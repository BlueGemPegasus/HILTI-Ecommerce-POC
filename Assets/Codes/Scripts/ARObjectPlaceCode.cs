using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

using System;
using System.Collections;
using System.Collections.Generic;

public class ARObjectPlaceCode : MonoBehaviour
{
    [Header("Header")]
    [Tooltip("This is to reference the 3D object")]
    public GameObject toolsPrefab;

    [Tooltip("This section is to reference the AR Raycast Manager")]
    public ARRaycastManager aRRaycastManager;

    [Tooltip("This is to reference the AR Plane Manager")]  
    public ARPlaneManager aRPlaneManager;

    [Tooltip("Reference for the Start Panel")]
    public GameObject startPanel;

    [Tooltip("Reference for the Start Button")]
    public Button startButton;

    [Tooltip("Reference to the ButtonHolder Panel")]
    public GameObject HolderPanel;

    [Tooltip("Reference for the Place Button")]
    public GameObject placeButton;

    [Tooltip("Reference for the Content GameObejct")]
    public Transform content;

    [Tooltip("Reference for the AR Mangaer")]
    public GameObject aRManager;

    private GameObject placedToolsOnScene;

    private bool _spawn = false;

    private Vector2 touchPosition = default;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void OnEnable()
    {
        placeButton.GetComponent<Button>().onClick.AddListener(PlaceOnClick);
        startButton.onClick.AddListener(OnBegin);
        CleanUp();
        aRManager.SetActive(true);
    }

    private void OnDisable()
    {
        placeButton.GetComponent<Button>().onClick.RemoveAllListeners();
        startButton.onClick.RemoveAllListeners();
        aRManager.SetActive(false);
    }

    private void Update()
    {
        if (startPanel.activeSelf)
            return;

        if (!_spawn)
            SettingUpAR();
            
    }

    private void SettingUpAR()
    {
        // Touch is detected!
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
        }


        if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (placedToolsOnScene == null)
            {
                placedToolsOnScene = Instantiate(toolsPrefab, hitPose.position, hitPose.rotation, content.transform);
            }
            else
            {
                placedToolsOnScene.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            }
        }

        if (placedToolsOnScene != null)
        {
            placeButton.SetActive(true);
        }
    }

    private void PlaceOnClick()
    {
        _spawn = true;
        HolderPanel.SetActive(true);
        placeButton.SetActive(false);
        // Destroy all Plane
        foreach (var plane in aRPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        aRPlaneManager.enabled = false;
        aRRaycastManager.enabled = false;
    }

    private void CleanUp()
    {
        // Reset UI Panels
        startPanel.SetActive(true);
        HolderPanel.SetActive(false);
        placeButton.SetActive(false);

        // Disable PlaneManager First
        aRPlaneManager.enabled = false;
        aRRaycastManager.enabled = false;

        // Reset _spawn check
        _spawn = false;

        // Destroy all of the tools spawned in Content
        foreach (Transform childObject in content)
        {
            Destroy(childObject.gameObject);
        }

    }

    private void OnBegin()
    {
        // Disable Start Panel
        startPanel.SetActive(false);
        // Enable Plane Scan
        aRPlaneManager.enabled = true;
        aRRaycastManager.enabled = true;

    }
}
