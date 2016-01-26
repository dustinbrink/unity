using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	// Use this for initialization
	void Start () {
		int score = PlayerPrefsManager.GetScore();
		int highScore = PlayerPrefsManager.GetHighScore();

		scoreText.text = score.ToString();

		if ( score > highScore ) {
			PlayerPrefsManager.SetHighScore( score );
			highScoreText.text = "New High Score!!";
		} else {
			highScoreText.text = "High Score " + highScore;
		}
	}
}
