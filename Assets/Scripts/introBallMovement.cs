using UnityEngine;
using System.Collections;

public class introBallMovement : MonoBehaviour {

	public float speed = 10;
	public float xDirection = 1.0f;
	public float yDirection = 1.0f;
	Vector2 startpoint;
	Vector2 initDirection;


	// Use this for initialization
	void Start () {
		//set starting point of the ball
		startpoint = this.transform.position;
		initDirection = new Vector2(xDirection,yDirection);

		//Initial Velocity
		GetComponent<Rigidbody2D> ().velocity = initDirection * speed;
	}

	void OnCollisionEnter2D(Collision2D col) {
		
		//if collision on horizantal walls reset back to initial position
		if (col.gameObject.name == "topwall" || col.gameObject.name == "botwall") {
			resetPosition ();
		}

		//When the ball hits paddle, reflect the x direction
		//Then perserve initial x direction for reset
		if (col.gameObject.name == "Paddle") {

			initDirection.x = -initDirection.x;
			GetComponent<Rigidbody2D> ().velocity = initDirection * speed;
			initDirection.x = -initDirection.x;
		}

	}
	void resetPosition ()
	{
		this.transform.position = startpoint;
		GetComponent<Rigidbody2D> ().velocity = initDirection * speed;

	}
	float hitFactor (Vector2 ballPos, Vector2 racketPos, float racketHeight)
	{
		return (ballPos.y - racketPos.y) / racketHeight;
	}


}
