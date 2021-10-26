using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOrder : MonoBehaviour {
  public GlobalStatus gs;

  private float orderRate;
  private int waitTime;

  void Update() {
    orderRate = gs.GetAutoOrderRate();

  }

  IEnumerator ProcessOrder (float revenue, int waitTime) {
    gs.UpdateBalance((long)(revenue), true);
  
    yield return new WaitForSeconds(waitTime);
  }
}