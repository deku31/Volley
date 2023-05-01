using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer PlayerSkin;

    public float speed;
    public float jf;
    private Rigidbody2D rb2d;
    bool isGrounded;
    public LayerMask TargetLayer;
    float moveHoriz=0;

    gameManager gm;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<gameManager>();
    }

    void Update()
    {
        if (gm.start)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, TargetLayer);
            isGrounded = hit.collider != null;
            //moveHoriz = Input.GetAxisRaw("Horizontal");
            rb2d.velocity = new Vector2(speed * moveHoriz, rb2d.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jf));
        }
    }

    public void MovePlayer(float move)
    {
        moveHoriz = move;
    }
    public void StopMove()
    {
        moveHoriz = 0;
    }
}
