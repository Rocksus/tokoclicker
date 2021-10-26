using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddProduct : MonoBehaviour {
  public GlobalStatus gs;

  public Button AddProductButton;
  public GameObject AddProductButtonDisplay;
  public GameObject NotEligiblePurchaseDisplay;
  public long BaseCreatePrice = 0;
  public float PriceMultiplier = 1;

  public long BaseProductPrice = 0;
  public float ProductPriceMultiplier = 1;

  private int productCounter;
  private long currentBalance;
  private long addProductPrice;
  private long currentProductBasePrice;
  void Start() {
    productCounter = gs.GetProductList().Count;
    addProductPrice = BaseCreatePrice;
    currentProductBasePrice = BaseProductPrice;
    AddProductButton.interactable = false;
    AddProductButtonDisplay.GetComponent<Text>().text = "Add Product - " + addProductPrice;
    NotEligiblePurchaseDisplay.GetComponent<Text>().text = "(not enough money)";
  }

  void Update() {
    currentBalance = gs.GetBalance();
    if (currentBalance >= addProductPrice) {
      AddProductButton.interactable = true;
      NotEligiblePurchaseDisplay.SetActive(false);
    } else {
      AddProductButton.interactable = false;
      NotEligiblePurchaseDisplay.SetActive(true);
      
    }

    productCounter = gs.GetProductList().Count;
    if (productCounter >= gs.GetMaxProduct()) {
      AddProductButton.gameObject.SetActive(false);
    }
  }

  public void CreateProduct() {
    if (productCounter >= gs.GetMaxProduct()) {
      return;
    }
    gs.UpdateBalance(addProductPrice, false);
    addProductPrice = (long)(addProductPrice * PriceMultiplier);
    currentProductBasePrice = (long)(currentProductBasePrice * ProductPriceMultiplier);
    GameObject newProduct = gs.CreateProduct("Product #"+(productCounter+1), currentProductBasePrice, (long)(currentProductBasePrice*10*productCounter));
    gs.AddProductToList(newProduct);
    AddProductButtonDisplay.GetComponent<Text>().text = "Add Product - " + addProductPrice;
  }
}