using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    int DNALength = 2;      // two sets of decisions to make: 1st - what to do when can see the platform; 2nd - when can't see the platform
    public float timeAlive;
    public DNA dna;
    public GameObject eyes;

    public float timeWalking = 0f;     // used as fitness. Higher fitness for those that are walking, not standing still and rotating

    bool alive = true;
    bool seeGround = true;


    private int numActions = 3;

    private float translateModifier = 0.1f;

    public float drawRayDuration = 2f;

	private void OnCollisionEnter(Collision obj)
	{
        if(obj.gameObject.tag == "Dead")
        {
            Debug.Log("touched the dead cube");
            alive = false;
        }
	}

	public void Init()
	{
        //initialize DNA
        //0 forward
        //1 left
        //2 right
        dna = new DNA(DNALength, numActions);       // remember, DNALength -- see and can't see the platform
        timeAlive = 0;
        alive = true;
	}

	private void Update()
	{
        if (!alive)
            return;
        
        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 10, Color.red, drawRayDuration);
        seeGround = false;
        RaycastHit hit;
        if (Physics.Raycast(eyes.transform.position, eyes.transform.forward * 10, out hit))
        {
            if (hit.collider.tag == "Platform")
            {
                seeGround = true;
            }
        }
        timeAlive = PopulationManager.elapsed;


        if (seeGround)
        {
            int actionNum = dna.GetGene(0);

            switch(actionNum)
            {
                case 0: // move forward     // only update fitness when it's walking
                    transform.Translate(Vector3.forward * translateModifier);
                    AddTimeWalking();
                    break;

                case 1: // turn left
                    transform.Rotate(0f, -90f, 0f);
                    break;

                case 2: // turn right
                    transform.Rotate(0f, 90f, 0f);
                    break;
            }
        }
        else
        {
            int actionNum = dna.GetGene(1);

            switch (actionNum)
            {
                case 0: // move forward
                    transform.Translate(Vector3.forward * translateModifier);
                    AddTimeWalking();
                    break;

                case 1: // turn left
                    transform.Rotate(0f, -90f, 0f);
                    break;

                case 2: // turn right
                    transform.Rotate(0f, 90f, 0f);
                    break;
            }
        }


	}

    private void AddTimeWalking()
    {
        timeWalking += 1;
    }

}