using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    [SerializeField]
    int attackingPlayer;

    [SerializeField]
    GameManagerScript gameMan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Ball")
        {
            gameMan.GoalScored(attackingPlayer);
        }
    }
}
