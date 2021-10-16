using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour, GameObserver, PlayerStatsObserver 
{
  public static GameObject GameObject;

  // UI elements
  public Text hudBalance;
  public Text hudOrderRate;

  // Screens
  public Canvas hudScreen;
  public Canvas productManagementScreen;
  public Canvas storeUpgradeScreen;

  // Player stats
  private int currentBalance;
  private int currentOrderRate;

  public GameSimulation currentGame;

  void Start()
  {
    productManagementScreen.enabled = false;
    storeUpgradeScreen.enabled = false;

    // TODO: Rename the prefabs
    GameObject = Instantiate(Resources.Load<GameObject>("Prefabs/MainGame"), new Vector3(0, 0), Quaternion.identity);
    currentGame = GameObj.GetComponent<GameSimulation>();
    currentGame.AddObserver(this);
    currentGame.stats.AddObserver(this);

    hudBalance = PlayerPrefs.GetInt("balance");
    hudOrderRate = PlayerPrefs.GetInt("order_rate");

    Countdown.Create(StartGame);
  }

  void Update()
  {
    CheckUserInput();
  }

  void CheckUserInput()
  {
    if (!currentGame.isStarted)
      return;
    // For hotkey
    if (Input.GetKeyDown(KeyCode.Space))
    {
      // Do something
    }
  }

  void StartGame()
  {
    currentGame.StartGame();
  }

  public void OnUpdateBalance(int newBalance)
  {
    currentBalance = newBalance;
  }

  public void OnUpdateOrderRate(int newOrderRate)
  {
    currentOrderRate = newOrderRate;
  }

  void OpenProductManagementScreen()
  {
    hudScreen.enabled = false;
    storeUpgradeScreen.enabled = false;
    productManagementScreen.enabled = true;
  }

  void OpenStoreUpgradeScreen()
  {
    hudScreen.enabled = false;
    productManagementScreen.enabled = false;
    storeUpgradeScreen.enabled = true;
  }

  void ClosePopUpScreen()
  {
    hudScreen.enabled = true;
    storeUpgradeScreen.enabled = false;
    productManagementScreen.enabled = false;
  }
}