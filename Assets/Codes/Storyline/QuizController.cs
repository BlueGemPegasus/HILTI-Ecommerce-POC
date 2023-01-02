using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizController : MonoBehaviour
{
    public int id;

    [Header("Upper Controller")]
    public GamificationController gamificationController;

    [Header("The panel that need to be edited")]
    public QuizSituationStoryComponent situationComponent;
    public QuizComponent quizComponent;
    public QuizResultStoryComponent quizResult;

    public GameObject heartPanel;
    public GameObject levelPanel;

    [Header("Model or Database")]
    public List<SituationScriptableObject> situationSO;
    public ResultScriptableObject resultSO;

    public int correctAnswer;
    public Button[] answerButtons;

    public TextMeshProUGUI levelText;

    public int lifeUsed;
    public GameObject[] hearts;

    [SerializeField] private int quizCount;

    private void OnEnable()
    {
        if (gamificationController.statusOfQuiz.All(x => x != 0))
        {
            Debug.Log("All Quiz has now Finished!");
            heartPanel.SetActive(false);
            levelPanel.SetActive(false);
            quizResult.resultText.text = resultSO.resultText[1];
            quizResult.avatar.sprite = resultSO.avatarImage[1];
            quizResult.restartButton.onClick.RemoveAllListeners();
            quizResult.restartButton.onClick.AddListener(() => AppManager.Instance.GoToPage(PageName.Skyscrapper));
            return;
        }

        levelText.text = situationSO[id].LevelName;

        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
        quizResult.gameObject.SetActive(false);
        quizComponent.gameObject.SetActive(false);
        lifeUsed = 0;
        quizCount = 0;
        RemoveButtonFunction();
        situationComponent.situationImage.sprite = situationSO[id].spriteImage;
        situationComponent.situationText.text = situationSO[id].situationText;
        situationComponent.gameObject.SetActive(true);
        situationComponent.startSituationButton.onClick.AddListener(StartQuiz);
        quizResult.exitButton.onClick.AddListener(ExitButtonOnClick);
    }

    private void OnDisable()
    {
        quizResult.exitButton.onClick.RemoveAllListeners();
    }

    private void StartQuiz()
    {
        situationComponent.gameObject.SetActive(false);
        SetUpQuestion();
        quizComponent.gameObject.SetActive(true);
    }

    private void AssignButtonFunction()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            if (i != correctAnswer - 1)
                answerButtons[i].onClick.AddListener(WrongAnswerButton);
            else
                answerButtons[i].onClick.AddListener(CorrectAnswerButton);
        }
    }

    private void RemoveButtonFunction()
    {
        foreach (Button button in answerButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }

    private void CorrectAnswerButton()
    {
        quizCount += 1;
        SetUpQuestion();
        Debug.Log("CorrectAnswer Clicked!");
    }

    private void WrongAnswerButton()
    {
        lifeUsed += 1;
        for (int i = 0; i < lifeUsed; i ++)
        {
            hearts[i].SetActive(false);
        }

        if (lifeUsed == 3)
        {
            quizComponent.gameObject.SetActive(false);
            quizResult.resultText.text = resultSO.resultText[0];
            quizResult.avatar.sprite = resultSO.avatarImage[0];
            quizResult.nextRestartButtonText.text = "RESTART";
            quizResult.restartButton.onClick.RemoveAllListeners();
            quizResult.restartButton.onClick.AddListener(AssignRestartButton);
            quizResult.exitButton.gameObject.SetActive(true);
            quizResult.gameObject.SetActive(true);
        }
        Debug.Log("WrongAnswer Clicked!");
    }

    private void SetUpQuestion()
    {
        if (quizCount >= situationSO[id].questionText.Length - 1)
        {
            quizComponent.gameObject.SetActive(false);
            quizResult.resultText.text = situationSO[id].questionText[quizCount];
            quizResult.avatar.sprite = situationSO[id].avatarImage[quizCount];
            quizResult.nextRestartButtonText.text = "NEXT";
            quizResult.restartButton.onClick.RemoveAllListeners();
            quizResult.restartButton.onClick.AddListener(AssignFinishButton);
            quizResult.exitButton.gameObject.SetActive(false);
            quizResult.gameObject.SetActive(true);
        }
        else
        {
            quizComponent.questionText.text = situationSO[id].questionText[quizCount];
            if (situationSO[id].questionImage.Length != 0)
            {
                if (situationSO[id].questionImage[quizCount] != null)
                {
                    quizComponent.questionImage.sprite = situationSO[id].questionImage[quizCount];
                    quizComponent.questionImage.gameObject.SetActive(true);
                }
                else
                {
                    quizComponent.questionImage.gameObject.SetActive(false);
                }
            }
            else
            {
                quizComponent.questionImage.gameObject.SetActive(false);
            }
            quizComponent.answerText1.text = situationSO[id].answerText1[quizCount];
            quizComponent.answerText2.text = situationSO[id].answerText2[quizCount];
            quizComponent.answerText3.text = situationSO[id].answerText3[quizCount];
            quizComponent.QuizAvatar.sprite = situationSO[id].avatarImage[quizCount];
            correctAnswer = situationSO[id].correctAnswer[quizCount];
            RemoveButtonFunction();
            AssignButtonFunction();
        }
    }

    private void ExitButtonOnClick()
    {
        gamificationController.gameMap.SetActive(true);
        gameObject.SetActive(false);
    }

    private void AssignRestartButton()
    {
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
        quizResult.gameObject.SetActive(false);
        quizComponent.gameObject.SetActive(false);
        lifeUsed = 0;
        quizCount = 0;
        RemoveButtonFunction();
        situationComponent.situationImage.sprite = situationSO[id].spriteImage;
        situationComponent.situationText.text = situationSO[id].situationText;
        situationComponent.gameObject.SetActive(true);
        situationComponent.startSituationButton.onClick.AddListener(StartQuiz);
    }

    private void AssignFinishButton()
    {
        gamificationController.statusOfQuiz[id] = 1;
        for (int i = 0; i < gamificationController.statusOfQuiz.Length; i++)
        {
            if (gamificationController.statusOfQuiz[i] != 0)
            {
                gamificationController.component2.gameButton[i].interactable = false;
                gamificationController.component2.gameButton[i].gameObject.GetComponent<Image>().sprite = gamificationController.winButton;
            }
        }

        if (gamificationController.statusOfQuiz.All(x => x != 0))
        {
            Debug.Log("All Quiz has now Finished!");
            heartPanel.SetActive(false);
            levelPanel.SetActive(false);
            quizResult.resultText.text = resultSO.resultText[1];
            quizResult.avatar.sprite = resultSO.avatarImage[1];
            quizResult.restartButton.onClick.RemoveAllListeners();
            quizResult.restartButton.onClick.AddListener(() => { AppManager.Instance.GoToPage(PageName.Skyscrapper); });
        }
        else
        {
            gamificationController.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
