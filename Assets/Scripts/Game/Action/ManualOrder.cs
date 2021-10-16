using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualOrder : MonoBehaviour {
  public int internalPriceMultiplier;
  public void ProcessOrder () {
    InternalPriceMultiplier = GlobalStatus.PriceMultiplier;
    
    GlobalStatus.Balance += InternalPriceMultiplier;
  }
}