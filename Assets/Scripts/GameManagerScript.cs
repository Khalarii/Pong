using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    [SerializeField]
    BallScript ball;

    int playerLeftScore, playerRightScore;

    [SerializeField]
    Text score;

	// Use this for initialization
	void Start () {
        playerLeftScore = 0;
        playerRightScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
	}

    public void GoalScored(int playerNumber)
    {
        if (playerNumber == 1)
        {
            playerLeftScore++;
            if (playerLeftScore == 3)
            {
                GameOver();
            }
        }
        else if (playerNumber == 2)
        {
            playerRightScore++;
            if (playerRightScore == 3)
            {
                GameOver();
            }
        }

        ball.Reset(playerNumber);
    }

    void UpdateScore()
    {
        score.text = string.Format("({0}) {1} - {2} ({3})", "Player1", playerLeftScore, playerRightScore, "Player2");
    }

    void GameOver()
    {
        playerLeftScore = 0;
        playerRightScore = 0;
    }
}