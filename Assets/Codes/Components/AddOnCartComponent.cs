using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AddOnCartComponent : MonoBehaviour
{
    public CartPage cartPage;
    
    public Button plusButton;
    public Button minusButton;

    public Image addOnComponentImage;
    public TextMeshProUGUI addOnComponentName;
    public TextMeshProUGUI addOnComponentPrice;
    public TextMeshProUGUI addOnComponentQuantity;

    public float price;
    public int quantity;

    private void OnEnable()
    {
        plusButton.onClick.AddListener(IncreaseQuantity);
        minusButton.onClick.AddListener(DecreaseQuantity);
    }

    private void OnDisable()
    {
        plusButton.onClick.RemoveAllListeners();
        minusButton.onClick.RemoveAllListeners();
    }

    private int GetCurrentQuantity()
    {
        int currentQuantity = int.Parse(addOnComponentQuantity.text);
        return currentQuantity;
    }

    public void IncreaseQuantity()
    {
        int previousQuantity = GetCurrentQuantity();
        addOnComponentQuantity.text = (previousQuantity + 1).ToString();
        cartPage.UpdatePrice();
    }

    public void DecreaseQuantity()
    {
        int previousQuantity = GetCurrentQuantity();
        addOnComponentQuantity.text = Mathf.Clamp((previousQuantity - 1), 0, 99).ToString();
        cartPage.UpdatePrice();
    }
}
