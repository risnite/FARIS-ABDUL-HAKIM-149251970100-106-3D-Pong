using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    // Players' points
    public Text player1Point;
    public Text player2Point;
    public Text player3Point;
    public Text player4Point;

    // Point manager
    public PointManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1Point.text = manager.player1Point.ToString();
        player2Point.text = manager.player2Point.ToString();
        player3Point.text = manager.player3Point.ToString();
        player4Point.text = manager.player4Point.ToString();
    }
}
