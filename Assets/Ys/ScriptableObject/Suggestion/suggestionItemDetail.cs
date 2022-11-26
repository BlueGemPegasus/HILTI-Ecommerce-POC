using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class suggestionItemDetail : ScriptableObject
{
    public Sprite image;
    public string itemName;
    [TextArea]
    public string des;
}
