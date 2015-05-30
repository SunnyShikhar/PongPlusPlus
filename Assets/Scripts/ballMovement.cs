using UnityEngine;
using System.Collections;

public class ballMovement : MonoBehaviour {


	public float speed = 30;
	Vector2 launchPoint;

	// Use this for initialization
	void Start () {

		//initialposition
		launchPoint = this.transform.position;

		//Initial velocity
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
	}

	void OnCollisionEnter2D(Collision2D col) {

		//if collision on vertical walls
		if (col.gameObject.name == "leftWall" || col.gameObject.name == "rightWall")
		{
			resetPosition();
		}

		// Hit the left Racket?
		if (col.gameObject.name == "paddleLeft") {
			// Calculate hit Factor
			float y = hitFactor (transform.position,
			                    col.transform.position,
			                    col.collider.bounds.size.y);
			
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2 (1, y).normalized;
			
			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}
		
		// Hit the right Racket?
		if (col.gameObject.name == "paddleRight") {
			// Calculate hit Factor
			float y = hitFactor (transform.position,
			                    col.transform.position,
			                    col.collider.bounds.size.y);
			
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2 (-1, y).normalized;
			
			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}
	}

	float hitFactor (Vector2 ballPos, Vector2 racketPos, float racketHeight)
	{
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void resetPosition ()
	{
		this.transform.position = launchPoint;

	}

	// Update is called at the same rate as physics engine
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.R)) {
			resetPosition();
		}

	}
}
