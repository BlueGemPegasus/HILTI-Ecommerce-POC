using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class GamificationManager : MonoBehaviour
{
    public GameObject buildingPanel;
    public GameObject surveyPanel;
    public GameObject suggestionPanel;

    public GameObject shopOverlay;

    //button
    public Button construction;
    public Button hardware;
    public Button renovation;
    public Button freelance;
    public Button enterShopBtn;

    public Button closeOverlay;


    public TextMeshProUGUI shopName;
    public TextMeshProUGUI shopDescription;

    //store building info 
    private BuildingInfo currentShop;
    public BuildingInfo currentShopInfo { get { return currentShop; } }
    public List<BuildingInfo> buildingInfo;

    //store suggestion to show
    private int suggestion;
    public int currentSuggestion { get { return suggestion; } }

    [Header("Survey Background")]
    public Sprite RenovationBG;
    public Sprite FreelanceBG;

    private void Update()
    {
        Debug.Log("suggestion"+suggestion);
        Debug.Log("get method"+currentSuggestion);
    }


    private Dictionary<ShopType, string> buildings = new Dictionary<ShopType, string>() 
    {
        {ShopType.Construction,"Construction Shop" },
        {ShopType.Hardware,"Hardware Accessories" },
        {ShopType.Renovation,"Renovation Store" },
        {ShopType.Freelance,"Freenlance Store" }
    };

    enum GamiPanel
    {
        building,
        survey,
        suggestion
    }

    public enum ShopType
    {
        Construction,
        Hardware,
        Renovation,
        Freelance
    }

    private void OnEnable()
    {
        //set to default panel everytime open gamification
        SwitchGamiSceen(GamiPanel.building);
        construction.onClick.AddListener(()=>ShopInfoBtn(ShopType.Construction));
        hardware.onClick.AddListener(()=>ShopInfoBtn(ShopType.Hardware));
        renovation.onClick.AddListener(()=>ShopInfoBtn(ShopType.Renovation));
        freelance.onClick.AddListener(()=>ShopInfoBtn(ShopType.Freelance));
        closeOverlay.onClick.AddListener(CloseOverlay);
        enterShopBtn.onClick.AddListener(OpenShop);
    }

    private void OnDisable()
    {
        construction.onClick.RemoveListener(() => ShopInfoBtn(ShopType.Construction));
        hardware.onClick.RemoveListener(() => ShopInfoBtn(ShopType.Hardware));
        renovation.onClick.RemoveListener(() => ShopInfoBtn(ShopType.Renovation));
        freelance.onClick.RemoveListener(() => ShopInfoBtn(ShopType.Freelance));
        closeOverlay.onClick.RemoveListener(CloseOverlay);
        enterShopBtn.onClick.RemoveListener(OpenShop);
    }

    private void ShopInfoBtn(ShopType shop)
    {
        shopOverlay.SetActive(true);
        if(shop == ShopType.Renovation || shop == ShopType.Freelance)
            enterShopBtn.interactable = true;
        else
            enterShopBtn.interactable = false;

        currentShop = buildingInfo.FirstOrDefault(x=>x.shopName == buildings[shop]);
        if (currentShop == null) return;
        shopName.text = currentShop.shopName;
        shopDescription.text = currentShop.description;
    }

    private void OpenShop()
    {
        switch (currentShop.shopName)
        {
            case "Renovation Store":
                surveyPanel.GetComponent<Image>().sprite = RenovationBG;
                break;
            case "Freenlance Store":
                surveyPanel.GetComponent<Image>().sprite = FreelanceBG;
                break;
        }
        
        SwitchGamiSceen(GamiPanel.survey);
    }

    private void CloseOverlay()
    {
        shopOverlay.SetActive(false);
    }


    private void SwitchGamiSceen(GamiPanel newPanel)
    {
        buildingPanel.SetActive(false);
        surveyPanel.SetActive(false);
        suggestionPanel.SetActive(false);

        switch (newPanel)
        {
            case GamiPanel.building:
                buildingPanel.SetActive(true);
                break;
            case GamiPanel.survey:
                surveyPanel.SetActive(true);
                break;
            case GamiPanel.suggestion:
                suggestionPanel.SetActive(true);
                break;
        }
    }

    public void OpenSuggestion(int suggestion)
    {
        this.suggestion = suggestion;
        SwitchGamiSceen(GamiPanel.suggestion);
    }

}
