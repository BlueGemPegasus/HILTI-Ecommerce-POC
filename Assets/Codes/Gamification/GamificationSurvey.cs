using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GamificationSurvey : MonoBehaviour
{
    public GamificationManager manager;

    public GameObject startPanel;
    public GameObject questionPanel;
    public GameObject surveyOverlayPanel;

    private int currentQuestion;

    //startPanel
    public TextMeshProUGUI startingText;
    public Button GoToQuestionBtn;

    //question panel
    public TextMeshProUGUI questionText;
    public List<Button> ansBtn;
    public List<TextMeshProUGUI> ansText;
    public List<GameObject> ansGO;
    public Button surveyOverlayClose;

    public int suggestion = 1;


    private void OnEnable()
    {
        SetUpSurvey();
        currentQuestion = 0;
        ansBtn[0].onClick.AddListener(() => AnsQuestion(1));
        ansBtn[1].onClick.AddListener(() => AnsQuestion(2));
        ansBtn[2].onClick.AddListener(() => AnsQuestion(3));
        ansBtn[3].onClick.AddListener(() => AnsQuestion(4));

        GoToQuestionBtn.onClick.AddListener(StartQuestion);
        surveyOverlayClose.onClick.AddListener(CloseSurveyOverlay);
    }

    private void OnDisable()
    {
        //loop thru all ans button and assign listner and number of answer
        foreach (Button question in ansBtn)
        {
            question.onClick.RemoveAllListeners();
        }
        GoToQuestionBtn.onClick.RemoveAllListeners();
        surveyOverlayClose.onClick.RemoveAllListeners();
    }

    private void SetUpSurvey()
    {
        startPanel.SetActive(true);
        questionPanel.SetActive(false);
        startingText.text = $"Welcome to \n{manager.currentShopInfo.shopName}! \nFind ur best H+ Tools!";
    }

    private void StartQuestion()
    {
        if(manager == null ) return;
        if(manager.currentShopInfo == null) return;
        if(manager.currentShopInfo.questionList == null)
        {
            //call manager open suggestion panel with default item/info
            manager.OpenSuggestion(suggestion);
            return;
        }
        //setup 1st question
        SetupQuestion(true);
        startPanel.SetActive(false);
        questionPanel.SetActive(true);
    }

    private void SetupQuestion(bool isNext)
    {
        if (isNext) currentQuestion++;
        else currentQuestion--;

        Question q;
        q = manager.currentShopInfo.questionList.FirstOrDefault(x => x.number == currentQuestion);
        if(q == null)
        {
            //call manager to open suggestion panel 
            manager.OpenSuggestion(suggestion);
        }
        else
        {
            questionText.text = q.question;
            int i = 0;
            
            foreach(GameObject obj in ansGO)
            {
                obj.SetActive(false);
            }
            foreach(string a in q.ansList)
            {
                ansGO[i].SetActive(true);
                ansText[i].text = a;
                i++;
            }
        }
    }

    private void AnsQuestion(int ansBtnNum)
    {
        if(currentQuestion == 1)
        {
            suggestion = ansBtnNum;
        }
        else if(currentQuestion == 4)
        {
            //show survey reward
            surveyOverlayPanel.SetActive(true);
        }
        //go to next question when answered
        SetupQuestion(true);
    }

    private void CloseSurveyOverlay()
    {
        if(surveyOverlayPanel.activeSelf) surveyOverlayPanel.SetActive(false);
    }
}
