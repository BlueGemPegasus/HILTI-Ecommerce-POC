using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FeatureData", menuName = "ScriptableObjects/AR/FeatureData", order = 1)]
public class FeatureSO : ScriptableObject
{
    [TextArea]
    public string dustShieldDescription;

    [TextArea]
    public string insertToolUnlockDescription;

    [TextArea]
    public string controlSwtichDescription;

    [TextArea]
    public string gripDescription;

    [TextArea]
    public string functionSelectorDescription;

    [TextArea]
    public string sideHandleDescription;

    [TextArea]
    public string lightButtonDescription;

    [TextArea]
    public string batteryButtonDescription;

    public Sprite[] InsertToolUnlockingAddOnImage;

    [TextArea]
    public string[] InsertToolUnlockingAddOnDescription;

    public Sprite[] BatteryAddOnImage;

    [TextArea]
    public string[] BatteryAddOnDescription;

    public Sprite[] DustShieldAddOnImage;

    [TextArea]
    public string[] DustShieldAddOnDescription;
}
