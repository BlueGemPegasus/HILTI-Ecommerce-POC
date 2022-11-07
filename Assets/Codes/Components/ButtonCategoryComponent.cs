using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonCategoryComponent : MonoBehaviour
{
    public ItemHolder allItem;
    public int id;
    public Button thisButton;
    public TextMeshProUGUI categoryText;

    public void ButtonOnClick()
    {
        
        CategoriesComponent categoriesComponent = GameObject.Find("Panel_Category").GetComponent<CategoriesComponent>();
        categoriesComponent.Clear();
        categoriesComponent.EnableAllButton();

        thisButton.interactable = false;
        categoryText.color = Color.white;

        foreach (Categories categories in categoriesComponent.CategoryList)
        {
            if (id == categories.Id)
            {
                foreach (Item item in allItem.Items)
                {
                    for (int i = 0; i < categories.itemId.Length; i++)
                    {
                        if (categories.itemId[i] == item.itemId)
                        {
                            ComponentCardComponent component = Instantiate(categoriesComponent.itemListPrefab, categoriesComponent.itemListContent).GetComponent<ComponentCardComponent>();
                            component.toolImage.sprite = item.itemSprite;
                            component.toolNameText.text = item.nameTxt;
                            component.descriptionText.text = item.descriptionTxt;
                            //component.priceText.text = item.packageList.
                        }
                    }
                }
            }
        }

    }
}
