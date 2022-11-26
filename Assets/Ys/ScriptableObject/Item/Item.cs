using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="item")]
public class Item : ScriptableObject
{
    public int itemId;
    public Sprite itemSprite;

    public string nameTxt;
    public string descriptionTxt;
    public List<ItemPackage> packageList;
    [TextArea]
    public string toolDetailDescription;
}

