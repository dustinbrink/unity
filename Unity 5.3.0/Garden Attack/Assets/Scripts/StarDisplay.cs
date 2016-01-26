using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE}
	public int stars = 100;
	private Text text;

	// Use this for initialization
	void Start () {
		stars += 50 * (2 - (int)PlayerPrefsManager.GetDifficulty());
		text = GetComponent<Text>();
		Redraw();
	}

	public Status UpdateStars ( int amt ) {
		if ( stars + amt >= 0 ) {
			stars += amt;
			Redraw();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	void Redraw () {
		text.text = stars.ToString();
	}
}
