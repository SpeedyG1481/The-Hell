using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static int health;

    private void Awake()
    {
        health = 1;
    }
    public  void Damage()
    {
        health -= 1;
    }


}
