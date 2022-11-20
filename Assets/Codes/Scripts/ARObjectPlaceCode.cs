using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

using H.Input;

using System;
using System.Collections;
using System.Collections.Generic;

public class ARObjectPlaceCode : MonoBehaviour
{
    [Header("Header")]
    [Tooltip("This is to reference the 3D object")]
    public GameObject toolsPrefab;

    [Tooltip("The ghost object for the 3D object, reference where it would be placed")]
    public GameObject placementIndicatorPrefab;

    [Tooltip("This section is to reference the ARRaycastManager")]
    public ARRaycastManager aRRaycastManager;

    private GameObject toolsOnScene;

    private Pose placementPos;
    private bool placementPosIsValid = false;

    private InputCatcher _inputCatcher;

    private void Awake()
    {
        _inputCatcher = GetComponent<InputCatcher>();    
    }

    private void TryGetTouchPosition()
    {
        if (_inputCatcher.place != Vector2.zero)
        {

        }

    }

}
