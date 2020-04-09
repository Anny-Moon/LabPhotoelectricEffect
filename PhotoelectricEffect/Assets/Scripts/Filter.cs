using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Filter : DropdownSettings 
{
    

    protected List<float> values;
    protected List<string> valuesToPrint;
    protected List<Color32> colors;

    public Image filter;

    public void Awake()
    {
        /* filters:
         * 365 nm purple
         * 405 nm violet
         * 436 nm blue
         * 546 nm green
         * 577 nm yellow
         */
        float[] values_str = { 8.21e14f,
                               7.40e14f,
                               6.87e14f,
                               5.49e14f,
                               5.20e14f

                                };
        values = new List<float>(values_str);

        string[] valuesToP_str = { "365 nm",
                                   "405 nm",
                                   "436 nm",
                                   "546 nm",
                                   "577 nm"
                                };
        valuesToPrint = new List<string>(valuesToP_str);
        fillIn(valuesToPrint);

        Color32[] filterColors = {new Color32(0x61, 0x00, 0x61, 0xff),
                                new Color32(0x82, 0x00, 0xc8, 0xff),
                                new Color32(0x1d, 0x00, 0xff, 0xff),
                                new Color32(0x96, 0xff, 0x00, 0xff),
                                new Color32(0xf6, 0xff, 0x00, 0xff),
                            };
        colors = new List<Color32>(filterColors);


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
        owner.onFilterChange(values[i], valuesToPrint[i]);
        filter.color = colors[i];
        print(colors[i]);
    }
   
}

