using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectFeature : MonoBehaviour
{
    [Header("Script Reference")]
    public ARObjectPlaceCode aRObjectPlaceCode;

    private void OnEnable()
    {
        
    }

    private void Awake()
    {
        if(aRObjectPlaceCode == null)
        {
            Debug.Log("YOU FOR GOT TO REFERNCE THE SCRIPTS!");
        }
    }

    private void Start()
    {
        
    }
}
