using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FooterButtonComponent : MonoBehaviour
{
    public Button homeButton;
    public Button cartButotn;
    public Button gameButton;

    public Action onClickHome;
    public Action onClickCart;
    public Action onClickGame;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
