using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrillFeatureMethod : MonoBehaviour
{
    [TextArea]
    public string dustShieldDescription;

    [TextArea]
    public string insertToolUnlockDescription;

    [TextArea]
    public string controlSwtichDescription;

    [TextArea]
    public string gripDescription;

    [TextArea]
    public string functionSelectorDescription;

    [TextArea]
    public string sideHandleDescription;

    [TextArea]
    public string lightButtonDescription;

    [TextArea]
    public string batteryButtonDescription;

    public GameObject descriptionPanel;

    public TextMeshProUGUI descriptionText;

    public FeatureComponent featureComponent;

    public RectTransform AddOnContentPlace;

    public GameObject AddOnComponentPrefab;

    public Sprite[] InsertToolUnlockingAddOnImage;

    [TextArea]
    public string[] InsertToolUnlockingAddOnDescription;

    public Sprite[] BatteryAddOnImage;

    [TextArea]
    public string[] BatteryAddOnDescription;

    public Sprite[] DustShieldAddOnImage;

    [TextArea]
    public string[] DustShieldAddOnDescription;

    private void OnEnable()
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

    private void OnDisable()
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

    private void DustShieldButtonFunction()
    {
        Clear();
        for (int i = 0; i < InsertToolUnlockingAddOnImage.Length; i++)
        {
            AddOnComponentCard component = Instantiate(AddOnComponentPrefab, AddOnContentPlace).GetComponent<AddOnComponentCard>();
            component.image.sprite = DustShieldAddOnImage[i];
            component.text.text = DustShieldAddOnDescription[i];
        }
        descriptionText.text = dustShieldDescription;
        descriptionPanel.SetActive(true);
    }

    private void InsertToolUnlockButtonFunction()
    {
        Clear();
        for(int i = 0; i < InsertToolUnlockingAddOnImage.Length; i++)
        {
            AddOnComponentCard component = Instantiate(AddOnComponentPrefab, AddOnContentPlace).GetComponent<AddOnComponentCard>();
            component.image.sprite = BatteryAddOnImage[i];
            component.text.text = BatteryAddOnDescription[i];
        }
        descriptionText.text = insertToolUnlockDescription;
        descriptionPanel.SetActive(true);
    }

    private void ControlSwtichButtonFunction()
    {
        Clear();
        descriptionText.text = controlSwtichDescription;
        descriptionPanel.SetActive(true);
    }

    private void GripButtonFunction()
    {
        Clear();
        descriptionText.text = gripDescription;
        descriptionPanel.SetActive(true);
    }

    private void FunctionSelectorButtonFunction()
    {
        Clear();
        descriptionText.text = functionSelectorDescription;
        descriptionPanel.SetActive(true);
    }

    private void SideHandleButtonFunction()
    {
        Clear();
        descriptionText.text = sideHandleDescription;
        descriptionPanel.SetActive(true);
    }

    private void LightButtonFunction()
    {
        Clear();
        descriptionText.text = lightButtonDescription;
        descriptionPanel.SetActive(true);
    }

    private void BatteryButtonFunction()
    {
        Clear();
        for (int i = 0; i < InsertToolUnlockingAddOnImage.Length; i++)
        {
            AddOnComponentCard component = Instantiate(AddOnComponentPrefab, AddOnContentPlace).GetComponent<AddOnComponentCard>();
            component.image.sprite = InsertToolUnlockingAddOnImage[i];
            component.text.text = InsertToolUnlockingAddOnDescription[i];
        }
        descriptionText.text = batteryButtonDescription;
        descriptionPanel.SetActive(true);

    }

    private void Clear()
    {
        foreach(RectTransform children in AddOnContentPlace)
        {
            Destroy(children.gameObject);
        }
        descriptionPanel.SetActive(false);
        AllButtonEnable();
    }

    private void AllButtonEnable()
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

}
