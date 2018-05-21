using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    [SerializeField]
    float forceValue = 100.0f;

    Rigidbody2D mainBody;

	// Use this for initialization
	void Start () {
        mainBody = GetComponent<Rigidbody2D>();
        mainBody.AddForce(new Vector2(forceValue * 10, 50));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ForceStart(int playerScored)
    {
        if (playerScored == 1)
        {
            mainBody = GetComponent<Rigidbody2D>();
            mainBody.AddForce(new Vector2(forceValue * -10, 50));
        }
        else
        {
            mainBody = GetComponent<Rigidbody2D>();
            mainBody.AddForce(new Vector2(forceValue * 10, 50));
        }
    }

    public void Reset(int playerScored)
    {
        mainBody.velocity = Vector2.zero;
        transform.position = new Vector2(0, 0);
        ForceStart(playerScored);
    }
}
