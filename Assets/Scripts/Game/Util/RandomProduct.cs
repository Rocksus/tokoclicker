using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProduct : MonoBehaviour {
  public GlobalStatus gs;
  
  private GameObject chosenProduct;
  private GameObject chosenPointer;
  
  private List<GameObject> products;
  private int productIdx;

  private List<GameObject> pointers;
  private int pointerIdx;

  public GameObject ChooseProduct() {
    products = gs.GetProductList();
    productIdx = Random.Range(0, products.Count);
    chosenProduct = products[productIdx];
    return chosenProduct;
  }

  public GameObject ChoosePointer() {
    pointers = gs.GetPointerList();
    pointerIdx = Random.Range(0, pointers.Count);

    chosenPointer = pointers[pointerIdx];

    return chosenPointer;
  }
}