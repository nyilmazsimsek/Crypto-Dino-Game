using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public float jumpForce;
    private Rigidbody2D rb;
    public float score;
    public float bestScore;
   
    public bool isGrounded;
    public bool isAlive;

    private void Awake()
    {
        Instance = this;
        isAlive = true;
        isGrounded = false;
        score = 0;
        rb = GetComponent<Rigidbody2D>();
        bestScore = PlayerPrefs.GetFloat("BestScore"); 
    }

    void Update()
    {
    
        if (isAlive && GameManager.Instance.isGameStarted && !GameManager.Instance.isGamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    rb.AddForce(Vector2.up * jumpForce);
                    isGrounded = false;
                }
            }
            score += Time.deltaTime * 4;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (col.gameObject.CompareTag("Obstacle"))
        {
            isAlive = false;
            GameManager.Instance.isGameStarted = false;
            if (bestScore<score)
            {
                PlayerPrefs.SetFloat("BestScore", score);
            }
        }
    }
}
