using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VoltageInput : MonoBehaviour
{
    public Master owner;
    float UPPER_LIMIT = 30f; // V
    float LOWER_LIMIT = -4.5f; //V
    float voltage;
    TMP_InputField input;
     

    // Start is called before the first frame update
    void Start()
    {
        input = this.gameObject.GetComponent<TMP_InputField>();
        input.onEndEdit.AddListener(onInputChange);
    }

    float Validator(string arg)
    {
        float result;
        bool isNumber = float.TryParse(arg, out result);
        if (isNumber)
        {
            if (result > UPPER_LIMIT)
                return UPPER_LIMIT;
            if (result < LOWER_LIMIT)
                return LOWER_LIMIT;
            else
                return result;
        }
        return 0;
    }
    

    public void onInputChange(string arg)
    {
        voltage = Validator(arg);
        print("volt " + voltage);
        input.text = voltage.ToString();
        owner.onVoltageInputChange(voltage);

    }

    public void onInputChangeFloat(float arg)
    {
        //voltage = Validator(arg);
        //print("volt " + voltage);
        input.text = arg.ToString();
        owner.onVoltageInputChange(arg);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
