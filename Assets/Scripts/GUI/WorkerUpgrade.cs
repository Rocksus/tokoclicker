using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerUpgrade : MonoBehaviour {
  public GameObject overlayButton;
  public GameObject overlayText;
  public GameObject upgradeButton;
  public GameObject upgradeText;

  public GlobalStatus gs;
  public long currentBalance;

  public float PriceMultiplier;
  public long UpgradePrice;
  public bool buttonOff = false;

  public void TurnOnButton() {
    buttonOff = false;
  }

  public void TurnOffButton() {
    buttonOff = true;
  }

  public void MultiplyPrice() {
    UpgradePrice *= (long)PriceMultiplier;
  }

  void Update() {
    currentBalance = gs.GetBalance();
    overlayText.GetComponent<Text>().text = "Hire worker";
    upgradeText.GetComponent<Text>().text = "Hire worker";

    if (currentBalance >= UpgradePrice && !buttonOff) {
      overlayButton.SetActive(false);
      upgradeButton.SetActive(true);
    }

    if (buttonOff) {
      overlayButton.SetActive(true);
      upgradeButton.SetActive(false);
      buttonOff = false;
    }
  }
}