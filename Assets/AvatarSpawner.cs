using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSpawner : MonoBehaviour {

    // Ethan
    public GameObject avatarPrefab;
    private GameObject avatar;


	public void InstantiateAvatar(Transform tran)
    {
        avatar = Instantiate(avatarPrefab, tran.position, tran.rotation);
        avatar.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = tran;
    }

    public void DestroyAvatar()
    {
        Destroy(avatar);
    }
}
