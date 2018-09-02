﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA {

    List<int> genes = new List<int>();
    int dnaLength = 0;
    int maxValues = 0;

    public DNA(int len, int maxVal)
    {
        dnaLength = len;
        maxValues = maxVal;
        SetRandom();
    }

    public void SetRandom()
    {
        genes.Clear();
        for (int i = 0; i < dnaLength; i++)
        {
            genes.Add(Random.Range(0, maxValues));
        }
    }

    public void SetGeneAtPos(int pos, int val)
    {
        genes[pos] = val;
    }

    public void Combine(DNA d1, DNA d2)
    {
        for (int i = 0; i < dnaLength; i++)
        {
            if (i < dnaLength/2.0)
            {
                genes[i] = d1.genes[i];
            }
            else
            {
                genes[i] = d2.genes[i];
            }
        }
    }

    public void Mutate()
    {
        genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValues);
    }

    public int GetGene(int pos)
    {
        return genes[pos];
    }
}
