using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductObject : MonoBehaviour
{
    public GlobalStatus gs;

    public string ProductName = "";
    public long BaseProductPrice = 0;
    public long BaseUpgradePrice = 0;
    public float UpgradeMultiplier = 1;
    public float UpgradePriceMultiplier = 1;
    public float ProductQuality = 1;

    public GameObject ProductNameText;
    public GameObject CurrentProfitText;
    public GameObject CurrentUpgradeText;
    public Button UpgradeButton;

    private long currentProductPrice;
    private long currentUpgradePrice;
    private float orderRate;
    private bool processOrder = false;

    void Start() {
        UpgradeButton.interactable = false;

        ProductNameText.GetComponent<Text>().text = ProductName;
        CurrentProfitText.GetComponent<Text>().text = ""+currentProductPrice+"/product sold";
        CurrentUpgradeText.GetComponent<Text>().text = ""+currentUpgradePrice;
    }

    public void SetGlobalStatus(GlobalStatus gs) {
        this.gs = gs;
    }

    void Update() {
        float currentBalance = gs.GetBalance();
        if (currentBalance >= currentUpgradePrice) {
            UpgradeButton.interactable = true;
        } else {
            UpgradeButton.interactable = false;
        }
    }
    
    public void Init() {
        currentProductPrice = BaseProductPrice;
        currentUpgradePrice = BaseUpgradePrice;
    }

    public void SetProductName(string productName) {
        ProductName = productName;
    }

    public void SetBaseProductPrice(long productPrice) {
        BaseProductPrice = productPrice;
    }

    public void SetBaseUpgradePrice(long upgradePrice) {
        BaseUpgradePrice = upgradePrice;
    }

    public void UpgradeProduct()
    {
        currentProductPrice = (long)((float)(currentProductPrice)*UpgradeMultiplier);
        gs.UpdateBalance(currentUpgradePrice, false);
        currentUpgradePrice = (long)((float)(currentUpgradePrice)*UpgradePriceMultiplier);
        
        CurrentProfitText.GetComponent<Text>().text = ""+currentProductPrice+"/product sold";
        CurrentUpgradeText.GetComponent<Text>().text = ""+currentUpgradePrice;
    }

    public long GetProductPrice() {
        return this.currentProductPrice;
    }

    IEnumerator ProcessOrder (int waitTime) {
        gs.UpdateBalance(currentProductPrice, true);
    
        yield return new WaitForSeconds(waitTime);
        processOrder = false;
    }
}
