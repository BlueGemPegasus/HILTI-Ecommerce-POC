using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrillFeatureMethod : MonoBehaviour
{
    [Header("Model or Database")]
    public FeatureSO featureData;
    public OverviewSO overviewData;

    [Header("Reference for Display")]
    [Tooltip("The whole panel that house the description and addon component")]
    public GameObject descriptionPanel;
    [Tooltip("The text of feature and overview.")]
    public TextMeshProUGUI descriptionText;
    [Tooltip("The all feature button component reference")]
    public FeatureComponent featureComponent;
    [Tooltip("The place where the Add On component card to spawn in.")]
    public RectTransform AddOnContentPlace;
    [Tooltip("The all overview button component reference")]
    public OverviewComponent overviewComponent;

    [Header("The item Prefab to Spawn")]
    [Tooltip("This item prefab is spawn for the feature view about Item Add On.")]
    public GameObject AddOnComponentPrefab;

    private void OnEnable()
    {
        EnableFeatureButton();
        EnableOverviewButton();
    }

    private void OnDisable()
    {
        DisableFeatureButton();
        DisableOverviewButton();
    }

    #region FeatureButtonMethod
    private void DustShieldButtonFunction()
    {
        Clear();
        for (int i = 0; i < featureData.InsertToolUnlockingAddOnImage.Length; i++)
        {
            AddOnComponentCard component = Instantiate(AddOnComponentPrefab, AddOnContentPlace).GetComponent<AddOnComponentCard>();
            component.image.sprite = featureData.DustShieldAddOnImage[i];
            component.text.text = featureData.DustShieldAddOnDescription[i];
        }
        descriptionText.text = featureData.dustShieldDescription;
        descriptionPanel.SetActive(true);
    }

    private void InsertToolUnlockButtonFunction()
    {
        Clear();
        for (int i = 0; i < featureData.InsertToolUnlockingAddOnImage.Length; i++)
        {
            AddOnComponentCard component = Instantiate(AddOnComponentPrefab, AddOnContentPlace).GetComponent<AddOnComponentCard>();
            component.image.sprite = featureData.BatteryAddOnImage[i];
            component.text.text = featureData.BatteryAddOnDescription[i];
        }
        descriptionText.text = featureData.insertToolUnlockDescription;
        descriptionPanel.SetActive(true);
    }

    private void ControlSwtichButtonFunction()
    {
        Clear();
        descriptionText.text = featureData.controlSwtichDescription;
        descriptionPanel.SetActive(true);
    }

    private void GripButtonFunction()
    {
        Clear();
        descriptionText.text = featureData.gripDescription;
        descriptionPanel.SetActive(true);
    }

    private void FunctionSelectorButtonFunction()
    {
        Clear();
        descriptionText.text = featureData.functionSelectorDescription;
        descriptionPanel.SetActive(true);
    }

    private void SideHandleButtonFunction()
    {
        Clear();
        descriptionText.text = featureData.sideHandleDescription;
        descriptionPanel.SetActive(true);
    }

    private void LightButtonFunction()
    {
        Clear();
        descriptionText.text = featureData.lightButtonDescription;
        descriptionPanel.SetActive(true);
    }

    private void BatteryButtonFunction()
    {
        Clear();
        for (int i = 0; i < featureData.InsertToolUnlockingAddOnImage.Length; i++)
        {
            AddOnComponentCard component = Instantiate(AddOnComponentPrefab, AddOnContentPlace).GetComponent<AddOnComponentCard>();
            component.image.sprite = featureData.InsertToolUnlockingAddOnImage[i];
            component.text.text = featureData.InsertToolUnlockingAddOnDescription[i];
        }
        descriptionText.text = featureData.batteryButtonDescription;
        descriptionPanel.SetActive(true);

    }

    private void Clear()
    {
        foreach (RectTransform children in AddOnContentPlace)
        {
            Destroy(children.gameObject);
        }
        descriptionPanel.SetActive(false);
        //AllFeatureButtonEnable();
    }

    private void AllFeatureButtonEnable()
    {
        featureComponent.dustShieldButton.enabled = true;
        featureComponent.insertToolUnlockButton.enabled = true;
        featureComponent.controlSwitchButto.enabled = true;
        featureComponent.gripButton.enabled = true;
        featureComponent.functionSelectorButton.enabled = true;
        featureComponent.sideHandleButton.enabled = true;
        featureComponent.lightButton.enabled = true;
        featureComponent.batteryButton.enabled = true;
    }

    private void EnableFeatureButton()
    {
        featureComponent.dustShieldButton.onClick.AddListener(DustShieldButtonFunction);
        featureComponent.insertToolUnlockButton.onClick.AddListener(InsertToolUnlockButtonFunction);
        featureComponent.controlSwitchButto.onClick.AddListener(ControlSwtichButtonFunction);
        featureComponent.gripButton.onClick.AddListener(GripButtonFunction);
        featureComponent.functionSelectorButton.onClick.AddListener(FunctionSelectorButtonFunction);
        featureComponent.sideHandleButton.onClick.AddListener(SideHandleButtonFunction);
        featureComponent.lightButton.onClick.AddListener(LightButtonFunction);
        featureComponent.batteryButton.onClick.AddListener(BatteryButtonFunction);
    }

    private void DisableFeatureButton()
    {
        featureComponent.dustShieldButton.onClick.RemoveAllListeners();
        featureComponent.insertToolUnlockButton.onClick.RemoveAllListeners();
        featureComponent.controlSwitchButto.onClick.RemoveAllListeners();
        featureComponent.gripButton.onClick.RemoveAllListeners();
        featureComponent.functionSelectorButton.onClick.RemoveAllListeners();
        featureComponent.sideHandleButton.onClick.RemoveAllListeners();
        featureComponent.lightButton.onClick.RemoveAllListeners();
        featureComponent.batteryButton.onClick.RemoveAllListeners();
    }
    #endregion

    #region OverviewButtonMethod
    private void EnableOverviewButton()
    {
        for (int buttonArrayCount = 0; buttonArrayCount < overviewComponent.overviewButtons.Length; buttonArrayCount++)
        {
            if (overviewComponent.overviewButtons[buttonArrayCount] != null)
                CallOverviewFeatureAccordingToArray(overviewComponent.overviewButtons[buttonArrayCount], buttonArrayCount);
        }
    }

    private void DisableOverviewButton()
    {
        foreach (Button ovButton in overviewComponent.overviewButtons)
        {
            ovButton.onClick.RemoveAllListeners();
        }
    }

    private void CallOverviewFeatureAccordingToArray(Button button, int arrayNumber)
    {
        Clear();
        button.onClick.AddListener(() =>
        {
            descriptionText.text = overviewData.overviewArray[arrayNumber];
            descriptionPanel.SetActive(true);
        });
        
    }
    #endregion
}
