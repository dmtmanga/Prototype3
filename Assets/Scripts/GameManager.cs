using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Text p1ScoreUI;
	public Text p2ScoreUI;

	private int _p1Score = 0;
	private int _p2Score = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		p1ScoreUI.text = _p1Score.ToString ();
		p2ScoreUI.text = _p2Score.ToString ();
	}

	void Score ( string player ) {
		if (player == "P1")
			_p2Score++;
		else if (player == "P2")
			_p1Score++;
	}

}
