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
        homeButton.onClick.AddListener(() => AppManager.Instance.GoToPage(PageName.MainMenu));
        cartButotn.onClick.AddListener(() => AppManager.Instance.GoToPage(PageName.CartPage));
        gameButton.onClick.AddListener(() => AppManager.Instance.GoToPage(PageName.Gamification));
    }

    private void OnDisable()
    {
        homeButton.onClick.RemoveAllListeners();
        cartButotn.onClick.RemoveAllListeners();
        gameButton.onClick.RemoveAllListeners();
    }
}
