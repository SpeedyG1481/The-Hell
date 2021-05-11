using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatLauncher : MonoBehaviour
{
    public Transform spawnPoint,endPoint;
    public GameObject batPrefab;
    public int random;

    

    
    void FixedUpdate()//update or fixedUpdate?
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }*/
        random = Random.Range(1, 100);
        if(random == 1 && CurseManager.curse=="batCurse")
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(batPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
