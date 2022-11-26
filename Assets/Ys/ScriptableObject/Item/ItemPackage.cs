using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Package")]
public class ItemPackage : ScriptableObject
{
    [TextArea]
    public string packageContents;
    public string packagePrice;

}


