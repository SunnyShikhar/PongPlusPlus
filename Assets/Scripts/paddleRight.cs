using UnityEngine;
using System.Collections;

public class paddleRight : MonoBehaviour {

	public float speed = 30;
	public string axis = "Vertical";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float direction = Input.GetAxisRaw ("Vertical");
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, direction) * speed;
	}
}
