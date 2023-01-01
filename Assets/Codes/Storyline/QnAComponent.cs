using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QnAComponent : MonoBehaviour
{
    public GameObject[] heartshape;
    private int health = 3;
    public TextMeshProUGUI levelText;
    public QuizComponent quizComponent;
    public QuizSituationStoryComponent quizSituationStoryComponent;
}
