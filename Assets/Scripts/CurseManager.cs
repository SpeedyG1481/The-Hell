using System.Collections.Generic;
using Ads;
using Loader;
using UnityEngine;

public class CurseManager : MonoBehaviour
{
    public static string curse;
    public static Dictionary<int, string> curseList;
    public bool adActivated;

    public static int curseCounter, maxCurse;
    //public AudioSource Laugh;

    bool Ycurse;

    public GameObject camera, bat, mapGenerator, player, gameCanvas, devilCanvas;

    public float tolerance;
    public int toleranceTime;


    public Transform t;
    public Timer timer;
    HealthSystem health;

    private void Awake()
    {
        PlayerMovement playerRgb = player.GetComponent<PlayerMovement>();
        curseCounter = 0;
        t = transform;
        health = GetComponent<HealthSystem>();
    }

    private void FixedUpdate()
    {
        CurrentCurse();
        if (Input.GetKey(KeyCode.R))
        {
            GameManager.deathCounter = 0;
        }
    }

    private void CurrentCurse()
    {
        if (curse == "batCurse")
        {
            bat.SetActive(true);
        }
        else
        {
            bat.SetActive(false);
        }

        if (GameManager.deathCounter == 7 && !adActivated)
        {
            new TenDeadAd().ShowAd();
            adActivated = true;
        }
        

        if (GameManager.deathCounter == 15)
        {
            //Laugh.Play();
            devilCanvas.SetActive(true);
            gameCanvas.SetActive(false);
            Time.timeScale = 0.75f;
            adActivated = false;
        }
    }

    public void devilButton()
    {
        PlayerPrefs.SetInt("deathCount", 0);
        curse = "";
        SceneLoader.Load(Scenes.DevilMap);
    }
}