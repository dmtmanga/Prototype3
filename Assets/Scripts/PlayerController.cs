using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float force = 5f;
	public float shotSpeed = 10f;
	public float chargeShotSpeed = 4f;
	public float chargeTime = 3f;
	// Keys
	public KeyCode up;
	public KeyCode down;
	public KeyCode shoot;
	// References
	public GameObject bulletPrefab;
	public GameObject chargeShotPrefab;

	private GameObject _bullet;
	private bool _charged = false;
	private bool _charging = false;
	private float _timeCharged = 0f;


	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		// Attacking
		Vector3 bulletPos;

		if (Input.GetKeyDown(shoot)){
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
		else if (Input.GetKey (shoot)) {
			_charged = ChargeShot();
			if(_charged){
				foreach (Transform child in transform)
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
			else if (_charging) {
				if(transform.childCount == 0){
					if (name == "P1"){
						bulletPos = new Vector3(transform.position.x + 0.5f, transform.position.y, 0f);
						_bullet = (GameObject) Instantiate(bulletPrefab, bulletPos, new Quaternion());
						_bullet.transform.parent = transform;
						_bullet.GetComponent<SpriteRenderer>().color = new Color (0f, 255f, 0f);
					}
					else if (name == "P2"){
						bulletPos = new Vector3(transform.position.x - 0.5f, transform.position.y, 0f);
						_bullet = (GameObject) Instantiate(bulletPrefab, bulletPos, new Quaternion());
						_bullet.transform.parent = transform;
						_bullet.GetComponent<SpriteRenderer>().color = new Color (0f, 255f, 0f);
					}
				}
			}
		}

		else if (Input.GetKeyUp (shoot)) {
			if (_charged){
				if (name == "P1"){
					_bullet.rigidbody2D.velocity = new Vector2(chargeShotSpeed, 0f);
				}
				else if (name == "P2"){
					_bullet.rigidbody2D.velocity = new Vector2(-1*chargeShotSpeed, 0f);
				}
				_charged = false;
			}
			else if(_charging) {
				foreach (Transform child in transform)
					Destroy(child.gameObject);
				if ( _timeCharged >= chargeTime/2){
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
			_timeCharged = 0f;
		}
	}


	void FixedUpdate () {
		// Movement
		if (Input.GetKey (up))
			rigidbody2D.AddForce( new Vector2(0, force) );
		else if (Input.GetKey (down))
			rigidbody2D.AddForce( new Vector2(0, -1*force) );
	}

	
	bool ChargeShot(){
		if (!_charging) {
			_charging = true;
		}
		_timeCharged += Time.deltaTime;
		return (_timeCharged >= chargeTime);
	}

}
