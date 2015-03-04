using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float force = 5f;
	public KeyCode up;
	public KeyCode down;
	public KeyCode fire;
	public GameObject bullet;


	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {



	}


	void FixedUpdate () {
		
		// Movement

		if (Input.GetKey ("up"))
			rigidbody2D.AddForce( new Vector2(0, force) );
		else if (Input.GetKey ("down"))
			rigidbody2D.AddForce( new Vector2(0, -1*force) );


		// Attacking
		//bullet.GetComponent<SpriteRenderer> ().color = new Color (255f, 0f, 0f);


	}
}
