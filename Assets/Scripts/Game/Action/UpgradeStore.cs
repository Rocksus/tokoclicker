using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStore : MonoBehaviour {
  public GameObject autoOrder;

  void Update() {
    calculateOrderRate();
  }

  public void StartAutoOrder() {
    autoOrder.SetActive(true);
    AddWorker(2);
  }

  public void AddWorker(int worker) {
    GlobalStatus.WorkerCount += worker;
    WorkerUpgrade.TurnOffButton = true;
    WorkerUpgrade.UpgradePrice *= WorkerUpgrade.PriceMultiplier;
  }

  public void AddWorkerEfficiency(float workerEfficiency) {
    GlobalStatus.WorkerEfficiency += workerEfficiency;
  }

  public void AddRevenueMultiplier(int revenueIncrease) {
    GlobalStatus.RevenueMultiplier += revenueIncrease;
  }

  private void calculateOrderRate() {
    GlobalStatus.OrderRate = Mathf.Round(GlobalStatus.WorkerCount * GlobalStatus.WorkerEfficiency);
  }
}