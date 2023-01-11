using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyscraperGamePage : MonoBehaviour
{
    [Header("Page References")]
    public GameObject skyScraperGameStart;
    public GameObject skyScraperGame;

    public Button startButton;

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveAllListeners();
    }

    private void StartGame()
    {
        skyScraperGameStart.SetActive(false);
        skyScraperGame.SetActive(true);
    }

    
}
