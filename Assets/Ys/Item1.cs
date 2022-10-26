using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="item")]
public class Item1 : ScriptableObject
{
    public Sprite itemSprite;

    public string nameTxt;
    public string priceTxt;
    public string descriptionTxt;
    [TextArea]
    public List<string> packageList;
    [TextArea]
    public string toolDetailDescription;
}

