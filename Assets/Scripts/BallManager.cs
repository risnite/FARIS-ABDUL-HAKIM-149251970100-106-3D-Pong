using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private int randomVectorPositive;
    private int randomVectorNegative;

    //Initial ball speed
    private Vector3 initialBallSpeed = new Vector3(0f, 0f, -3f);

    // Spawn Area
    public Transform spawnArea;

    // Ball list
    private List<GameObject> ballList;

    // Ball speed
    private Vector3 spawnSpeed;

    // 
    public GameObject bola;

    // Ball spawn
    public int spawnInterval; //interval
    private float timer; //timer

    // Ball spawn position list
    private static Vector3 spawner1 = new Vector3(3.95f, 0.3f, -3.95f); //Kanan bawah
    private static Vector3 spawner2 = new Vector3(-3.95f, 0.3f, -3.95f); //Kiri bawah
    private static Vector3 spawner3 = new Vector3(-3.95f, 0.3f, 3.95f); //Kiri atas
    private static Vector3 spawner4 = new Vector3(3.95f, 0.3f, 3.95f); //Kanan atas
    private List<Vector3> spawnList = new List<Vector3>() { spawner1, spawner2, spawner3, spawner4 };
    private int randomIndex;

    // Set max ball amount
    public int maxBallAmount;

    // Spawn ball
    public void SpawnBall()
    {
        randomIndex = Random.Range(0, spawnList.Count);
        SpawnBall(spawnList[randomIndex]);
    }

    // Spawn mechanism
    public void SpawnBall(Vector3 position)
    {
        randomVectorPositive = Random.Range(2, 4);
        randomVectorNegative = Random.Range(-4, -2);
        if (ballList.Count >= maxBallAmount)
        {
            return;
        }

        if (randomIndex == 0) //Kanan bawah
        {
            spawnSpeed = new Vector3(randomVectorNegative, 0, randomVectorPositive); //Kiri atas
        }
        else if (randomIndex == 1) //Kiri bawah
        {
            spawnSpeed = new Vector3(randomVectorPositive, 0, randomVectorPositive); //Kanan atas

        }
        else if (randomIndex == 2) //Kiri atas
        {
            spawnSpeed = new Vector3(randomVectorPositive, 0, randomVectorNegative); //Kanan bawah
        }
        else if (randomIndex == 3) //Kanan atas
        {
            spawnSpeed = new Vector3(randomVectorNegative, 0, randomVectorNegative); //Kiri bawah
        }
        if (spawnSpeed.x == spawnSpeed.z ||
            spawnSpeed.x == spawnSpeed.z * -1)
        {
            return;
        }
        GameObject ball = Instantiate(bola, spawnList[randomIndex], Quaternion.identity, spawnArea);
        ball.SetActive(true);
        ball.GetComponent<Rigidbody>().velocity = spawnSpeed;
        ballList.Add(ball);
    }

    // Remove ball
    public void RemoveBall(GameObject ball)
    {
        ballList.Remove(ball);
        Destroy(ball);
    }

    // Remove all ball
    public void RemoveAllBall()
    {
        while (ballList.Count > 0)
        {
            RemoveBall(ballList[0]);
        }
    }

   public void InitiateBall()
    {
        GameObject ball = Instantiate(bola, new Vector3(0, 0, 0), Quaternion.identity, spawnArea);
        ball.SetActive(true);
        ball.GetComponent<Rigidbody>().velocity = initialBallSpeed;
        ballList.Add(ball);
    }

    // Start is called before the first frame update
    void Start()
    {
        ballList = new List<GameObject>();
        timer = 0;
        //InitiateBall();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            SpawnBall();
            timer -= spawnInterval;
        }
    }
}
