using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Charge : MonoBehaviour
{

    float PLANK_CONSTANT = 4.135667696e-15f; // eV * s
    float MAX_FREQUENCY = 8.21e14f; // blue filter


    int NUM_OF_BINS = 100;
    int MAX_NUM_OF_ELECTRONS_PER_BIN = 100;
    
    double TOTAL_NUM_OF_ELECTRONS = 1e8;
    float POTENTIAL_BARRIER = 0.2f; // eV
    double ELEMENTARY_CHARGE = 1.60217662e-19;
    float WORK_FUNCTION = 2.2f; // Cs 4.2 Zn eV

    

    public List<float> energies;
    public List<double> numElectrons;

    float frequency;
    int intensity;

    public void setIntensity(int arg)
    {
        intensity = arg;
    }

    public void setFrequency(float arg)
    {
        frequency = arg;
    }

    public void Start()
    {
        float E_max_max = PLANK_CONSTANT * MAX_FREQUENCY - WORK_FUNCTION;
        float E_max_capacitor = -WORK_FUNCTION;
        //float E_min_capacitor = -WORK_FUNCTION - E_max_max;
        float E_min_capacitor = - PLANK_CONSTANT * MAX_FREQUENCY - 4f;
        float dE = (E_max_capacitor - E_min_capacitor) / (NUM_OF_BINS-1);
        energies = new List<float>();
        for (int i=0; i < NUM_OF_BINS; i++)
            energies.Add(E_min_capacitor + i*dE);

        calculateDensityOfStates();
    }

    void calculateDensityOfStates()
    {
        
        double totalNumber = 0;
        numElectrons = new List<double>();

        for (int i=0; i < NUM_OF_BINS ; i++)
        {
            numElectrons.Add(UnityEngine.Random.Range(0, MAX_NUM_OF_ELECTRONS_PER_BIN));
            totalNumber += numElectrons[i];
        }

        double coeff = TOTAL_NUM_OF_ELECTRONS / totalNumber;
        
        totalNumber = 0;
        for (int i = 0; i < NUM_OF_BINS; i++)
        {
            numElectrons[i] = coeff * numElectrons[i];
            totalNumber += numElectrons[i];
        }

       
    }

    public double calculateCurrent(float voltage)
    {
        
        double current = 0;
        for (int i = 0; i < NUM_OF_BINS; i++)
        {
            //print(energies[i]);
            if(PLANK_CONSTANT*frequency + energies[i] + voltage > 0)
                current += numElectrons[i];
            
        }
        return current*ELEMENTARY_CHARGE * intensity/56.0;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
