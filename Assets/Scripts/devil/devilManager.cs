using System;
using Loader;
using UnityEngine;

public class devilManager : MonoBehaviour
{
    public GameObject player, finishPosition, camera, grid;
    public float slide;
    public static bool devil_IsPaused;
    public bool pFinish;
    public static int devilDied;
    public Vector3 delay;
    public AudioSource stab;

    private void Awake()
    {
        Time.timeScale = 2F;
    }

    private void FixedUpdate()
    {
        grid.transform.position += new Vector3(-slide, 0f, 0f);
        cameraManager();
        devilMapManager();
    }

    void devilMapManager()
    {
        if (!devil_IsPaused)
        {
            if (HealthSystem.health == 0) //player when dead
            {
                devilDied++;
                RestartGame(); //butona koyulcak 
                // deathCanvas.SetActive(true);
                //gameCanvas.SetActive(false);
                StopGame();
            }

            if (devilDied >= 20)
            {
                CurseManager.curse = "";
                devilDied = 0;
                SceneLoader.Load(Scenes.MainGameScene);
            }
        }

        if (IsPlayerWin())
        {
            SceneLoader.Load(Scenes.MainGameScene);
        }
    }

    bool IsPlayerWin()
    {
        if (player.transform.position.x >= finishPosition.transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void cameraManager()
    {
        camera.transform.position = new Vector3(player.transform.position.x + delay.x,
            player.transform.position.y + delay.y, delay.z);
    }

    private void StopGame()
    {
        if (devil_IsPaused)
        {
            Time.timeScale = 2;
            devil_IsPaused = false;
        }

        else
        {
            Time.timeScale = 0;
            devil_IsPaused = true;
        }
    }

    private void RestartGame()
    {
        Debug.Log("restatr");
        SceneLoader.Load(Scenes.DevilMap);
        StopGame();
        HealthSystem.health = 1;
        // deathCanvas.SetActive(false);
    }
}