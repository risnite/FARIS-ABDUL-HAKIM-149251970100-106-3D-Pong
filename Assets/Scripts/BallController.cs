using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public BallManager ballManager;
    public PointManager pointManager;
    public Collider goalPlayer1;
    public Collider goalPlayer2;
    public Collider goalPlayer3;
    public Collider goalPlayer4;

    // Goal
    public void OnTriggerEnter(Collider collision)
    {
        if (collision == goalPlayer1)
        {
            pointManager.AddPlayer1Point(1);
        }
        else if (collision == goalPlayer2)
        {
            pointManager.AddPlayer2Point(1);

        }
        else if (collision == goalPlayer3)
        {
            pointManager.AddPlayer3Point(1);

        }
        else if (collision == goalPlayer4)
        {
            pointManager.AddPlayer4Point(1);
        }
        ballManager.RemoveBall(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
