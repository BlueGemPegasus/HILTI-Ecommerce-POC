using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillWorldSpaceCanvas : MonoBehaviour
{
    Canvas _canvas;

    private void OnEnable()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = Camera.main;

    }
}
