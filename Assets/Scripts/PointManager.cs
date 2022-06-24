using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
    // Winner
    private List<string> winners = new List<string>();
        
    // Players' bet
    public GameObject betPlayer1;
    public GameObject betPlayer2;
    public GameObject betPlayer3;
    public GameObject betPlayer4;

    // Players' goal
    public GameObject goalPlayer1;
    public GameObject goalPlayer2;
    public GameObject goalPlayer3;
    public GameObject goalPlayer4;

    // Get ball for reset position
    public BallController ball;

    // Number of player left
    private int playerLeft = 4;

    // Poin for players
    public int player1Point;
    public int player2Point;
    public int player3Point;
    public int player4Point;

    // Poin for elimination
    public int eliminationPoint;

    // Adding score
    public void AddPlayer1Point(int increment)
    {
        player1Point += increment;
        if(player1Point >= eliminationPoint)
        {
            EliminatePlayer(betPlayer1);
            playerLeft -= 1;
            // Change goal to wall
            AddWall(goalPlayer1);
            winners.Remove("Player 1");
        }
    }
    public void AddPlayer2Point(int increment)
    {
        player2Point += increment;
        if (player2Point >= eliminationPoint)
        {
            EliminatePlayer(betPlayer2);
            playerLeft -= 1;
            AddWall(goalPlayer2);
            winners.Remove("Player 2");
        }
    }
    public void AddPlayer3Point(int increment)
    {
        player3Point += increment;
        if (player3Point >= eliminationPoint)
        {
            EliminatePlayer(betPlayer3);
            playerLeft -= 1;
            AddWall(goalPlayer3);
            winners.Remove("Player 3");
        }
    }
    public void AddPlayer4Point(int increment)
    {
        player4Point += increment;
        //ball.ResetBall();
        if (player4Point >= eliminationPoint)
        {
            EliminatePlayer(betPlayer4);
            playerLeft -= 1;
            AddWall(goalPlayer4);
            winners.Remove("Player 4");
        }
    }

    // Eliminate players
    public void EliminatePlayer(GameObject gameObject)
    {
        // Remove player
        Destroy(gameObject);
    }

    // Add wall
    public void AddWall(GameObject gameObject)
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    // End game
    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    // Start is called before the first frame update
    void Start()
    {
        winners.Add("Player 1");
        winners.Add("Player 2");
        winners.Add("Player 3");
        winners.Add("Player 4");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLeft <= 1)
        {
            DeclareWinnerController.winner = winners[0].ToString();
            GameOver();
        }
    }
}
