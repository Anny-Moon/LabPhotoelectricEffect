using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownSettings : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    TMP_Dropdown.OptionData option;
    public Master owner;

    List<TMP_Dropdown.OptionData> listOfOptions = new List<TMP_Dropdown.OptionData>();

    public void fillIn(List<string> options)
    {
        dropdown = gameObject.GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();

        for (int i = 0; i < options.Count; i++)
        {
            option = new TMP_Dropdown.OptionData();
            option.text = options[i];
            listOfOptions.Add(option);
        }

        dropdown.AddOptions(listOfOptions);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    public virtual void DropdownValueChanged(TMP_Dropdown change) { }
   
}
