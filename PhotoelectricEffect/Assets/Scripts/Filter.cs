using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Filter : DropdownSettings 
{
    
    public enum filter
    {
        red,
        yellow,
        blue
    };


    public float value;
    //public DropdownSettings dropdown;

    protected List<float> values;
    protected List<string> valuesToPrint;

    public void Awake()
    {
        float[] values_str = { 415.0f,
                               555.0f,
                               612.0f
                                };
        values = new List<float>(values_str);

        string[] valuesToP_str = { "blue",
                                   "green",
                                   "red"
                                };
        valuesToPrint = new List<string>(valuesToP_str);

        fillIn(valuesToPrint);
        //print("filled units");

        value = 415.0f;

    }

    public  override void DropdownValueChanged(TMP_Dropdown change)
    {
        int i = change.value;
        owner.onFilterChange(values[i]);
        //print("New Value : " + change.value);

    }
   
}

