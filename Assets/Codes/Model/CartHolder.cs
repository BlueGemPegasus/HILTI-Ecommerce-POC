using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CartList", menuName = "ScriptableObjects/Cart/CartHolder", order = 1)]
public class CartHolder : ScriptableObject
{
    public List<CartsItem> CartItems;
}
