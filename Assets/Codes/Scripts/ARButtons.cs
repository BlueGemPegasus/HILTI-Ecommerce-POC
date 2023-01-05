using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARButtons : MonoBehaviour
{
    [Header("Reference")]
    [Tooltip("The Feature Button Reference")]
    public Button featureButton;
    [Tooltip("The Overview Button Referencec")]
    public Button overviewButton;
    [Tooltip("Toggle Drill Animation Button Reference")]
    public Button toggleDrillButton;
    [Tooltip("Toggle Battery Animation Button Reference")]
    public Button toggleBatteryButton;
    [Tooltip("Toggle Light Button Reference")]
    public Button toggleLightButton;
    [Tooltip("Add to Cart Button Reference")]
    public Button addToCartButton;
    public string check1;
    public string check2;

    private GameObject toolsOnScene;
    private ARObjectComponent aRObjectComponent;

    private bool DrillAnimation = false;


    private void OnEnable()
    {
        toolsOnScene = GameObject.FindWithTag("ARObject");
        if (toolsOnScene != null)
        {
            aRObjectComponent = toolsOnScene.GetComponent<ARObjectComponent>();
        }

        RegisterButtons();
    }

    private void OnDisable()
    {
        toolsOnScene = null;
        aRObjectComponent.drillingSound.Stop();
        UnregisterButton();
    }

    private void Update()
    {
        // If the tool is missing and somehow the panel had enabled
        // Make it cancel
        if (toolsOnScene == null)
            return;

    }

    private void RegisterButtons()
    {
        featureButton.onClick.AddListener(FeatureButtonOnClick);
        overviewButton.onClick.AddListener(OverviewButtonOnClick);
        toggleDrillButton.onClick.AddListener(ToggleDrillButtonOnClick);
        toggleBatteryButton.onClick.AddListener(ToggleBatteryButtonOnClick);
        toggleLightButton.onClick.AddListener(ToggleLightButtonOnClick);
        addToCartButton.onClick.AddListener(AddToCartButtonOnClick);
    }

    private void UnregisterButton()
    {
        featureButton.onClick.RemoveAllListeners();
        overviewButton.onClick.RemoveAllListeners();
        toggleDrillButton.onClick.RemoveAllListeners();
        toggleBatteryButton.onClick.RemoveAllListeners();
        toggleLightButton.onClick.RemoveAllListeners();
        addToCartButton.onClick.RemoveAllListeners();
    }

    private void SetInactiveEverything()
    {
        aRObjectComponent.overview.SetActive(false);
        aRObjectComponent.featurePanel.SetActive(false);
        aRObjectComponent.descriptionPanel.SetActive(false);
    }

    private void FeatureButtonOnClick()
    {
        SetInactiveEverything();
        aRObjectComponent.featurePanel.SetActive(true);
        aRObjectComponent.descriptionText.text = check1;
        aRObjectComponent.descriptionPanel.SetActive(true);
    }

    private void OverviewButtonOnClick()
    {
        SetInactiveEverything();
        aRObjectComponent.overview.SetActive(true);
        aRObjectComponent.descriptionText.text = check2;
        aRObjectComponent.descriptionPanel.SetActive(true);
    }

    private void ToggleDrillButtonOnClick()
    {
        if(DrillAnimation == false)
        {
            SetInactiveEverything();
            DrillAnimation = true;
            aRObjectComponent.animator.SetBool("OnDrill", DrillAnimation);
            aRObjectComponent.drillingSound.Play();
        }
        else
        {
            DrillAnimation = false;
            aRObjectComponent.animator.SetBool("OnDrill", DrillAnimation);
            aRObjectComponent.drillingSound.Stop();
        }    
    }

    private void ToggleBatteryButtonOnClick()
    {
        SetInactiveEverything();
        DrillAnimation = false;
        aRObjectComponent.animator.SetBool("OnDrill", DrillAnimation);
        aRObjectComponent.drillingSound.Stop();
        aRObjectComponent.animator.SetTrigger("RemoveBattery");
    }

    private void ToggleLightButtonOnClick()
    {
        if (aRObjectComponent.spotLight.activeSelf)
        {
            aRObjectComponent.spotLight.SetActive(false);
            aRObjectComponent.directionalLight.SetActive(true);
        }
        else
        {
            aRObjectComponent.spotLight.SetActive(true);
            aRObjectComponent.directionalLight.SetActive(false);
        }
    }

    private void AddToCartButtonOnClick()
    {

    }
}
