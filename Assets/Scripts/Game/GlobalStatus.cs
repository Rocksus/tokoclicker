using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalStatus : MonoBehaviour {

  // CONSTANT
  public const int MAX_MANUAL_ORDER_COUNT = 5;
  public const int MAX_PRODUCT_COUNT = 5;
  public int ProductCount=0;
  public int OrderCount=0;

  public ScreenOrderManager som;
  public AudioManager am;

  // Parents
  public GameObject PointerParent;
  public GameObject ProductParent;

  // Balance
  public long Balance;
  public GameObject balanceDisplay;
  public long internalBalance;

   // OrderRate
  public float AutoOrderRate;
  public float ManualOrderRate = 0.5f;
  public GameObject orderRateDisplay;
  public float internalOrderRate;

  // Worker
  public int WorkerCount;
  public GameObject workerDisplay;
  public int internalWorker;

  // Worker efficiency
  public float WorkerEfficiency = 0.5f;
  public GameObject workerEfficiencyDisplay;
  public float internalWorkerEfficiency;

  // Revenue multiplier
  public float RevenueMultiplier;
  public GameObject revenueMultiplierDisplay;
  public float internalRevenueMultiplier;

  // ProductList
  private List<GameObject> ProductList;

  // PointerList
  private List<GameObject> PointerList;
  public GameObject ProductPrefab;
  public GameObject PointerPrefab;

  void Start() {
    ProductList = new List<GameObject>();
    PointerList = new List<GameObject>();
    InitiatePointers();
    InitiateProduct();
    som.StartOrderManager();
  }

  public long GetBalance() {
    return this.Balance;
  }

  public float GetAutoOrderRate() {
    return AutoOrderRate;
  }

  public float GetManualOrderRate() {
    return ManualOrderRate;
  }

  public int GetWorkerCount() {
    return WorkerCount;
  }

  public long GetProductRevenue() {
    long revenue = 0;
    foreach(GameObject product in ProductList) {
      ProductObject productObject = product.GetComponent<ProductObject>();
      revenue += productObject.GetProductPrice();
    }
    return revenue;
  }

  public List<GameObject> GetProductList() {
    return ProductList;
  }

  public void AddProductToList(GameObject product) {
    ProductList.Add(product);
  }

  public List<GameObject> GetPointerList() {
    return PointerList;
  }

  public int GetMaxManualOrder() {
    return MAX_MANUAL_ORDER_COUNT;
  }

  public int GetMaxProduct() {
    return MAX_PRODUCT_COUNT;
  }

  public int GetOrderCount() {
    return OrderCount;
  }

  public void SetOrderCount(bool increase) {
    if (increase) {
      OrderCount += 1;
    } else {
      OrderCount -= 1;
    }
  }

  public void UpdateBalance(long balance, bool increase) {
    if (increase) {
      Balance += balance;
    } else {
      Balance -= balance;
    }
  }

  public void AddWorker(int num) {
    WorkerCount += num;
  }

  public void AddWorkerEfficiency(float num) {
    WorkerEfficiency = num;
  }

  public void AddRevenueMultiplier(float num) {
    RevenueMultiplier = num;
  }

  public void CalculateAutoOrderRate() {
    AutoOrderRate = Mathf.Round(WorkerCount * WorkerEfficiency);
  }

  public void CalculateManualOrderRate(float updateRate) {
    ManualOrderRate = ManualOrderRate + updateRate;
  }

  public void IncreaseProductCount() {
    ProductCount += 1;
  }

  void Update() {
    // Balance
    internalBalance = Balance;
    balanceDisplay.GetComponent<Text>().text = "" + internalBalance;

    // AutoOrderRate
    internalOrderRate = AutoOrderRate;
    orderRateDisplay.GetComponent<Text>().text = internalOrderRate + " order/second";

    // Worker
    internalWorker = WorkerCount;
    //workerDisplay.GetComponent<Text>().text = "" + internalWorker;

    // Worker efficiency
    internalWorkerEfficiency = WorkerEfficiency;
    //workerEfficiencyDisplay.GetComponent<Text>().text = "" + internalWorkerEfficiency;


    // Revenue multiplier
    internalRevenueMultiplier = RevenueMultiplier;
    //revenueMultiplierDisplay.GetComponent<Text>().text = internalRevenueMultiplier + "x";
    }

  public GameObject CreateProduct(string name, long baseProductPrice, long baseUpgradePrice) {
    GameObject newProduct = Instantiate(ProductPrefab) as GameObject;
    ProductObject productObject = newProduct.GetComponent<ProductObject>();
    productObject.SetBaseProductPrice(baseProductPrice);
    productObject.SetBaseUpgradePrice(baseUpgradePrice);
    productObject.SetProductName(name);
    productObject.SetGlobalStatus(this);
    productObject.Init();
    newProduct.transform.SetParent(ProductParent.transform, false);
    newProduct.transform.SetSiblingIndex(ProductParent.transform.childCount-2);

    return newProduct;
  }

  GameObject CreatePointer(string name, float x, float y) {
    GameObject newPointer = Instantiate(PointerPrefab) as GameObject;
    PointerObject pointerObject = newPointer.GetComponent<PointerObject>();
    pointerObject.SetPlaceName(name);
    pointerObject.SetPosition(x, y);
    pointerObject.Initiate(this, som, am);
    newPointer.transform.SetParent(PointerParent.transform, false);
  
    return newPointer;
  }

  void InitiatePointers() {
    PointerList.Add(CreatePointer("Banda Aceh", -595f, 200f));
    PointerList.Add(CreatePointer("Medan", -537f, 143f));
    PointerList.Add(CreatePointer("Padang", -481f, 49f));
    PointerList.Add(CreatePointer("Pekanbaru", -455f, 75f));
    PointerList.Add(CreatePointer("Jambi", -417f, 17f));
    PointerList.Add(CreatePointer("Palembang", -365f, -23f));
    PointerList.Add(CreatePointer("Bengkulu", -443f, -18f));
    PointerList.Add(CreatePointer("BandarLampung", -345f, -65f));
    PointerList.Add(CreatePointer("Pangkalpinang", -331f, 11f));
    PointerList.Add(CreatePointer("Tanjungpinang", -372f, 96f));
    PointerList.Add(CreatePointer("Jakarta", -309f, -103f));
    PointerList.Add(CreatePointer("Bandung", -275f, -126f));
    PointerList.Add(CreatePointer("Semarang", -210f, -138f));
    PointerList.Add(CreatePointer("Yogyakarta", -204f, -152f));
    PointerList.Add(CreatePointer("Surabaya", -192f, -126f));
    PointerList.Add(CreatePointer("Serang", -171f, -142f));
    PointerList.Add(CreatePointer("Denpasar", -77f, -162f));
    PointerList.Add(CreatePointer("Mataram", -21f, -173f));
    PointerList.Add(CreatePointer("Kupang", 23f, -167f));
    PointerList.Add(CreatePointer("Pontianak", -229f, 86f));
    PointerList.Add(CreatePointer("Palangkaraya", -138f, 30f));
    PointerList.Add(CreatePointer("Banjarmasin", -75f, -18f));
    PointerList.Add(CreatePointer("Samarinda", -48f, 92f));
    PointerList.Add(CreatePointer("Tanjung Selor", -32f, 185f));
    PointerList.Add(CreatePointer("Manado", 150f, 86f));
    PointerList.Add(CreatePointer("Palu", 32f, -16f));
    PointerList.Add(CreatePointer("Makassar", 53f, -59f));
    PointerList.Add(CreatePointer("Kendari", 110f, -37f));
    PointerList.Add(CreatePointer("Gorontalo", 107f, 30f));
    PointerList.Add(CreatePointer("Mamuju", 44f, 8f));
    PointerList.Add(CreatePointer("Ambon", 240f, -25f));
    PointerList.Add(CreatePointer("Jayapura", 410f, 28f));
    PointerList.Add(CreatePointer("Manokwari", 580f, -52f));
  }

  void InitiateProduct() {
    AddProductToList(CreateProduct("Product #1",(long)100, (long)1000));
  }
}