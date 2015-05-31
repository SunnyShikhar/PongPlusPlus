using UnityEngine;
using System.Collections;

public class ballMovement : MonoBehaviour {


	public float speed = 30;
	Vector2 launchPoint;

	public GUIText leftScoreText = null;
	public GUIText rightScoreText = null;

	int rightscore = 0;
	int leftscore= 0;


	Vector2 reset = new Vector2(0,0);
	

	// Use this for initialization
	void Start () {

		//initialposition
		launchPoint = this.transform.position;

		//Initial velocity
		reset = Vector2.right * speed;
		GetComponent<Rigidbody2D> ().velocity = reset;



	}


	void OnCollisionEnter2D(Collision2D col) {

		//if collision on vertical walls
		if (col.gameObject.name == "leftWall")
		{
			GetComponent<Rigidbody2D>().velocity = reset;
			rightscore = rightscore + 1;
			UpdateScore();
			this.transform.position = launchPoint;
		}

		if (col.gameObject.name == "rightWall") {

			GetComponent<Rigidbody2D>().velocity = reset;
			leftscore = leftscore + 1;
			UpdateScore();
			this.transform.position = launchPoint;
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
		leftscore = 0;
		rightscore = 0;
		UpdateScore ();
	}

	// Update is called at the same rate as physics engine
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.R)) {
			resetPosition();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel (0);
		}

	}

	void UpdateScore()
	{
		leftScoreText.text = " " + leftscore;
		rightScoreText.text = " " + rightscore;
	}
}
