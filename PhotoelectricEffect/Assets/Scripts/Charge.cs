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
    float POTENTIAL_BARRIER = 5.0f; // eV
    double ELEMENTARY_CHARGE = 1.60217662e-19;
    float WORK_FUNCTION = 2.2f; // Cs 4.2 Zn eV

    float E_max_capacitor;
    float E_min_capacitor;

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
        E_max_capacitor = -WORK_FUNCTION;
        //float E_min_capacitor = -WORK_FUNCTION - E_max_max;
        E_min_capacitor = - PLANK_CONSTANT * MAX_FREQUENCY - 20f;
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

    double Gauss(double mu, double sigma)
    {
        return Math.Exp(-mu * mu / (sigma*sigma));
    }

    void calculateDensityOfStatesNew()
    {

        double totalNumber = 0;
        numElectrons = new List<double>();

        for (int i = 0; i < NUM_OF_BINS; i++)
        {
            numElectrons.Add(UnityEngine.Random.Range(0, MAX_NUM_OF_ELECTRONS_PER_BIN)*Gauss(i-NUM_OF_BINS, NUM_OF_BINS/4.0));
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
    /*
    double Box_Muller(double mean, double stdDev)
    {
        System.Random rand = new System.Random(); //reuse this if you are generating many
        double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                     Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        double randNormal =
                     mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
        return randNormal;
    }

    void calculateDensityOfStatesGauss()
    {
        double totalNumber = 0;
        numElectrons = new List<double>();

        for (int i = 0; i <1000; i++)
        {
            double mu = E_min_capacitor - E_max_capacitor;
            double sigma = - mu / 2.0 * 2;
            .Add(Box_Muller(mu,sigma ));
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
    */
    public double calculateCurrent(float voltage)
    {
        
        
        double photonEnergy = PLANK_CONSTANT * frequency;
        print("photon " + photonEnergy);
        double current = 0;
       
        
        for (int i = 0; i < NUM_OF_BINS; i++)
        {
            if (photonEnergy + energies[i] < 0)
                continue;
            //print(energies[i]);
            if(photonEnergy + energies[i] + voltage > 0)
                current += numElectrons[i];
            
        }
        return current*ELEMENTARY_CHARGE * intensity/56.0;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
