using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackTraps : MonoBehaviour
{
    public int random;
    public GameObject batTrap, batTrapSpawner;
    public Transform spawnPoint;
    HealthSystem health;
    float destroyPoint;


    void FixedUpdate()
    {
        TrapManager();

    }

    private void TrapManager()
    {
        random = (int)Random.Range(1, 500);
        if (random == 1 && batTrapSpawner.name == "BatSpawner1")
        {
            Shoot();
        }
        if (random == 9 && batTrapSpawner.name == "BatSpawner1")
        {
            Shoot();
        }
        if (random == 11 && batTrapSpawner.name == "BatSpawner1")
        {
            Shoot();
        }
        if (random == 2 && batTrapSpawner.name == "BatSpawner2")
        {
            Shoot();
        }
        if (random == 3 && batTrapSpawner.name == "BatSpawner3")
        {
            Shoot();
        }
        if (random == 4 && batTrapSpawner.name == "BatSpawner4")
        {
            Shoot();
        }
        if (random == 5 && batTrapSpawner.name == "BatSpawner5")
        {
            Shoot();
        }
        if (random == 6 && batTrapSpawner.name == "BatSpawner6")
        {
            Shoot();
        }
        if (random == 7 && batTrapSpawner.name == "BatSpawner7")
        {
            Shoot();
        }
        if (random == 8 && batTrapSpawner.name == "BatSpawner8")
        {
            Shoot();
        }
        if (random == 10 && batTrapSpawner.name == "BatSpawner8")
        {
            Shoot();
        }
        if (random == 12 && batTrapSpawner.name == "BatSpawner8")
        {
            Shoot();
        }
    }

    public void destroyBat()
    {
        if (gameObject.transform.position.x <= destroyPoint)
        {
            Destroy(gameObject);
        }
    }
 
    void Shoot() 
    {
        Instantiate(batTrap, spawnPoint.position, spawnPoint.rotation);

    }
}
