using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CartList", menuName = "ScriptableObjects/CartHolder", order = 1)]
public class CartHolder : ScriptableObject
{
    public int Id;
    public int Quantity;
}
