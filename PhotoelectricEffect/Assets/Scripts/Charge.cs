using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Charge : MonoBehaviour
{
    int NUM_OF_BINS = 100;
    int MAX_NUM_OF_ELECTRONS_PER_BIN = 100;
    Int64 TOTAL_NUM_OF_ELECTRONS = 100000000;
    float POTENTIAL_BARRIER = 0.9f; // eV
    double ELEMENTARY_CHARGE = 1.60217662e-19;

    public List<float> energies;
    public List<int> numElectrons;

    float E_max;
    int intensity;

    public void setE_max(float arg)
    {
        E_max = arg;
        print("E " + E_max);
    }

    public void setIntensity(int arg)
    {
        intensity = arg;
    }

    public void setEnergies()
    {
        if (E_max < 0)
            return;

        energies = new List<float>();
        for (int i=0; i < NUM_OF_BINS; i++)
            energies.Add(E_max / NUM_OF_BINS * i);
    }

    public void setNumElectrons()
    {
        if (E_max<0)
            return;

        Int64 totalNumber = 0;
        numElectrons = new List<int>();
        for (int i=0; i < NUM_OF_BINS ; i++)
        {
            numElectrons.Add(UnityEngine.Random.Range(0, MAX_NUM_OF_ELECTRONS_PER_BIN));
            totalNumber += numElectrons[i];
        }

        Int64 a = intensity * TOTAL_NUM_OF_ELECTRONS;
        double coeff = a / totalNumber;
        
        totalNumber = 0;
        for (int i = 0; i < NUM_OF_BINS; i++)
        {
            numElectrons[i] = (int)(coeff * numElectrons[i]);
            totalNumber += numElectrons[i];
        }

       
    }

    public double calculateCurrent(float voltage)
    {
        if (E_max < 0)
            return 0;
        print("emax " + E_max);
        double current = 0;
        for (int i = 0; i < NUM_OF_BINS; i++)
        {
            //print(energies[i]);
            if(energies[i]+voltage-POTENTIAL_BARRIER > 0)
            {
    
                current += numElectrons[i];
            }
        }
        return current*ELEMENTARY_CHARGE;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
