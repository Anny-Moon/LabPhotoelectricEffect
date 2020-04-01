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
        float[] values_str = { 40f,
                               160f,
                               560f
                                };
        values = new List<float>(values_str);

        string[] valuesToP_str = { "2 mm",
                                   "4 mm",
                                   "8 mm"
                                };
        valuesToPrint = new List<string>(valuesToP_str);

        fillIn(valuesToPrint);
        //print("filled units");


    }

    public override void DropdownValueChanged(TMP_Dropdown change)
    {
        int i = change.value;
        owner.onApertureChange(values[i]);
        //print("New Value : " + change.value);

    }
}
