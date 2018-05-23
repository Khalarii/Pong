using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    [SerializeField]
    BallScript ball;

    int playerLeftScore, playerRightScore;

    [SerializeField]
    Text score;

    [SerializeField]
    Button continuteButton;

    [SerializeField]
    Button exitButton;

    bool paused;

    Vector2 ballSpeed;

	// Use this for initialization
	void Start () {
        continuteButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        playerLeftScore = 0;
        playerRightScore = 0;

        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused && Input.GetKey(KeyCode.Escape))
        {
            PlayPause();
        }
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

        UpdateScore();
        ball.Reset(playerNumber);
    }

    public void PlayPause()
    {
        if (!paused)
        {
            ballSpeed = new Vector2(ball.mainBody.velocity.x, ball.mainBody.velocity.y);
            ball.mainBody.velocity = new Vector2(0, 0);

            continuteButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
        }
        else
        {
            continuteButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);

            ball.mainBody.AddForce(ballSpeed);
        }
        paused = !paused;
    }

    void UpdateScore()
    {
        score.text = string.Format("\n({0}) {1} - {2} ({3})", "PLAYER1", playerLeftScore, playerRightScore, "PLAYER2");
    }

    void GameOver()
    {
        playerLeftScore = 0;
        playerRightScore = 0;
    }
}