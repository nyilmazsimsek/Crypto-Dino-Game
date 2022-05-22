using System;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public ObstacleGenerator obstacleGenerator;

    void Update()
    {
        transform.Translate(Vector2.left * obstacleGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("NextLine"))
        {
            obstacleGenerator.getRandomizedObstacle();
        }

        if (col.gameObject.CompareTag("FinishLine"))
        {
            Destroy(this.gameObject );
        }
    }
}
