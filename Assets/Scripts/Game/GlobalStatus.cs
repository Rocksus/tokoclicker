using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalStatus : MonoBehaviour {
  // Balance
  public static int Balance;
  public GameObject balanceDisplay;
  public int internalBalance;

   // OrderRate
  public static int OrderRate;
  public GameObject orderRateDisplay;
  public int internalOrderRate;

   // Worker
  public static int WorkerCount;
  public GameObject workerDisplay;
  public int internalWorker;

   // Worker efficiency
  public static int WorkerEfficiency;
  public GameObject workerEfficiencyDisplay;
  public int internalWorkerEfficiency;

  // Revenue multiplier
  public static int RevenueMultiplier;
  public GameObject revenueMultiplierDisplay;
  public int internalRevenueMultiplier;

  void Update() {
    // Balance
    internalBalance = Balance;
    balanceDisplay.GetComponent<Text>().text = internalBalance;

    // OrderRate
    internalOrderRate = OrderRate;
    orderRateDisplay.GetComponent<Text>().text = internalOrderRate + " order/seconds";

    // Worker
    internalWorker = WorkerCount;
    workerDisplay.GetComponent<Text>().text = internalWorker;

    // Worker efficiency
    internalWorkerEfficiency = WorkerEfficiency;
    workerEfficiencyDisplay.GetComponent<Text>().text = internalWorkerEfficiency;

    // Revenue multiplier
    internalRevenueMultiplier = RevenueMultiplier;
    revenueMultiplierDisplay.GetComponent<Text>.text = internalRevenueMultiplier + "x";
  }
}