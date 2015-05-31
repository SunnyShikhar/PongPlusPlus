using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GameObject camera;
	public int speed = 1;
	public int waitTime = 15;
	public int level = -1;
	float startTime = 0;
	// Update is called once per frame
	void Update () {

		camera.transform.Translate (Vector3.down * Time.deltaTime * speed);
		Debug.Log (Time.time - startTime);
		if (Time.time - startTime >= waitTime) {
			Application.LoadLevel(level);
		}
	}

	void Start(){
		startTime = Time.time;
	}
}
