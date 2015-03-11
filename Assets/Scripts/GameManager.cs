using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int targetScore = 10;
	public Text p1ScoreUI;
	public Text p2ScoreUI;
	public Text winnerUI;
	public Text fpsUI;

	private int _p1Score = 0;
	private int _p2Score = 0;
	private static bool _gameEnd = false;

	// Use this for initialization
	void Start () {
		winnerUI.enabled = false;
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		// Game state check
		if (_gameEnd) {
			if (Input.GetKey(KeyCode.Escape)) {
				_gameEnd = false;
				ResetScore();
				Application.LoadLevel("MainLevel");
			}
			else 
				return;
		}

		p1ScoreUI.text = _p1Score.ToString ();
		p2ScoreUI.text = _p2Score.ToString ();

		if (_p1Score >= targetScore) {
			_p1Score = targetScore;
			Win ("P1");
		}
		else if (_p2Score >= targetScore) {
			_p2Score = targetScore;
			Win ("P2");
		}

		int fps = (int)(1 / Time.deltaTime);
		fpsUI.text = fps.ToString ();
	}

	void Score ( string player ) {
		if (player == "P1")
			_p2Score++;
		else if (player == "P2")
			_p1Score++;
	}

	void Win( string player ) {
		Time.timeScale = 0.0f;
		winnerUI.text = player + " Wins!\nPress Esc to Play Again.";
		winnerUI.enabled = true;
		_gameEnd = true;

	}

	void ResetScore() {
		_p1Score = 0;
		_p2Score = 0;
	}

	public static bool GameOver(){
		return _gameEnd;
	}

}
