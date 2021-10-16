using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSimulation : MonoBehaviour
{
    // Time logic variables
    public const float LockDelay = .5f;
    public bool isStarted;
    public Timer lockTimer;
    public float dropInterval = 1.0f;
    public bool isPaused = false;

    // Observers
    public List<GameObserver> observers = new List<GameObserver>();

    void Awake()
    {
        ResetVariables();
    }

    void Update()
    {

    }

    public void StartGame()
    {
        isStarted = true;
    }

    public void AddObserver(GameObserver observer)
    {
        if (observers.Contains(observer)) return;
        observers.Add(observer);
    }
}