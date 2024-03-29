using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Globalization;

public class ProductDetailPage : MonoBehaviour
{
    public ItemHolder allItem;
    public Item item;
    public Image itemImg;
    public TextMeshProUGUI toolNameText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI toolDescriptionText;
    public TextMeshProUGUI packageNameText;
    public TMP_Dropdown packageList;
    public TextMeshProUGUI toolDetailText;

    public Button addToCartButton;

    public CartPage cartHolder;

    private int _itemId;

    //Quantity Panel
    [Tooltip("Quantity Panel")]
    public TextMeshProUGUI quantityText;
    //public Button increaseBtn;
    //public Button decreaseBtn;


    //test
    public int id = 10;

    // Start is called before the first frame update
    void Start()
    {
        //test
        //SetSelectedItem(id);
    }

    void SetPanel()
    {
        itemImg.sprite = item.itemSprite;
        toolNameText.text = item.nameTxt;

        toolDescriptionText.text = item.descriptionTxt;
        toolDetailText.text = item.toolDetailDescription;

        //clear drop down list option
        packageList.options.Clear();

        //assign new option based on selected item/product
        foreach (ItemPackage itemPackage in item.packageList)
        {
            packageList.options.Add(new TMP_Dropdown.OptionData(itemPackage.packageContents));
        }
        //assign default contents for drop down
        packageList.value = 1;
        //packageNameText.text = item.packageList[0];
        priceText.text = item.packageList[0].packagePrice;

    }

    public void SetSelectedItem(int id)
    {
        item = allItem.Items.FirstOrDefault(x => x.itemId == id);
        if (item != null)
        {
            _itemId = id;
            SetPanel();
        }
        //LayoutRebuilder.ForceRebuildLayoutImmediate(contentPanel);
    }

    public void SetPackagePrice(int arrayPos)
    {
        //check is the item exist
        if (item != null)
        {
            //check is the array position exist
            if (item.packageList.Count > arrayPos)
                priceText.text = item.packageList[arrayPos].packagePrice;
        }
    }

    private void OnEnable()
    {
        DropDownAction.getPackagePrice += SetPackagePrice;
        addToCartButton.onClick.AddListener(AddToCart);
    }

    private void OnDisable()
    {
        DropDownAction.getPackagePrice -= SetPackagePrice;
        addToCartButton.onClick.RemoveAllListeners();
    }

    private int GetCurrentQuantity()
    {
        int currentQuantity = int.Parse(quantityText.text);
        return currentQuantity;
    }

    public void IncreaseQuantity()
    {
        int previousQuantity = GetCurrentQuantity();
        quantityText.text = (previousQuantity + 1).ToString();
    }

    public void DecreaseQuantity()
    {
        int previousQuantity = GetCurrentQuantity();
        quantityText.text = Mathf.Clamp((previousQuantity - 1), 0, 99).ToString();
    }

    public void ReturnMainMenu()
    {
        AppManager.Instance.GoToPage(PageName.MainMenu);
    }

    public void TemporaryFunctionToAR()
    {
        AppManager.Instance.GoToPage(PageName.ARPage);
    }

    private void AddToCart()
    {
        if (quantityText.text == "0")
            return;

        var cartItemScriptableObject = ScriptableObject.CreateInstance<CartsItem>();
        cartItemScriptableObject.id = _itemId;
        cartItemScriptableObject.price = float.Parse(priceText.text.Replace("RM ", "").Replace(",", ""));
        cartItemScriptableObject.quantity = int.Parse(quantityText.text);

        bool matchFound = false;

        if (cartHolder.cartList.Count != 0)
        {
            foreach (CartsItem items in cartHolder.cartList)
            {
                if (cartItemScriptableObject.id == items.id && cartItemScriptableObject.price == items.price)
                {
                    items.quantity += cartItemScriptableObject.quantity;
                    matchFound = true;
                    break;
                }
            }
        }

        if (!matchFound)
        {
            cartHolder.cartList.Add(cartItemScriptableObject);
        }
    }
}
