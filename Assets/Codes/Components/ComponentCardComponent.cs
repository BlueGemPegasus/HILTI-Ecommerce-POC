using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class ComponentCardComponent : MonoBehaviour
{
    public Image toolImage;
    public TextMeshProUGUI toolNameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI priceText;

    public Action onClickAR;
    public Action onClickCard;

    public int itemId;



    public void OnClick()
    {
        AppManager.Instance.GoToPage(PageName.ItemDetail, () => { SetItemDetailPage(itemId); });
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


    public void TemporaryFunctionToAR()
    {
        AppManager.Instance.GoToPage(PageName.ARPage);
    }

}
