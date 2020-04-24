using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Master : MonoBehaviour
{
    

    float frequency;
    string filter;
    int intensity;
    string aperture;

    public GameObject currentTextObject;
    private TextMeshProUGUI currentText;

    public GameObject voltageTextObject;
    private TextMeshProUGUI voltageText;

    public double current;
    public float voltage;

    public Charge charge;

    float E_max; // max energy of electrons
    List<float> electrons; // energies of electrons


    private void Awake()
    {
        currentText = currentTextObject.gameObject.GetComponent<TextMeshProUGUI>();
        voltageText = voltageTextObject.gameObject.GetComponent<TextMeshProUGUI>();
        charge.setIntensity(intensity);

    }
    // Start is called before the first frame update
    void Start()
    {
        
        voltage = 0f;
        onVoltageInputChange(voltage);

        InvokeRepeating("displayCurrent", 1.0f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onFilterChange(float arg, string name)
    {
        //print(arg);
        frequency = arg;
        filter = name;
        print(filter);
        charge.setFrequency(frequency);
        onAnyChange();
    }

    public void onApertureChange(float arg, string name)
    {
        //print(option);
        intensity = (int)arg;
        aperture = name;
        charge.setIntensity(intensity);
        onAnyChange();

    }

    double addNoise(double arg)
    {
        return (arg + 1e-14*UnityEngine.Random.Range(-1f, 1f));
    }

    void displayCurrent()
    {
        double tmp = addNoise(current);
        currentText.text = tmp.ToString("0.00000E0");
        print("current " + current);
    }

    void onAnyChange()
    { 
        current = charge.calculateCurrent(voltage);
        displayCurrent();
        
    }

    public void onSaveButtonClick()
    {
        //System.IO.FileStream oFileStream = null;
        //oFileStream = new System.IO.FileStream("./curentVSvoltage.csv", System.IO.FileMode.Create);
        StreamWriter writer = new StreamWriter("currentVSvoltage_" + filter.Remove(filter.Length - 3) + "_"+ aperture.Remove(aperture.Length - 3) + ".dat", false);

        for (float V = -4.5f; V < 30; V += 0.1f)
        {
            double tmp = charge.calculateCurrent(V);
            tmp = addNoise(tmp);
            writer.Write(V+" "+tmp + "\n");
        }
        writer.Close();
        //onAnyChange();
    }

    public void onVoltageInputChange(float volts_in)
    {
        voltage = volts_in;
        voltageText.text = voltage.ToString();
        onAnyChange();
    }
}
