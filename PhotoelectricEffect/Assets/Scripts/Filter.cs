using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Filter : DropdownSettings 
{
    

    protected List<float> values;
    protected List<string> valuesToPrint;


    public void Awake()
    {
        float[] values_str = { 8.21e14f,
                               6.87e14f,
                               5.20e14f
                                };
        values = new List<float>(values_str);

        string[] valuesToP_str = { "blue",
                                   "green",
                                   "red"
                                };
        valuesToPrint = new List<string>(valuesToP_str);

        fillIn(valuesToPrint);
        //print("filled units");

    }

    public override void DropdownValueChanged(TMP_Dropdown change)
    {
        int i = change.value;
        owner.onFilterChange(values[i]);
        //print("New Value : " + change.value);

    }
   
}

