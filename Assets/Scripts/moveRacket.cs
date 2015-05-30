using UnityEngine;
using System.Collections;

public class moveRacket : MonoBehaviour {

	public float speed = 30;
	public string axis = "Vertical";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called at the same rate physics engine works 
	void FixedUpdate () {
		float dir = Input.GetAxisRaw (axis);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, dir) * speed;
	
	}
}
