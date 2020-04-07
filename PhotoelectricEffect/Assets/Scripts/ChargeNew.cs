using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeNew : MonoBehaviour
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

    public double calculateCurrent(float voltage)
    {
        double E_max = frequency * PLANK_CONSTANT - WORK_FUNCTION;

        if(E_max<0)
            return 0;

        double current = 0;
        current = 2 * (voltage+E_max) * intensity/5.0;
        return current;
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
