using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BolaScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    gameManager gm;
    bool start;
    void Start()
    {
        gm = FindObjectOfType<gameManager>();
        start = true;
    }

    void Update()
    {
        int random = Random.RandomRange(-1, 1);

        if (gm.start==true&&start==true)
        {
            random = Random.RandomRange(-1, 1);
            rb = GetComponent<Rigidbody2D>();
            while (random==0)
            {
                random = Random.RandomRange(-1, 1);
            }
            rb.velocity = new Vector2(random,0) * speed;
            //rb.AddForce(new Vector2(0, 0));
            start = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            rb.velocity = Vector2.right * speed/2;
            rb.AddForce(new Vector2(50, 100));
        }
        else if (collision.CompareTag("enemy"))
        {
            rb.velocity = Vector2.left * speed/2;
            rb.AddForce(new Vector2(-50,-100));
        }
        //else if (collision.CompareTag("ground"))//jika terkena tanah game akan diulang
        //{
        //    gm.start = false;
        //    start = true;
        //    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}

        if (collision.transform.tag == "PlayerPos")
        {
            Debug.Log("EnemyScore");
            gm.start = false;
            start = true;
            gm.Se+=1;
        }
        else if (collision.transform.tag == "EnemyPos")
        {
            Debug.Log("PlayerScore");
            gm.start = false;
            start = true;
            gm.Sp+=1;
        }
    }
}
