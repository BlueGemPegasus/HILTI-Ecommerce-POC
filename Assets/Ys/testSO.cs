using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testSO : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI toolNameText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI toolDescriptionText;
    public TextMeshProUGUI packageNameText;
    public TextMeshProUGUI packageList;
    public TextMeshProUGUI toolDetailText;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(item.nameTxt);
        Debug.Log(item.toolDetailDescription);
        toolDescriptionText.text = item.toolDetailDescription;
    }

}
