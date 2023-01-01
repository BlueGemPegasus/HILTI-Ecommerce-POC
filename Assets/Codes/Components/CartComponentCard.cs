using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartComponentCard : MonoBehaviour
{
    [Tooltip("This reference the image to replace")]
    public Image toolImage;
    public TextMeshProUGUI toolName;
    public TextMeshProUGUI toolpackagePrice;
    public TextMeshProUGUI quantity;
    public Button plus_Button;
    public Button minus_Button;

    private int GetCurrentQuantity()    
    {
        int currentQuantity = int.Parse(quantity.text);
        return currentQuantity;
    }

    public void IncreaseQuantity()
    {
        int previousQuantity = GetCurrentQuantity();
        quantity.text = (previousQuantity + 1).ToString();
    }

    public void DecreaseQuantity()
    {
        int previousQuantity = GetCurrentQuantity();
        if (previousQuantity != 1)
        {
            quantity.text = Mathf.Clamp((previousQuantity - 1), 1, 99).ToString();
        }
        else
        {
            Destroy(transform.gameObject);
        }

    }
}
