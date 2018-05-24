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
    Button[] pauseButtons;

    [SerializeField]
    Button continueButton;

    [SerializeField]
    Button exitButton;

    bool paused;

    Vector2 ballSpeed;

	// Use this for initialization
	void Start () {
        playerLeftScore = 0;
        playerRightScore = 0;

        paused = false;

        pauseButtons = UnityEngine.UI.Button.FindObjectsOfType<Button>();

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
        if (!paused)
        {
            int multiplier = 50;

            ballSpeed = new Vector2(ball.mainBody.velocity.x * multiplier, ball.mainBody.velocity.y * multiplier);
            ball.mainBody.velocity = new Vector2(0, 0);
        }
        else
        {
            //continueButton.gameObject.SetActive(false);
            //exitButton.gameObject.SetActive(false);
            ball.mainBody.AddForce(ballSpeed);
        }
        paused = !paused;
        UpdateButtons();
    }

    void UpdateButtons()
    {
        foreach (Button b in pauseButtons.Where(but => but.transform.name != "PauseButton"))
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