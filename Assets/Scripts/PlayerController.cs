using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 6f;
	public float friction = 0.03f;
	public float shotSpeed = 12f;
	public float chargeShotSpeed = 5f;
	public float chargeTime = 1.2f; // time required to reach full charge
	public float maxChargedTime = 3f; // max time player can hold charge
	// Keys
	public KeyCode up;
	public KeyCode down;
	public KeyCode shoot;
	// References
	public GameObject bulletPrefab;
	public GameObject chargeShotPrefab;
	public GameObject particles;

	private GameObject _bullet;
	private bool _charged = false;
	private bool _charging = false;
	private float _timeCharging = 0f;  // time spent charging
	//private float _timeCharged = 0f; // time spent holding a charge


	// Use this for initialization
	void Start () {
		particles.particleSystem.enableEmission = false;
	}
	
	void Update () {

		// Game state check
		if (GameManager.GameOver())
			return;

		// Attacking
		Vector3 bulletPos;
		
		particles.particleSystem.enableEmission = (_charging && _timeCharging >= chargeTime/3);

		if (Input.GetKeyDown(shoot)){
			if (name == "P1"){
				bulletPos = new Vector3(transform.position.x + 0.5f, transform.position.y, 0f);
				_bullet = (GameObject) Instantiate(bulletPrefab, bulletPos, new Quaternion());
				_bullet.rigidbody2D.velocity = new Vector2(shotSpeed, 0f);
			}
			else if (name == "P2"){
				bulletPos = new Vector3(transform.position.x - 0.5f, transform.position.y, 0f);
				_bullet = (GameObject) Instantiate(bulletPrefab, bulletPos, new Quaternion());
				_bullet.rigidbody2D.velocity = new Vector2(-1*shotSpeed, 0f);
			}
		}
		else if (Input.GetKey (shoot)) {
			_charged = ChargeShot();
			if(_charged){
				foreach (Transform child in transform)
					if(child.tag != "Particles")
						Destroy(child.gameObject);
				if (name == "P1"){
					bulletPos = new Vector3(transform.position.x + 0.5f, transform.position.y, 0f);
					_bullet = (GameObject) Instantiate(chargeShotPrefab, bulletPos, new Quaternion());
					_bullet.transform.parent = transform;
				}
				else if (name == "P2"){
					bulletPos = new Vector3(transform.position.x - 0.5f, transform.position.y, 0f);
					_bullet = (GameObject) Instantiate(chargeShotPrefab, bulletPos, new Quaternion());
					_bullet.transform.parent = transform;
				}
			}
		}

		else if (Input.GetKeyUp (shoot)) {
			if (_charged){
				if (name == "P1"){
					_bullet.rigidbody2D.velocity = new Vector2(chargeShotSpeed, 0.8f *  rigidbody2D.velocity.y);
					_bullet.transform.parent = null;
				}
				else if (name == "P2"){
					_bullet.rigidbody2D.velocity = new Vector2(-1*chargeShotSpeed, 0.8f * rigidbody2D.velocity.y);	
					_bullet.transform.parent = null;
				}
				_charged = false;
				particles.particleSystem.enableEmission = false;
			}
			else if(_charging) {
				foreach (Transform child in transform)
					if(child.tag != "Particles")
						Destroy(child.gameObject);
				if ( _timeCharging >= chargeTime/2){
					if (name == "P1"){
						bulletPos = new Vector3(transform.position.x + 0.5f, transform.position.y, 0f);
						_bullet = (GameObject) Instantiate(bulletPrefab, bulletPos, new Quaternion());
						//bullet.transform.parent = transform;
						_bullet.rigidbody2D.velocity = new Vector2(shotSpeed, 0f);
					}
					else if (name == "P2"){
						bulletPos = new Vector3(transform.position.x - 0.5f, transform.position.y, 0f);
						_bullet = (GameObject) Instantiate(bulletPrefab, bulletPos, new Quaternion());
						//bullet.transform.parent = transform;
						_bullet.rigidbody2D.velocity = new Vector2(-1*shotSpeed, 0f);
					}
				}
			}
			_charging = false;
			_timeCharging = 0f;
			particles.particleSystem.enableEmission = false;
		}
	}


	void FixedUpdate () {
		// Game state check
		if (GameManager.GameOver())
			return;

		// Movement
		if (Input.GetKey (up))
			//rigidbody2D.AddForce( new Vector2(0, force) );
			rigidbody2D.velocity = new Vector2 (0, moveSpeed);
		else if (Input.GetKey (down))
			//rigidbody2D.AddForce( new Vector2(0, -1*force) );
			rigidbody2D.velocity = new Vector2 (0, -1 * moveSpeed);
		else
			rigidbody2D.velocity = rigidbody2D.velocity * (1 - friction);
	}

	
	bool ChargeShot(){
		if (!_charging) {
			_charging = true;
		}
		_timeCharging += Time.deltaTime;
		return (_timeCharging >= chargeTime);
	}

}
