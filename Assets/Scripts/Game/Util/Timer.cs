using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public delegate void Callback();

    public Callback callback;
    public float time = 0;
    public float waitTime;
    public float repeatInterval;
    public bool repeating = false;
    public bool running { get; private set; }

    public static Timer Create(GameObject where, float waitTime, float repeatInterval, Callback callback)
    {
        var timer = Create(where, waitTime, callback);
        timer.repeatInterval = repeatInterval;
        timer.repeating = true;
        return timer;
    }

    public static Timer Create(GameObject where, float waitTime, Callback callback)
    {
        var timer = where.AddComponent<Timer>();
        timer.callback = callback;
        timer.waitTime = waitTime;
        timer.time = -waitTime;
        return timer;
    }

    public void ResetTimer() { time = -waitTime; }

    public void StartTimer() { running = true; }

    public void PauseTimer() { running = false; }

    public void StopTimer() { PauseTimer(); ResetTimer(); }

    public void UpdateInterval(float repeatInterval)
    {
        this.repeatInterval = repeatInterval;
        ResetTimer();
    }

    public void UpdateWaitTime(float waitTime)
    {
        this.waitTime = waitTime;
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            if (time >= 0)
            {
                callback();
                if (repeating) time = -repeatInterval;
                else StopTimer();
            }
            time += Time.deltaTime;
        }
    }
}
