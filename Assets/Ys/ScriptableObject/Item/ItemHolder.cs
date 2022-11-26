using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemHolder")]
public class ItemHolder : ScriptableObject
{
    public List<Item> Items;
}
