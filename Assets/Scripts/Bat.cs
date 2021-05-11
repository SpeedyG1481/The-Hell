using UnityEngine;

public class Bat : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D batRb;
    HealthSystem health;
    float endPoint;

    void Start()
    {
        health = new HealthSystem();
        endPoint = gameObject.transform.position.x - 200f;
        batRb.velocity = transform.right * speed;
    }

    private void Update()
    {
        destroyBat();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health.Damage();
            Debug.Log("girdi");
        }
    }


    public void destroyBat()
    {
        if (gameObject.transform.position.x <= endPoint)
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
    }
}