using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	// Use this for initialization
	void Start () {
		foreach ( Text text in rollTexts ) {
			text.text = "";
		}

		foreach ( Text text in frameTexts ) {
			text.text = "";
		}
	}

	public void FillRollCard ( List<int> rolls ) {
		FillRolls( rolls );
		FillFrames( rolls );
	}

	void FillRolls ( List<int> rolls ) {
		string rollScores = ScoreMaster.FormatRolls( rolls );
		for ( var i = 0; i < rollScores.Length; i++ ) {
			rollTexts[ i ].text = rollScores[ i ].ToString();
		}
	}

	void FillFrames ( List<int> rolls ) {
		List<int> frameScores = ScoreMaster.ScoreCumulative( rolls );
		for ( var i = 0; i < frameScores.Count; i++ ) {
			frameTexts[ i ].text = frameScores[ i ].ToString();
		}
	}
}
