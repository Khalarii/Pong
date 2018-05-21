using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    [SerializeField]
    bool player2;

    [SerializeField]
    float baseSpeed = 0.3f;

    Transform myTransform;

    direction myDirection = direction.STILL;

    float previousY;

    enum direction
    {
        UP=1, DOWN=-1, STILL=0
    }

	// Use this for initialization
	void Start () {
        myTransform = transform;
        previousY = myTransform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveUp();
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                MoveDown();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                MoveUp();
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                MoveDown();
            }
        }

        if (previousY > myTransform.position.y)
        {
            myDirection = direction.UP;
        }
        else if (previousY < myTransform.position.y)
        {
            myDirection = direction.DOWN;
        }
        else
        {
            myDirection = direction.STILL;
        }
	}

    private void LateUpdate()
    {
        previousY = myTransform.position.y;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var velocity = collision.rigidbody.velocity;
        float adjust = 5 * (int)myDirection;
        collision.rigidbody.velocity = new Vector2(velocity.x, velocity.y + adjust);
    }

    void MoveUp()
    {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + baseSpeed);
    }

    void MoveDown()
    {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y - baseSpeed);
    }
}