using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ComponentCardComponent : MonoBehaviour
{
    public Image toolImage;
    public TextMeshProUGUI toolNameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI priceText;

    public Action onClickAR;
    public Action onClickCard;
}
