using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SuggestionSO : ScriptableObject
{
    public int SuggestionNumber;
    public int suggestedItemId;
    public List<suggestionItemDetail> tools;
    public List<suggestionItemDetail> inserts;
    public List<suggestionItemDetail> batteries;
    public List<int> similarToolId;
}

