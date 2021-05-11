using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public bool finnished = false;
    float start;
    bool running;
    HealthSystem health;
    public float deltaTime
    {
        get
        {
            if (!GameManager.isPaused)
                return UnityEngine.Time.time - start;
            return 0;
        }
    }

    public void Start()
    {
        health = new HealthSystem();
        startTime = UnityEngine.Time.time;
        if (GameManager.isPaused)
        {
            start = UnityEngine.Time.time;
            running = true;
        }
    }

    public void Stop()
    {
        if (!GameManager.isPaused)
        {
            start = 0;
        }
    }

    public void Reset()
    {
        if (finnished)
        {
            health.Damage();
        }        
            Stop();
            start = UnityEngine.Time.time;
            finnished = false;
        
 
    }


    public void Time()
    {
        string minutes = ((int)deltaTime / 60).ToString();
        string seconds = (deltaTime % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds + "\tLeft";
    }

    public void Finnish()
    {
        if (deltaTime >= 2.5f)
        {
            
            finnished = true;
            
            Reset();
        }
    }

}
