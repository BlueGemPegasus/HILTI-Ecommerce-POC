using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CartPage : MonoBehaviour
{
    // When jump into this page, I need to get a reference data to see what I have added into Cart
    // That Data need to be accesible from anywhere, normally with Database Online, it could do it
    // What I could do now, is create a ScriptableObject/Model to save the thing, and make it able to remember even thou app reloaded
    // Or, make an Empty Array, but the issue will be everytime the app RELOAD, the Array will be clear, means, everytime it's clear when the application restarted

    // Prompt a message when Cart is Empty

    // Prompt a message when User trying to delete the item


    [Header("Model")]
    public ItemHolder allitem;
    //public CartHolder cartList;

    public List<CartsItem> cartList;

    // To store the Data where the player Press Add To Cart
    public int[] itemIDList;

    public GameObject cartComponentCardPrefab;
    public RectTransform cartContent;
    public GameObject tallyPanel;


    private void OnEnable()
    {
        UpdateCart();
    }

    private void OnDisable()
    {

    }



    private void UpdateCart()
    {
        if (cartList != null)
        {
            foreach(CartsItem cartItem in cartList)
            {
                foreach (Item item in allitem.Items)
                {
                    if(cartItem.id == item.itemId)
                    {
                        CartComponentCard component = Instantiate(cartComponentCardPrefab, cartContent).GetComponent<CartComponentCard>();
                        component.toolImage.sprite = item.itemSprite;
                        component.toolName.text = item.nameTxt;
                        component.quantity.text = cartItem.quantity.ToString();
                        component.toolpackagePrice.text = (cartItem.quantity * cartItem.price).ToString();
                    }
                } 
                
            }
        }
    }
}
