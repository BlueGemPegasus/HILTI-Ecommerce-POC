using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Category", menuName = "ScriptableObjects/category", order = 1)]
public class Categories : ScriptableObject
{
    public int Id;
    public string categoryTxt;
    public int[] itemId;
}
