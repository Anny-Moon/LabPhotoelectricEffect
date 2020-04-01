using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Master : MonoBehaviour
{
    float WORK_FUNCTION = 2.1f; // Cs 4.2 Zn eV
    float PLANK_CONSTANT = 4.135667696e-15f; // eV * s
    float INTENSITY_COEFF = 1f; // have to check this
    float POTENTIAL_BARRIER = 0.9f; // eV


    float frequency;
    int intensity = 100;

    public float current;
    public float voltage;

    float E_max; // max energy of electrons
    List<float> electrons; // energies of electrons

    void setNewElectronsEnergies()
    {
        //calculate new E_max
        //h * nu = W + Emax - eV
        E_max = PLANK_CONSTANT * frequency - WORK_FUNCTION;
        print("emax " + E_max);

        // create new list with electrons energies
        electrons = new List<float>();
        if (E_max < 0)
        {
            for (int i = 0; i < intensity; i++)
            {
                electrons.Add(0f);
                //print(electrons[i]);
            };
            
        }
        

        else
        {
            for (int i = 0; i < intensity; i++)
            {
                electrons.Add(Random.Range(0f, E_max) + voltage - POTENTIAL_BARRIER);
                //print(electrons[i]);
            }
        }
    }

    void setNewCurrent()
    {
        current = 0;
        for (int i=0; i < electrons.Count; i++)
        {
            
            if (electrons[i] > 0)
                current += 1.0f;
        }
        current *= INTENSITY_COEFF;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        voltage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onFilterChange(float option)
    {
        //print(option);
        frequency = option;
        setNewElectronsEnergies();
        setNewCurrent();
        print("current " + current);

    }

    public void onSaveButtonClick()
    {
        print("save clicked");
    }
}
