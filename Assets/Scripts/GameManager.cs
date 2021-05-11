using Loader;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPaused;
    public GameObject player, gameCanvas, checkPointCanvas, bat, crossFade, deathCanvas, DevilCanvasObject;
    public Transform playerPosition, resetPosition, c1, c2, c3, c4;
    public static int deathCounter, deathDistance;

    public UIManager saver;

    //public CameraShaker cameraShaker;
    public float duration, magnitude;
    public Animator aliveAnim;
    bool IsRevieve;
    bool animatorFinish;
    public AudioSource Laugh;


    private void Start()
    {
        Invoke(nameof(CrossFadeEffect), 1.5F);
    }

    public void CrossFadeEffect()
    {
        crossFade.SetActive(false);
    }

    private void Awake()
    {
        deathCounter = PlayerPrefs.GetInt("deathCount");
        deathDistance = PlayerPrefs.GetInt("distance");
        IsRevieve = false;
        CurseManager.curse = PlayerPrefs.GetString("Curse");
    }

    void Update()
    {
        DevilCanvasLaugh();
    }

    void FixedUpdate()
    {
        Debug.Log("health" + HealthSystem.health);
        GameRunning();
        Debug.Log(CurseManager.curse);
        Debug.Log(deathCounter);
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("resetGame");
            deathCounter = 0;
            CurseManager.curse = "";
            deathDistance = 0;
            PlayerPrefs.SetInt("deathCount", deathCounter);
            PlayerPrefs.SetString("Curse", CurseManager.curse);
            PlayerPrefs.SetInt("distance", deathDistance);
        }
    }

    public void DevilCanvasLaugh()
    {
        if (DevilCanvasObject.activeInHierarchy)
        {
            Laugh.Play();
        }
    }

    private void GameRunning()
    {
        if (!isPaused)
        {
            if (Time.timeScale == 0 || Time.timeScale == 1)
            {
                if (CurseManager.curse == "timeCurse")
                {
                    Time.timeScale = 2;
                }

                else
                {
                    Time.timeScale = 1;
                }
            }
        }


        if (HealthSystem.health <= 0) //player when dead
        {
            if (!animatorFinish)
                DieAnim();
        }
    }


    private void LostGame()
    {
        if (playerPosition.position.x > c1.position.x && deathCounter != 15)
        {
            gameCanvas.SetActive(false);
            checkPointCanvas.SetActive(true);
        }
        else
        {
            gameCanvas.SetActive(false);
            deathCanvas.SetActive(true);
        }
    }

    private void RestartGame(Transform x)
    {
        aliveAnim.SetBool("Alive", true);
        HealthSystem.health = 1;
        gameCanvas.SetActive(true);
        checkPointCanvas.SetActive(false);
        if (CurseManager.curse == "mirrorYcurse")
        {
            player.transform.position = resetPosition.position;
            StopGame();
        }
        else if (!IsRevieve)
        {
            player.transform.position = x.position;
            StopGame();
        }
        else
        {
            StopGame();
            player.transform.position = x.position;
            IsRevieve = false;
        }

        bat.SetActive(false);
    }

    public void StopGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            if (CurseManager.curse == "timeCurse")
            {
                Debug.Log("timeScale2");
                Time.timeScale = 2;
            }
        }

        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void Revieve() //Meleği seçerse çağırılıcak
    {
        IsRevieve = true;
        CheckPoint();
        StopGame();
    }

    void DieAnim()
    {
        aliveAnim.SetBool("Alive", false);
        Debug.Log(534);

        Invoke("stuff", 1.5f);
        animatorFinish = true;
    }

    void stuff()
    {
        deathCounter++;
        StopGame();
        PlayerMovement.Istouched = false;
        saver.Save();
        aliveAnim.SetBool("Alive", false);
        Debug.Log("died");
        PlayerPrefs.SetInt("deathCount", deathCounter);
        deathDistance = (int) playerPosition.position.x;
        LostGame();
    }

    public void CheckPoint()
    {
        HealthSystem.health = 1;
        if (playerPosition.position.x > c1.position.x)
        {
            RestartGame(c1);
        }
        else if (playerPosition.position.x > c2.position.x)
        {
            RestartGame(c2);
        }
        else if (playerPosition.position.x > c3.position.x)
        {
            RestartGame(c3);
        }
        else if (playerPosition.position.x > c4.position.x)
        {
            RestartGame(c4);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Curse", CurseManager.curse);
    }

    public void RestartButton()
    {
        RestartGame(resetPosition);
        deathCanvas.SetActive(false);
        animatorFinish = false;
    }

    public void CanvasRestartBut()
    {
        SceneLoader.Load(Scenes.MainGameScene);
    }
}