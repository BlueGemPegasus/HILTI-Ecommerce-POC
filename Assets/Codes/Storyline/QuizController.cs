using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    [Tooltip("The panel that edits")]
    public QuizSituationStoryComponent situationComponent;
    public QuizComponent quizComponent;
    public QuizResultStoryComponent quizResult;

    [Header("Model or Database")]
    public List<SituationScriptableObject> situationSO;
    public ResultScriptableObject resultSO;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public int id;
    public int heart;

    //When this page enable, getID and according ID display the
    //correct text and images for situation, quiz and result components
    private void OnEnable()
    {
        situationComponent.situationImage.sprite = situationSO[id].spriteImage;
        situationComponent.situationText.text = situationSO[id].situationText;
        situationComponent.gameObject.SetActive(true);
        situationComponent.startSituationButton.onClick.AddListener(StartQuiz);
    }
    private void StartQuiz()
    {
        situationComponent.gameObject.SetActive(false);
        quizComponent.questionText.text = situationSO[id].questionText[0];
        quizComponent.answerText1.text = situationSO[id].answerText1[0];
        quizComponent.answerText2.text = situationSO[id].answerText2[0];
        quizComponent.answerText3.text = situationSO[id].answerText3[0];
        quizComponent.QuizAvatar.sprite = situationSO[id].avatarImage[0];
        quizComponent.gameObject.SetActive(true);
    }

}
