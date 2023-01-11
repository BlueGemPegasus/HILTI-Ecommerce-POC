using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartPage : MonoBehaviour
{
    // When jump into this page, I need to get a reference data to see what I have added into Cart
    // That Data need to be accesible from anywhere, normally with Database Online, it could do it
    // What I could do now, is create a ScriptableObject/Model to save the thing, and make it able to remember even thou app reloaded
    // Or, make an Empty Array, but the issue will be everytime the app RELOAD, the Array will be clear, means, everytime it's clear when the application restarted

    // Prompt a message when Cart is Empty

    // Prompt a message when User trying to delete the item

    public URLRegister urlScript;

    [Header("Model")]
    public ItemHolder allitem;
    //public CartHolder cartList;

    public List<CartsItem> cartList;
    public List<string> discountCodes;


    // To store the Data where the player Press Add To Cart
    public int[] itemIDList;

    public GameObject cartComponentCardPrefab;
    public RectTransform cartContent;
    public RectTransform addOnContent;
    public GameObject tallyPanel;

    public TextMeshProUGUI cleanPrice;
    public TextMeshProUGUI discountAmount;
    public TextMeshProUGUI totalPrice;

    public TMP_InputField inputField;

    public Button checkOutButton;

    private float _cleanPrice;
    private float _discountAmount;
    [SerializeField] private float _totalPrice;

    private void OnEnable()
    {
        checkOutButton.onClick.AddListener(urlScript.GoToURL);
        UpdateCart();
        UpdatePrice();
    }

    private void OnDisable()
    {
        checkOutButton.onClick?.RemoveListener(urlScript.GoToURL);
        foreach (RectTransform item in cartContent)
        {
            Destroy(item.gameObject);
        }
    }

    private void UpdateCart()
    {
        if (cartList != null)
        {
            foreach (CartsItem cartItem in cartList)
            {
                foreach (Item item in allitem.Items)
                {
                    if (cartItem.id == item.itemId)
                    {
                        CartComponentCard component = Instantiate(cartComponentCardPrefab, cartContent).GetComponent<CartComponentCard>();
                        component.cartPage = transform.GetComponent<CartPage>();
                        component.itemID = item.itemId;
                        component.toolImage.sprite = item.itemSprite;
                        component.toolName.text = item.nameTxt;
                        component.quantity.text = cartItem.quantity.ToString();
                        component.originalPrice = cartItem.price;
                        component.toolpackagePrice.text = "RM " + (cartItem.quantity * cartItem.price).ToString("N0", CultureInfo.InvariantCulture);
                    }
                }

            }
        }
    }

    public void UpdatePrice()
    {
        float _stotalPrice = 0;

        if (cartContent.childCount > 0)
        {
            foreach (RectTransform item in cartContent)
            {
                CartComponentCard componentCard = item.GetComponent<CartComponentCard>();
                _stotalPrice += float.Parse(componentCard.toolpackagePrice.text.Replace("RM ", "").Replace(",", ""));
            }
        }
        else
            _stotalPrice = 0;

        foreach (RectTransform item in addOnContent)
        {
            AddOnCartComponent componentCard = item.GetComponent<AddOnCartComponent>();
            _stotalPrice += ((componentCard.price) * int.Parse(componentCard.addOnComponentQuantity.text));
        }

        _cleanPrice = _stotalPrice;
        _totalPrice = _cleanPrice - _discountAmount;

        if (_totalPrice < 0)
            _totalPrice = 0;

        cleanPrice.text = "RM" + _cleanPrice.ToString("N0", CultureInfo.InvariantCulture);
        discountAmount.text = "RM" + _discountAmount.ToString("N0", CultureInfo.InvariantCulture);
        totalPrice.text = "RM" + _totalPrice.ToString("N0", CultureInfo.InvariantCulture);

    }

    public void OnEndEdit()
    {
        if (discountCodes.Contains(inputField.text))
        {
            _discountAmount = 500;
            UpdatePrice();
        }
        else
        {
            inputField.text = "The code you entered does not exsits!";
        }
    }
}
