using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerUpgrade : MonoBehaviour {
  public GameObject overlayButton;
  public GameObject overlayText;
  public GameObject upgradeButton;
  public GameObject upgradeText;

  public int currentBalance;

  public static int PriceMultiplier;
  public static int UpgradePrice;
  public static bool TurnOffButton = false;

  void Update() {
    currentBalance = GlobalStatus.Balance;
    overlayText.GetComponent<Text>.text = "Hire worker";
    upgradeText.GetComponent<Text>.text = "Hire worker";

    if (currentBalance >= UpgradePrice && !TurnOffButton) {
      overlayButton.SetActive(false);
      upgradeButton.SetActive(true);
    }

    if (TurnOffButton) {
      overlayButton.SetActive(true);
      upgradeButton.SetActive(false);
      TurnOffButton = false;
    }
  }
}