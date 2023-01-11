using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class BuildingInfo : ScriptableObject
{
    public string shopName;
    public string description;
    public List<Question> questionList;
}
