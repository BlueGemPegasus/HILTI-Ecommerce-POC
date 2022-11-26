using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Linq;

public class GamificationSuggestion : MonoBehaviour
{
    public Image itemImg;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;


    //object to instanciate
    public GameObject otherItemPrefeb;
    public GameObject AccessoriesPrefeb;

    //place to instanciate
    public GameObject otherItemPanel;
    public GameObject AccessoriesPanel;

    //category btn
    public Button all;
    public Button tools;
    public Button inserts;
    public Button battery;
    public Transform categoryPanel;

    //view item detail btn
    public Button viewItem;

    //store created game object in local
    private List<GameObject> suggestionList = new List<GameObject>();
    private List<GameObject> similarItem = new List<GameObject>();

    //information needed 
    public List<SuggestionSO> suggestionSo;
    public ItemHolder allItem;
    public GamificationManager manager;

    //current local data
    private SuggestionSO currentSuggestion;
    private int selectedCategory = 0;

    public ProductDetailPage productDetailPage;

    private void OnEnable()
    {
        selectedCategory = 0;
        SetupSuggestionPage();
        all.onClick.AddListener(() => suggestionFilterBtn(0));
        tools.onClick.AddListener(() => suggestionFilterBtn(1));
        inserts.onClick.AddListener(() => suggestionFilterBtn(2));
        battery.onClick.AddListener(() => suggestionFilterBtn(3));
        viewItem.onClick.AddListener(() => ViewSuggestedItem(currentSuggestion.suggestedItemId));
        all.interactable = false;
        all.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    private void OnDisable()
    {
        all.onClick.RemoveAllListeners();
        tools.onClick.RemoveAllListeners();
        inserts.onClick.RemoveAllListeners();
        battery.onClick.RemoveAllListeners();
        viewItem.onClick.RemoveAllListeners();
    }

    public void SetupSuggestionPage()
    {
        if (suggestionSo == null || allItem == null) return;
        currentSuggestion = suggestionSo.FirstOrDefault(x => x.SuggestionNumber == manager.currentSuggestion);
        if (currentSuggestion == null) return;
        if (similarItem != null)
        {
            foreach (GameObject obj in similarItem)
            {
                Destroy(obj);
            }
        }
        if (suggestionList != null)
        {
            foreach (GameObject obj in suggestionList)
            {
                Destroy(obj);
            }
        }
        //insert item information
        Item selectedItem = allItem.Items.FirstOrDefault(x => x.itemId == currentSuggestion.suggestedItemId);
        itemImg.sprite = selectedItem.itemSprite;
        itemName.text = selectedItem.nameTxt;
        itemPrice.text = selectedItem.packageList[0].packagePrice;


        CreateAccessoriesList();
        CreateSimilarItem();
    }

    public void CreateAccessoriesList()
    {
        if (selectedCategory == 1 || selectedCategory == 0)
        {
            foreach (suggestionItemDetail item in currentSuggestion.tools)
            {
                GameObject newItem = Instantiate(AccessoriesPrefeb, AccessoriesPanel.transform);
                SuggestionCardComponent itemComponent;
                if (newItem.TryGetComponent<SuggestionCardComponent>(out itemComponent))
                {
                    itemComponent.SetCardComponent(item.image, item.itemName, item.des);
                }
                suggestionList.Add(newItem);
            }

        }
        if (selectedCategory == 2 || selectedCategory == 0)
        {
            foreach (suggestionItemDetail item in currentSuggestion.inserts)
            {
                GameObject newItem = Instantiate(AccessoriesPrefeb, AccessoriesPanel.transform);
                SuggestionCardComponent itemComponent;
                if (newItem.TryGetComponent<SuggestionCardComponent>(out itemComponent))
                {
                    itemComponent.SetCardComponent(item.image, item.itemName, item.des);
                }
                suggestionList.Add(newItem);
            }
        }
        if (selectedCategory == 3 || selectedCategory == 0)
        {
            foreach (suggestionItemDetail item in currentSuggestion.batteries)
            {
                GameObject newItem = Instantiate(AccessoriesPrefeb, AccessoriesPanel.transform);
                SuggestionCardComponent itemComponent;
                if (newItem.TryGetComponent<SuggestionCardComponent>(out itemComponent))
                {
                    itemComponent.SetCardComponent(item.image, item.itemName, item.des);
                }
                suggestionList.Add(newItem);
            }
        }
    }

    public void CreateSimilarItem()
    {
        foreach (int id in currentSuggestion.similarToolId)
        {
            GameObject newTool = Instantiate(otherItemPrefeb, otherItemPanel.transform);
            ComponentCardComponent component;
            if (newTool.TryGetComponent<ComponentCardComponent>(out component))
            {
                Item item = allItem.Items.FirstOrDefault(x => x.itemId == id);
                if (item != null)
                {
                    component.toolImage.sprite = item.itemSprite;
                    component.toolNameText.text = item.nameTxt;
                    component.descriptionText.text = item.descriptionTxt;
                    component.priceText.text = item.packageList[0].packagePrice;

                }
            }
            similarItem.Add(newTool);
        }
    }

    public void suggestionFilterBtn(int selection)
    {
        foreach (Transform btn in categoryPanel)
        {
            btn.GetComponent<Button>().interactable = true;
            btn.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        }

        switch (selection)
        {
            case 0:
                all.interactable = false;
                all.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                break;
            case 1:
                tools.interactable = false;
                tools.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                break;
            case 2:
                inserts.interactable = false;
                inserts.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                break;
            case 3:
                battery.interactable = false;
                battery.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                break;
        }
        
        //clear all item in list
        if (suggestionList.Count > 0)
        {
            foreach (GameObject item in suggestionList)
            {
                Destroy(item);
            }
        }
        //instanciate new item to list
        selectedCategory = selection;
        CreateAccessoriesList();
    }

    public void ViewSuggestedItem(int newId)
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
