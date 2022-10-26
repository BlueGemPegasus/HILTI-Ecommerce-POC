using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class testSO : MonoBehaviour
{
    public Item item;
    public Image itemImg;
    public TextMeshProUGUI toolNameText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI toolDescriptionText;
    public TextMeshProUGUI packageNameText;
    public TMP_Dropdown packageList;
    public TextMeshProUGUI toolDetailText;
    
    // Start is called before the first frame update
    void Start()
    {

        setPanel();
    }

    void setPanel()
    {
        itemImg.sprite = item.itemSprite;
        toolNameText.text = item.nameTxt;
        priceText.text = item.priceTxt;
        toolDescriptionText.text = item.descriptionTxt;
        packageList.options.Clear();
        foreach(string s in item.packageList)
        {
            packageList.options.Add(new TMP_Dropdown.OptionData(s));
        }
        packageNameText.text = item.packageList[0];
        toolDetailText.text = item.toolDetailDescription;
    }

}
