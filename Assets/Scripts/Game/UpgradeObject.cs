using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeObject : MonoBehaviour
{
    public GlobalStatus gs;

    public string UpgradeName = "";
    public long BasePrice = 0;
    public float PriceMultiplier = 0;
    public float UpgradeImpact = 0;
    public string UpgradeType = "";
    public int MaxUpgrade = 20;

    public GameObject UpgradeNameText;
    public GameObject UpgradePriceText;
    public Button UpgradeButton;

    private long currentPrice;
    private float currentImpact = 0;
    private int upgradeCounter = 0;
    void Start() {
        UpgradeNameText.GetComponent<Text>().text = UpgradeName;
        currentPrice = BasePrice;

        UpgradePriceText.GetComponent<Text>().text = ""+currentPrice;
        UpgradeButton.interactable = false;
    }

    void Update() {
        if (IsUpgradeAllowed()) {
            UpgradeButton.interactable = true;
        } else {
            UpgradeButton.interactable = false;
        }
    }

    public void PurchaseUpgrade()
    {
        if(IsUpgradeAllowed()) {
            gs.UpdateBalance(currentPrice, false);
            currentPrice = (long)((float)(currentPrice)*PriceMultiplier);
            currentImpact += UpgradeImpact;
            UpgradePriceText.GetComponent<Text>().text = ""+currentPrice;
            upgradeCounter++;

            DoUpgrade();
        }
    }

    public float GetImpact() {
        return currentImpact;
    }

    public bool IsUpgradeAllowed()
    {
        return (gs.GetBalance() >= currentPrice && upgradeCounter < MaxUpgrade);
    }

    void DoUpgrade() {
        switch (UpgradeType) {
            case "ManualOrderRate":
                gs.CalculateManualOrderRate(currentImpact);
                break;
            case "WorkerCount":
                gs.AddWorker(1);
                gs.CalculateAutoOrderRate();
                break;
            case "WorkerEfficiency":
                gs.AddWorkerEfficiency(currentImpact);
                gs.CalculateAutoOrderRate();
                break;
            case "RevenueMultiplier": 
                gs.AddRevenueMultiplier(currentImpact);
                break;
            default:
                break;
        }
    }
}
