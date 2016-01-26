using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score;

	private Text text;

	void Start () {
		this.text = this.GetComponent<Text>();
		Reset();
	}
	
	public void Score ( int points ) {
		score += points;
		this.text.text = score.ToString();
	}
	
	public static void Reset () {
		score = 0;
	}
}
