using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            rb.velocity = Vector2.right * speed;
            rb.AddForce(new Vector2(0, 150));
        }
    }
}
