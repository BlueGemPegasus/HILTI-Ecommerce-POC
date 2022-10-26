using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="item")]
public class Item : ScriptableObject
{
    public Sprite itemSprite;

    public string nameTxt;
    public string priceTxt;
    public string descriptionTxt;
    public string packageName;
    public List<string> packageList;
    [TextArea]
    public string toolDetailDescription;
}

