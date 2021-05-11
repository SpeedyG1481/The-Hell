using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTrap : MonoBehaviour
{
    HealthSystem health;
    public AudioSource stab, burn, beQuick;
    public static bool devilWin;
    private void Awake()
    {
        health = new HealthSystem();

    }
    private void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

            switch (collision.gameObject.tag)
            {
                case "timeCurse":
                health.Damage();
                stab.Play();
                CurseManager.curse = "timeCurse";
                break;

                case "mirrorXcurse":
                stab.Play();
                CurseManager.curse = "mirrorXcurse";
                    health.Damage();
                break;
                case "mirrorYcurse":
                stab.Play();
                CurseManager.curse = "mirrorYcurse";
                    health.Damage();

                break;
                case "batCurse":
                stab.Play();
                CurseManager.curse = "batCurse";
                    health.Damage();

                break;
                case "cantStopCurse":
                burn.Play();
                CurseManager.curse = "cantStopCurse";
                    health.Damage();

                break;
                case "visionCurse":
                burn.Play();
                CurseManager.curse = "visionCurse";
                    health.Damage();
                break;
        }
        
    }


    
}