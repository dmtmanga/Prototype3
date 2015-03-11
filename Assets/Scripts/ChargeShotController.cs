using UnityEngine;
using System.Collections;

public class ChargeShotController : MonoBehaviour {

	public float homingForce;

	private GameObject _GM;
	private GameObject _otherPlayer;


	
	// Use this for initialization
	void Start () {
		_GM = GameObject.FindGameObjectWithTag ("GameController");

		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject player in players){
			if (player.name != transform.parent.name){
				_otherPlayer = player;
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Game state check
		if (GameManager.GameOver())
			return;

		if (Mathf.Abs(transform.position.x) > 10f || Mathf.Abs(transform.position.y) > 10f)
			Destroy (gameObject);


		// Slight Homing
		if (_otherPlayer.transform.position.y > transform.position.y)
			rigidbody2D.AddForce (new Vector2 (0f, homingForce));
		else if (_otherPlayer.transform.position.y < transform.position.y)
			rigidbody2D.AddForce (new Vector2 (0f, -1 * homingForce));
	}
	
	void OnTriggerEnter2D ( Collider2D collider ) {
		if (collider.tag == "Player" && transform.parent == null){
			//Debug.Log("collider name: " + collider.name + " parent name: " + transform.parent.name);
			Destroy (gameObject);
			_GM.SendMessage("Score", collider.name);
		}
	}
}
