using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARObjectComponent : MonoBehaviour
{
    [Header("Reference all object")]
    [Tooltip("Canvas Reference Component")]
    public Canvas canvas;
    [Tooltip("Animator Reference Component")]
    public Animator animator;
    [Tooltip("Light GameObject References")]
    public GameObject spotLight;
    [Tooltip("Refrence for the Directional Light")]
    public GameObject directionalLight;
    [Tooltip("Overview GameObject References")]
    public GameObject overview;
    [Tooltip("Feature Panel References")]
    public GameObject featurePanel;
    [Tooltip("Description Panel References")]
    public GameObject descriptionPanel;
    [Tooltip("Description Text Reference")]
    public TextMeshProUGUI descriptionText;

    private void OnEnable()
    {
        canvas.GetComponent<Canvas>().worldCamera = Camera.main;
    }



}
