using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrderManager : MonoBehaviour {
  public GlobalStatus gs;
  public RandomProduct rp;
  
  public int OrderCount = 0;

  private float manualOrderRate;
  private bool createOrder;
  private int maxManualOrder;
  private int internalOrderCount;
  private bool autoOrder=false;

  public void StartOrderManager() {
    // Manual Order
    StartCoroutine(SpawnManualOrder());
    // Auto Order
    StartCoroutine(CalculateAutoOrder());
  }

  IEnumerator SpawnManualOrder() {
    while(true) {
      // print("SpawnManualOrder");
      manualOrderRate = gs.GetManualOrderRate();
      if(manualOrderRate<=0) {
        manualOrderRate = 1;
      }

      CreateNewOrder();

      yield return new WaitForSeconds(1 / manualOrderRate);
    }
  }

  IEnumerator CalculateAutoOrder() {
    while(true) {
      DoAutoOrder();
      yield return new WaitForSeconds(1);
    }
  }

  public int GetOrderCount() {
    return OrderCount;
  }

  public void IncreaseOrderCount() {
    OrderCount += 1;
  }

  public void DecreaseOrderCount() {
    OrderCount -= 1;
  }

  void CreateNewOrder() {
    maxManualOrder = gs.GetMaxManualOrder();
    if (OrderCount > maxManualOrder) {
      return;
    }
    GameObject currentProduct = rp.ChooseProduct();
    GameObject currentPointer = rp.ChoosePointer();
    PointerObject currentPointerObj = currentPointer.GetComponent<PointerObject>();
    currentPointerObj.SetProduct(currentProduct);
    currentPointerObj.SpawnPointer();
  }

  void DoAutoOrder() {
    float autoOrderRate = gs.GetAutoOrderRate();
    gs.UpdateBalance(gs.GetProductRevenue() * (long)autoOrderRate, true);

    autoOrder = !autoOrder;
  }
}