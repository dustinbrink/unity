using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int startMax = 1000;
	int startMin = 1;
	int startGuess = 500;
	int startMaxGuess = 10;
	int maxGuess;
	int max;
	int min;
	int guess;
	
	public Text guessText;

	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame () {
		max = startMax;
		min = startMin;
		maxGuess = startMaxGuess;
		max = max + 1;
		guess = Random.Range( min, max );
		updateGuess();
	}
	
	// Update is called once per frame
	void Update () {
		if 		( Input.GetKeyDown ( KeyCode.UpArrow ) )	{ GuessHigher(); }
		else if ( Input.GetKeyDown ( KeyCode.DownArrow ) )	{ GuessLower(); }
	}
	
	public void GuessHigher() {
		min = guess;
		NextGuess();
	}
	
	public void GuessLower() {
		max = guess;
		NextGuess();
	}
	
	void NextGuess() {
		
		if ( maxGuess % 3  == 0 ) {
			guess = Random.Range( min, max );
		} else {
			guess = (max + min) / 2;
		}
		
		maxGuess--;
		
		if ( maxGuess <= 0 ) {
			Application.LoadLevel( "Win" );
		} else {
			updateGuess();
		}
	}
	
	void updateGuess() {
		guessText.text = "Is your number " + guess + "?";
	}
}
