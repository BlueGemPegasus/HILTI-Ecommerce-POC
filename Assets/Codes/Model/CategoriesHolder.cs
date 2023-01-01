using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CategoryHolder", menuName = "ScriptableObjects/Category/CategoryHolder", order = 1)]
public class CategoriesHolder : ScriptableObject
{
    public List<Categories> Categories;
}
