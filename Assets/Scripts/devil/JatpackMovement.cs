using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JatpackMovement : MonoBehaviour
{
    public Rigidbody2D jatpackRgb;
    public Vector3 velocity;
    public float amountForce;
    
    void Start()
    {
        jatpackRgb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        jatpackMovement();
    }
    public void jatpackMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch first = Input.GetTouch(0);
            if (Input.GetKey(KeyCode.W)/*|first.phase == TouchPhase.Stationary)*/ )
            {
                jatpackRgb.AddForce(new Vector3(0, amountForce, 0));
            }
        }

    }
}
