using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float force = 5f;
	public float shotSpeed = 5f;
	public KeyCode up;
	public KeyCode down;
	public KeyCode shoot;
	public GameObject bulletPrefab;


	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {

		// Attacking
		//bullet.GetComponent<SpriteRenderer> ().color = new Color (255f, 0f, 0f);
		GameObject bullet;
		Vector3 bulletPos;
		if (Input.GetKeyDown(shoot)){
			if (name == "P1"){
				bulletPos = new Vector3(transform.position.x + 0.3f, transform.position.y, 0f);
				bullet = (GameObject) Instantiate(bulletPrefab, bulletPos, new Quaternion());
				bullet.rigidbody2D.velocity = new Vector2(shotSpeed, 0f);
			}
			else if (name == "P2"){
				bulletPos = new Vector3(transform.position.x - 0.3f, transform.position.y, 0f);
				bullet = (GameObject) Instantiate(bulletPrefab, bulletPos, new Quaternion());
				bullet.rigidbody2D.velocity = new Vector2(-1*shotSpeed, 0f);
			}
		}
	}


	void FixedUpdate () {
		
		// Movement
		if (Input.GetKey (up))
			rigidbody2D.AddForce( new Vector2(0, force) );
		else if (Input.GetKey (down))
			rigidbody2D.AddForce( new Vector2(0, -1*force) );

	}

	
	void ChargeShot(){

	}

}
