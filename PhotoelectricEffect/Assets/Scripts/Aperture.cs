using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Aperture : DropdownSettings
{

    protected List<float> values;
    protected List<string> valuesToPrint;

    public Image filter;

    public void Awake()
    {
        float[] values_str = { 4f,
                               16f,
                               64f
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
        setValue(0);
    }

    public override void DropdownValueChanged(TMP_Dropdown change)
    {
        int i = change.value;
        setValue(i);
        //print("New Value : " + change.value);

    }

    private void setValue(int i)
    {
        owner.onApertureChange(values[i], valuesToPrint[i]);
        float newSize = Mathf.Sqrt(values[i]) * 10.0f;
        filter.rectTransform.sizeDelta = new Vector2(newSize, newSize);
    }
}
