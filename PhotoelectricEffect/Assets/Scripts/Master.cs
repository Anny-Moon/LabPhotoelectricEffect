﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Master : MonoBehaviour
{
    float WORK_FUNCTION = 2.2f; // Cs 4.2 Zn eV
    float PLANK_CONSTANT = 4.135667696e-15f; // eV * s
    float INTENSITY_COEFF = 1f; // have to check this
    float POTENTIAL_BARRIER = 0.9f; // eV


    float frequency = 8.21e14f;
    int intensity = 4;

    public GameObject currentTextObject;
    private TextMeshProUGUI currentText;

    public double current;
    public float voltage;

    public Charge charge;

    float E_max; // max energy of electrons
    List<float> electrons; // energies of electrons

    void setE_max()
    {   //calculate new E_max
        //h * nu = W + Emax - eV
        E_max = PLANK_CONSTANT * frequency - WORK_FUNCTION;
    }

   
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
            }
            
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

    private void Awake()
    {
        currentText = currentTextObject.gameObject.GetComponent<TextMeshProUGUI>();
        //charge = new Charge();
        charge.setIntensity(intensity);

    }
    // Start is called before the first frame update
    void Start()
    {
        
        voltage = 0f;

       // InvokeRepeating("onAnyChange", 1.0f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onFilterChange(float arg)
    {
        //print(option);
        frequency = arg;
        charge.setFrequency(frequency);
        onAnyChange();
    }

    public void onApertureChange(float arg)
    {
        //print(option);
        intensity = (int)arg;
        charge.setIntensity(intensity);
        onAnyChange();

    }

    void onAnyChange()
    { 
        current = charge.calculateCurrent(voltage);
        currentText.text = current.ToString("0.000000E0");
        print("current " + current);
    }

    public void onSaveButtonClick()
    {
        //System.IO.FileStream oFileStream = null;
        //oFileStream = new System.IO.FileStream("./curentVSvoltage.csv", System.IO.FileMode.Create);
        StreamWriter writer = new StreamWriter("currentVSvoltage.csv", false);

        for (float V = -4.5f; V < 30; V += 0.1f)
        {
            double currenttt = charge.calculateCurrent(V);
            writer.Write(V+" "+currenttt + "\n");
        }
        writer.Close();
        //onAnyChange();
    }

    public void onVoltageInputChange(float volts_in)
    {
        voltage = volts_in;
        onAnyChange();
    }
}
