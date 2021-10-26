using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerObject : MonoBehaviour
{
    public GlobalStatus gs;
    public ScreenOrderManager som;
    public AudioManager am;

    public string PlaceName;
    public Vector3 Position;
    public ProductObject Product;

    // public AudioClip popSound;

    public void SetPlaceName(string placeName) {
        this.PlaceName = placeName;
    }

    public void SetPosition(float x, float y) {
        this.Position = new Vector3(x, y, 0.0f);
        this.gameObject.transform.position = this.Position;
    }

    public void Initiate(GlobalStatus gs, ScreenOrderManager som, AudioManager am) {
        this.gs = gs;
        this.som = som;
        this.am = am;
        this.gameObject.SetActive(false);
    }

    public void SetProduct(GameObject product) {
        this.Product = product.GetComponent<ProductObject>();   
    }

    public string GetPlaceName() {
        return this.PlaceName;
    }

    public Vector3 GetPosition() {
        return this.Position;
    }

    public GameObject GetOrderPointer() {
        return this.gameObject;
    }

    public void SpawnPointer() {
        this.gameObject.SetActive(true);

        som.IncreaseOrderCount();
        StartCoroutine(RemovePointerWithTimer());
    }

    public IEnumerator RemovePointerWithTimer() {
        yield return new WaitForSeconds(5);
        RemovePointer();
    }

    public void RemovePointer() {
        som.DecreaseOrderCount();
        this.gameObject.SetActive(false);
    }

    public void PopPointer() {
        // am.PlaySFX(popSound);
        this.RemovePointer();
        if (this.Product != null) {
            gs.UpdateBalance(this.Product.GetProductPrice(), true);
        }
    }
}
