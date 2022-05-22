using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float JumpForce;

    [SerializeField]
    private bool isGrounded = false;

    private Rigidbody2D rb;

    private float score;
    private bool isAlive = true;

    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            scoreText.text = "SCORE: " + Math.Floor(score).ToString();
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
            Time.timeScale = 0;
        }
    }
}
