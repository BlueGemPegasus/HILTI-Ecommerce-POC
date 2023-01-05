using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class GamificationController : MonoBehaviour
{
    [Tooltip("Scriptable Object to extract data from.")]
    public StoryScriptableObject storySO;
    [Tooltip("The panel that edits")]
    public StoryComponent component;
    public GameMapComponent component2;

    [Header("Page Reference")]
    public GameObject storyLine;
    public GameObject gameMap;
    public GameObject quizPage;

    [Header("Condition Checker")]
    public int[] statusOfQuiz;

    public Sprite winButton;

    public QuizController quizController;

    int counter = 0;

    public void OnPressNextButton()
    {
        if (counter == 0)
        {
            component.nextButtonText.text = "NEXT"; 
            component.backButton.gameObject.SetActive(true);
        }
        if (counter == storySO.storyText.Length - 1)
        {
            storyLine.SetActive(false);
            gameMap.SetActive(true);
            return;
        }
        counter += 1;
        component.text.text = storySO.storyText[counter];
        component.avatarImage.sprite = storySO.spriteImage[counter];
    }
    public void OnPressBackButton()
    {
        if (counter == 1)
        {
            component.backButton.gameObject.SetActive(false);
        }
        counter -= 1;
        component.text.text = storySO.storyText[counter];
        component.avatarImage.sprite = storySO.spriteImage[counter];
    }
    public void onPressStartFixButton()
    {
        component2.mapPanel.SetActive(false);
        component2.buttonPanel.SetActive(true);
    }

    private void RegisterButton()
    {
        for (int buttonArrayCount = 0; buttonArrayCount < component2.gameButton.Length; buttonArrayCount++)
        {
            if (component2.gameButton[buttonArrayCount] != null)
                GetID(component2.gameButton, buttonArrayCount);
        }
    }
    private void UnregisterButton()
    {
        foreach (Button ovButton in component2.gameButton)
        {
            ovButton.onClick.RemoveAllListeners();
        }
    }

    private void GetID(Button [] buttons,int array)
    {
        buttons[array].onClick.AddListener(() =>
        {
            LevelButtonID ID = buttons[array].GetComponent<LevelButtonID>();
            Debug.Log("ID = " + ID.levelID.ToString());
            quizController.id = ID.levelID;
            gameMap.SetActive(false);
            quizPage.SetActive(true);
        });
        
    }

    private void OnEnable()
    {
        component.backButton.gameObject.SetActive(false);
        component.nextButtonText.text = "START";
        
        if(statusOfQuiz.All(x => x != 0))
        {
            storyLine.SetActive(false);
            gameMap.SetActive(false);
            quizPage.SetActive(true);
        }
        

        RegisterButton();
    }

    private void OnDisable()
    {
        UnregisterButton();
    }
}
