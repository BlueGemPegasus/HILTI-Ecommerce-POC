using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartComponentCard : MonoBehaviour
{
    [Tooltip("This reference the image to replace")]
    public Image toolImage;
    public TextMeshProUGUI toolName;
    public TextMeshProUGUI toolpackagePrice;
    public TextMeshProUGUI quantity;
    public Button plus_Button;
    public Button minus_Button;
}
