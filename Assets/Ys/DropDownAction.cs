using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DropDownAction : MonoBehaviour
{
    TMP_Dropdown m_Dropdown;

    //func to get the price string
    public static event Action<int> getPackagePrice;

    void Start()
    {
        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<TMP_Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            //action/function that will run if the value change
            DropdownValueChanged(m_Dropdown);
        });
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(TMP_Dropdown change)
    {
        getPackagePrice?.Invoke(change.value);
    }
}