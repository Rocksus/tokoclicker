using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ScriptableObject
{
    // Score constants
    public static readonly int[] ClearScores = { 40, 100, 300, 1200 };
    public static readonly int[] LevelMultipliers = { 20, 25, 30, 40 };

    public int balance { get; private set; }
    public int orderRate { get; private set; }

    // Playerpref keys
    public const string PrefName = "PlayerName";
    public const string PrefBalance = "Balance";
    public const string PrefOrderRate = "OrderRate";

    private List<PlayerStatsObserver> observers = new List<PlayerStatsObserver>();

    public void UpdateBalance(int balance)
    {
        this.balance = balance;
        NotifyUpdateBalance(balance);
    }

    public void UpdateOrderRate(int orderRate)
    {
      this.orderRate = orderRate;
      NotifyUpdateOrderRate(orderRate);
    }

    public void AddBalance(int delta)
    {
      UpdateBalance(this.balance + delta);
    }

    public void AddOrderRate(int delta)
    {
      // TODO: Add logic for order rate
      UpdateOrderRate();
    }

    private void NotifyUpdateBalance(int balance)
    {
        foreach (var observer in observers)
            observer.OnUpdateBalance(balance);
    }

    private void NotifyUpdateOrderRate(int orderRate)
    {
        foreach (var observer in observers)
            observer.OnUpdateOrderRate(orderRate);
    }

    public void AddObserver(PlayerStatsObserver observer)
    {
        if (observers.Contains(observer)) return;
        observers.Add(observer);
    }

    public static void SaveBalance(int balance)
    {
        PlayerPrefs.SetString(PrefBalance, balance);
    }

    public static void SaveOrderRate(int orderRate)
    {
        PlayerPrefs.SetString(PrefOrderRate, orderRate);
    }
}
