using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OverviewData", menuName = "ScriptableObjects/AR/OverviewData", order = 2)]

public class OverviewSO : ScriptableObject
{
    [TextArea]
    public string[] overviewArray;
}
