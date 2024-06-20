using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float rotationAmount;
    public float upwardForce;
    public bool started;
    public bool gameOver;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        started = false;
        gameOver = false;
    }

    void Update()
    {
        if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.isKinematic = false;
                GameManager.instance.GameStart();
            }
        }
        else
        {
            if(!gameOver)
            {
                transform.Rotate(0, 0, rotationAmount);
                if (Input.GetMouseButtonDown(0))
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector3.up * upwardForce, ForceMode2D.Impulse);
                }
            }
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver = true;
        GameManager.instance.GameOver();
        GetComponent<Animator>().Play("Ball");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pipe" && !gameOver)
        {
            gameOver = true;
            GameManager.instance.GameOver();
            GetComponent<Animator>().Play("Ball");
        }
        if (collision.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            ScoreManager.instance.IncrementScore();
            Debug.Log("Score");
        }
       
    }
}
