//this are libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "storySO", menuName = "ScriptableObjects/gamification/story", order = 1)]

public class StoryScriptableObject : ScriptableObject
{
    [TextArea]
    public string [] storyText;
    public Sprite[] spriteImage;

   
}
