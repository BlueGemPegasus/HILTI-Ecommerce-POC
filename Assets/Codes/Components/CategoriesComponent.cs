using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class CategoriesComponent : MonoBehaviour
{
    [Header("Model")]
    public ItemHolder allitem;

    [Header("Scriptable")]
    public CategoriesHolder allCategories;
    public Categories categories;

    [Header("Spawn At Target References")]
    public Transform categoryContent;
    public Transform itemListContent;

    [Header("Prefab References")]
    public GameObject categoryButtonPrefab;
    public GameObject itemListPrefab;

    [Header("CategoryList")]
    public List<Categories> CategoryList;

    public Action onClick;

    public void Start()
    {
        SpawnItemToCategory();
    }

    public void SpawnItemToCategory()
    {
        if (CategoryList != null)
        {
            foreach (Categories categories in CategoryList)
            {
                ButtonCategoryComponent buttonComponent = Instantiate(categoryButtonPrefab, categoryContent).GetComponent<ButtonCategoryComponent>();
                buttonComponent.categoryText.text = categories.categoryTxt;
                buttonComponent.id = categories.Id;
                //buttonComponent.gameObject.GetComponent<Button>().onClick.AddListener(ButtonOnClick);
            }
            GameObject firstButton = categoryContent.GetChild(0).gameObject;
            firstButton.GetComponent<Button>().interactable = false;
            firstButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            
            foreach (Categories categories in CategoryList)
            {
                if (firstButton.GetComponent<ButtonCategoryComponent>().id == categories.Id)
                {
                    foreach (Item item in allitem.Items)
                    {
                        for (int i = 0; i < categories.itemId.Length; i++)
                        {
                            if (categories.itemId[i] == item.itemId)
                            {
                                ComponentCardComponent component = Instantiate(itemListPrefab, itemListContent).GetComponent<ComponentCardComponent>();
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

    public void SpawnItemToItemList()
    {
        if (CategoryList != null)
        {

        }
    }

    public void Clear()
    {
        foreach (Transform itemListContent in itemListContent)
        {
            Destroy(itemListContent.gameObject);
        }
    }

    public void ButtonOnClick()
    {
        EnableAllButton();
    }

    public void EnableAllButton()
    {
        foreach (Transform button in categoryContent)
        {
            button.GetComponent<Button>().interactable = true;
            button.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        }
    }

}
