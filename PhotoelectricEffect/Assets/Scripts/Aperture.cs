using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Aperture : DropdownSettings
{

    protected List<float> values;
    protected List<string> valuesToPrint;


    public void Awake()
    {
        float[] values_str = { 4f,
                               16f,
                               56f
                                };
        values = new List<float>(values_str);

        string[] valuesToP_str = { "2 mm",
                                   "4 mm",
                                   "8 mm"
                                };
        valuesToPrint = new List<string>(valuesToP_str);
        fillIn(valuesToPrint);
        

    }

    protected override void Start()
    {
        base.Start();
        owner.onApertureChange(values[0], valuesToPrint[0]);
    }

    public override void DropdownValueChanged(TMP_Dropdown change)
    {
        int i = change.value;
        owner.onApertureChange(values[i], valuesToPrint[i]);
        //print("New Value : " + change.value);

    }
}
