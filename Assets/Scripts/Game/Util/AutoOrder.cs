using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOrder : MonoBehaviour {
  public bool autoProcess = false;
  public int internalOrderRate;
  public int internalPriceMultiplier;

  void Update() {
    internalOrderRate = GlobalStatus.OrderRate;
    internalPriceMultiplier = GlobalStatus.PriceMultiplier;
    
    if (!autoProcess) {
      autoProcess = true;
      StartCoroutine(ProcessOrder());
    }
  }

  IEnumerator ProcessOrder () {
    GlobalStatus.Balance += (internalOrderRate * internalPriceMultiplier);
  
    yield return new WaitForSeconds(1);

    autoProcess = false;
  }

}