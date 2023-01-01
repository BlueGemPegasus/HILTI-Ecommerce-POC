using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CartItem", menuName = "ScriptableObjects/Cart/CartItem", order = 2)]
public class CartsItem : ScriptableObject
{
    public int id;
    public int quantity;
    public float price;
}
