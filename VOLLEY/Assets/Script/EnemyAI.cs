using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform epf;
    public SpriteRenderer skin;

    public float speed = 5f; // speed of the enemy's movement
    public float batasminimal= 0f; // boundary to keep the enemy within the game area
    public float batasmaksimal= 5f; // boundary to keep the enemy within the game area
    public float jumpForce= 5f; 

    public float jumpHeight = 5f; // height of the enemy's jump
    public float jumpDistance = 2f; // distance around the enemy where it can jump
    public float jumpDistanceY = 2f; // distance around the enemy where it can jump

    private bool isGrounded=true;
    public Transform ball; // reference to the ball object

    private Rigidbody2D rb;
    public LayerMask TargetLayer;

    public gameManager gm;
    Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<gameManager>();
    }

    private void Update()
    {
         direction = ball.position - transform.position;
    }
    void LateUpdate()
    {
        if (gm.start==true)
        {
            //cek ground
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, TargetLayer);
            isGrounded = hit.collider != null;
            int Rand = Random.RandomRange(0, 3);

            // menghitung posisi enemy dengan bola

            // mengejar bola
            if (Mathf.Abs(ball.position.x - transform.position.x) < jumpDistance && isGrounded == true)
            {
                rb.velocity = new Vector2(direction.x, rb.velocity.y).normalized * speed;
            }
            else if (Mathf.Abs(ball.position.x - transform.position.x) > jumpDistance && isGrounded == true)
            {
                rb.velocity = new Vector2(direction.x, rb.velocity.y).normalized * speed;
            }
            // Script ai hanya mengejar pada batas yang telah diatur
            float xPos = Mathf.Clamp(transform.position.x, batasminimal, batasmaksimal);
            transform.position = new Vector2(xPos, transform.position.y);

            //mengecek enemy berada ditanah atau tidak
            if (Mathf.Abs(ball.position.x - transform.position.x) < jumpDistance
                && Mathf.Abs(ball.position.y - transform.position.y) < jumpDistanceY && ball.position.x < transform.position.x && isGrounded)
            {
                Rand = Random.RandomRange(0, 3);
                if (Rand == 0)
                {
                    rb.AddForce(new Vector2(0, jumpForce));
                }
            }
        }
    }
}
