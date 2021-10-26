using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageStore : MonoBehaviour {
  public GameObject StorePage;
  void Start() {
    StorePage.SetActive(false);
  }

  public void OpenStorePage() {
    StorePage.SetActive(true);
  }

  public void CloseStorePage() {
    StorePage.SetActive(false);
  }
}