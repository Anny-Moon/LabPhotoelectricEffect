using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    double Gauss(double x, double mu, double sigma)
    {
        return System.Math.Exp(-(x-mu)*(x-mu) / (sigma * sigma));
    }

    double shape(double x, double mu, double sigma)
    {
        //current = 2 * (voltage+E_max) * intensity/5.0;
        double cutoff = mu / 2.0;
        double current = 0;
        if (x < mu - cutoff)
            current = Gauss(x + cutoff, mu, sigma) - Gauss(cutoff, mu, sigma);

        else
            current = Gauss(mu, mu, sigma) - Gauss(cutoff, mu, sigma);



        return current;
    }

    public double calculateCurrent(float voltage)
    {
        double E_max = frequency * PLANK_CONSTANT - WORK_FUNCTION;
        print("E_max = " + E_max);
        if(E_max<0)
            return 0;

        double mu = 30;
        double sigma = 20;
        double current = 0;
        //current = 2 * (voltage+E_max) * intensity/5.0;

        
        current = shape((voltage + E_max), mu, sigma);

        if (current < 0)
            return 0;
        return intensity*current * 1e-10;
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
