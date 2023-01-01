using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "situationSO", menuName ="ScriptableObjects/gamification/situation", order = 2)]

public class SituationScriptableObject : ScriptableObject

{
    //Situation
    [TextArea]
    public string situationTextTitle;
    [TextArea]
    public string situationText;
    public Sprite spriteImage;

    //Question
    [TextArea]
    public string[] questionText;
    public Sprite questionImage;
    [TextArea]
    public string[] answerText1;
    [TextArea]
    public string[] answerText2;
    [TextArea]
    public string[] answerText3;
    public int[] correctAnswer;
 


    //Result
    [TextArea]
    public string passText;
    public Sprite [] avatarImage;

}
