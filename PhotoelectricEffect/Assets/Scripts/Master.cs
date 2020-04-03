using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Master : MonoBehaviour
{
    

    float frequency = 8.21e14f;
    int intensity = 4;

    public GameObject currentTextObject;
    private TextMeshProUGUI currentText;

    public double current;
    public float voltage;

    public Charge charge;

    float E_max; // max energy of electrons
    List<float> electrons; // energies of electrons


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
        StreamWriter writer = new StreamWriter("currentVSvoltage.dat", false);

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
