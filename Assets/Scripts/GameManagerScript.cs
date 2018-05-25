using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    IEnumerable<Button> pauseButtons;

    //[SerializeField]
    //Button continueButton;

    //[SerializeField]
    //Button exitButton;

    bool paused;

    Vector2 ballSpeed;

    internal const int multiplier = 50;

	// Use this for initialization
	void Start () {
        playerLeftScore = 0;
        playerRightScore = 0;

        paused = false;

        pauseButtons = FindObjectsOfType<Button>().Where(b => b.transform.name != "PauseButton");

        UpdateButtons();
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
        paused = !paused;

        if (paused)
        {
            ballSpeed = new Vector2(ball.mainBody.velocity.x * multiplier, ball.mainBody.velocity.y * multiplier);
            ball.mainBody.velocity = new Vector2(0, 0);
        }
        else
        {
            ball.mainBody.AddForce(ballSpeed);
        }

        UpdateButtons();
    }

    void UpdateButtons()
    {
        foreach (Button b in pauseButtons)
        {
            b.gameObject.SetActive(paused);
        }
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