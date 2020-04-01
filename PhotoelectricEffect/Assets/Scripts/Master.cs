using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Master : MonoBehaviour
{
    float frequency;
    float aperture;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onFilterChange(float option)
    {
        print(option);
        //frequency = newFrequency;
    }

    public void onSaveButtonClick()
    {
        print("save clicked");
    }
}
