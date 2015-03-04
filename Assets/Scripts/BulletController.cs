using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private GameObject _GM;

	// Use this for initialization
	void Start () {
		_GM = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		if ( Mathf.Abs(transform.position.x) > 10f || Mathf.Abs(transform.position.y) > 10f )
			Destroy (gameObject);
	}

	void OnTriggerEnter2D ( Collider2D collider ) {
		if (collider.tag == "Player") {
			Destroy (gameObject);
			_GM.SendMessage ("Score", collider.name);
		} 
		else if (collider.tag == "ChargeShot") {
			Destroy (gameObject);
		}
	}
	
}
