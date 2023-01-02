using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public enum PageName
{
    MainMenu = 1,
    ItemDetail = 2,
    Gamification = 3,
    ARPage = 4,
    CartPage = 5,
    QuizGamification = 6,
    Skyscrapper = 7
       
}

public class AppManager : MonoBehaviour
{
    public static AppManager Instance { get; private set; }

    //all page 
    public List<GameObject> AllPage;



    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public void GoToPage(PageName newPage, Action callback = null)
    {
        GameObject obj = null;
        foreach(GameObject page in AllPage)
        {
            if (page.activeSelf) page.SetActive(false);
        }
        
        switch (newPage)
        {
            case PageName.ItemDetail:
                obj = AllPage.FirstOrDefault(x=>x.gameObject.name == "ItemDetailPage");
                break;
            case PageName.MainMenu:
                obj = AllPage.FirstOrDefault(x => x.gameObject.name == "MainPage");
                break;
            case PageName.Gamification:
                obj = AllPage.FirstOrDefault(x => x.gameObject.name == "GamificationPage");
                break;
            case PageName.ARPage:
                obj = AllPage.FirstOrDefault(x => x.gameObject.name == "ItemARPage");
                break;
            case PageName.CartPage:
                obj = AllPage.FirstOrDefault(x => x.gameObject.name == "CartPage");
                break;
            case PageName.QuizGamification:
                obj = AllPage.FirstOrDefault(x => x.gameObject.name == "QuizGamificationPage");
                break;
            case PageName.Skyscrapper:
                obj = AllPage.FirstOrDefault(x => x.gameObject.name == "SkyscraperGamePage");
                break;
        }

        if (obj != null)
        {
            obj.SetActive(true);
            callback?.Invoke();
        }
    }

    


}
