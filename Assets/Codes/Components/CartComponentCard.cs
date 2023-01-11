using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Globalization;

public class CartComponentCard : MonoBehaviour
{
    public CartPage cartPage;

    [Tooltip("This reference the image to replace")]
    public int itemID;
    public float originalPrice;
    public Image toolImage;
    public TextMeshProUGUI toolName;
    public TextMeshProUGUI toolpackagePrice;
    public TextMeshProUGUI quantity;
    public Button plus_Button;
    public Button minus_Button;
    public Button itemButton;

    private int GetCurrentQuantity()
    {
        int currentQuantity = int.Parse(quantity.text);
        return currentQuantity;
    }

    public void IncreaseQuantity()
    {
        int previousQuantity = GetCurrentQuantity();
        quantity.text = (previousQuantity + 1).ToString();
        toolpackagePrice.text = "RM " + (GetCurrentQuantity() * originalPrice).ToString("N0", CultureInfo.InvariantCulture);
        UpdateCartList(GetCurrentQuantity());
        cartPage.UpdatePrice();
    }

    public void DecreaseQuantity()
    {
        int previousQuantity = GetCurrentQuantity();
        if (previousQuantity != 1)
        {
            quantity.text = Mathf.Clamp((previousQuantity - 1), 1, 99).ToString();
            toolpackagePrice.text = "RM " + (GetCurrentQuantity() * originalPrice).ToString("N0", CultureInfo.InvariantCulture);
            UpdateCartList(GetCurrentQuantity());
            cartPage.UpdatePrice();
        }
        else
        {
            RemoveFromCartList();
            cartPage.UpdatePrice();
            Destroy(transform.gameObject);
        }
    }

    private void UpdateCartList(int newQuantity)
    {
        for (int i = 0; i < cartPage.cartList.Count; i++)
        {
            if (cartPage.cartList[i].id == itemID && cartPage.cartList[i].price == originalPrice)
            {
                cartPage.cartList[i].quantity = newQuantity;
                break;
            }
        }
    }

    private void RemoveFromCartList()
    {
        for (int i = 0; i < cartPage.cartList.Count; i++)
        {
            if (cartPage.cartList[i].id == itemID && cartPage.cartList[i].price == originalPrice)
            {
                cartPage.cartList.RemoveAt(i);
                break;
            }
        }
    }

    public void GoToItemDetailPage()
    {
        AppManager.Instance.GoToPage(PageName.ItemDetail, () => { SetItemDetailPage(itemID); });

    }

    public void SetItemDetailPage(int newId)
    {
        GameObject obj = null;
        obj = AppManager.Instance.AllPage.FirstOrDefault(x => x.gameObject.name == "ItemDetailPage");
        if (obj != null)
        {
            ProductDetailPage productDetailScript;
            bool isAble;
            isAble = obj.TryGetComponent<ProductDetailPage>(out productDetailScript);
            if (isAble)
            {
                productDetailScript.SetSelectedItem(newId);
                productDetailScript.id = newId;
            }
        }
    }
}
