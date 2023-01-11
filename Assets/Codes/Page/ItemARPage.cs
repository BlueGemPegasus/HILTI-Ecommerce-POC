using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemARPage : MonoBehaviour
{
    private int itemId;
    public int currentId { get { return itemId; } }

    public void ReturnMainMenu()
    {
        AppManager.Instance.GoToPage(PageName.MainMenu);
    }
}
