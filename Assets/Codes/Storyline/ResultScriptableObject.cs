using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "resultSO", menuName = "ScriptableObjects/gamification/result", order = 3)]

public class ResultScriptableObject : ScriptableObject
{

    [TextArea]
    public string [] resultText;
    public Sprite[] avatarImage;
}
   
