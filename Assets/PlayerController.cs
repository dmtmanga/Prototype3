using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float force = 5f;
	public KeyCode up;
	public KeyCode down;
	public KeyCode fire;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Movement
		if (Input.GetKey ("up")) {
			rigidbody2D.AddForce( new Vector2(0, force) );
		}
		else if (Input.GetKey ("down")) {
			rigidbody2D.AddForce( new Vector2(0, -1*force) );
		}

	}
}
