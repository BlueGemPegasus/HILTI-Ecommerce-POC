using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SuggestionCardComponent : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI description;

    public void SetCardComponent(Sprite img, string nameTxt, string text)
    {
        image.sprite = img;
        itemName.text = nameTxt;
        description.text = text;
    }
}
