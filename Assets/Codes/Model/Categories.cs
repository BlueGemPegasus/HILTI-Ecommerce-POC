using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "category")]
public class Categories : ScriptableObject
{
    public int Id;
    public string categoryTxt;
    public int[] itemId;
}
