using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedAmount;
    public float jumpAmount;
    public Rigidbody2D rgb;
    public Vector3 velocity;
    public bool Isjumping, Isrunning;
    public static bool Istouched;
    public Timer t;
    public Animator runAnim;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        // rgb.drag = 1.5f;
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    public void jumpButton()
    {
        if (!Isjumping)
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse); //Jump
            Isjumping = true;
        }
    }

    private void HandleMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch first = Input.GetTouch(0);
            runAnim.SetTrigger("Running");

            if (Input.GetKey(KeyCode.D) | first.phase == TouchPhase.Stationary)
            {
                Istouched = true;
                velocity = new Vector3(5f, 0f, 0f);
                transform.position += velocity * speedAmount * Time.deltaTime;
                Isrunning = true;
                t.Reset();
            }
            else if (CurseManager.curse == "cantStopCurse")
            {
                t.Time();
                t.Finnish(); //SÜREYİ BAŞLAT
            }


            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f); //Rotation   RightSide
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Isjumping = false;
        }
    }
}