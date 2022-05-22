using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;

    public float maxSpeed;
    public float minSpeed;
    public float currentSpeed;

    public float speedMultiplier;
    void Awake()
    {
        currentSpeed = minSpeed ;
        generateObstacle();
    }

    public void getRandomizedObstacle()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateObstacle", randomWait);
    }

    void generateObstacle()
    {
        GameObject obstacleIns = Instantiate(obstacle, transform.position, transform.rotation);
        obstacleIns.GetComponent<ObstacleMovement>().obstacleGenerator = this; 
    }


    void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedMultiplier;
        }   
    }
}
