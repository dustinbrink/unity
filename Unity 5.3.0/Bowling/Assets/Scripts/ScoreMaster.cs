using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster {

	// return a list of individual frame scores
	public static List<int> ScoreFrames ( List<int> rolls ) {
		List<int> frameScores = new List<int>();

		for ( int i = 1; i < rolls.Count && frameScores.Count < 10; i += 2 ) {
			int score = rolls[ i ] + rolls[ i - 1 ];

			if ( score < 10 ) { // Normal Open frame
				frameScores.Add( score );
			} else { // Strike or Spare

				if ( rolls.Count > i + 1 ) {  // Can calc
					frameScores.Add( score + rolls[ i + 1 ] );
				}

				if ( rolls[ i - 1 ] == 10 ) { // Strike
					i--; // Only Jump ahead one bowl
				}
			}
		}

		return frameScores;
	}

	// returns a list of cumulative scores like a normal score card
	public static List<int> ScoreCumulative ( List<int> rolls ) {
		List<int> cumulativeScores = new List<int>();
		int score = 0;

		foreach ( int frameScore in ScoreFrames( rolls ) ) {
			score += frameScore;
			cumulativeScores.Add( score );
		}

		return cumulativeScores;
	}

	public static string FormatRolls ( List<int> rolls ) {
		string score = "";

		for ( int i = 0; i < rolls.Count; i++ ) {
			int roll = rolls[ i ]; // Default score to digit

			if ( roll == 0 ) { // Gutter ball
				score += "-";
			} else if ( score.Length % 2 != 0 && roll + rolls[ i - 1 ] == 10 ) { // Spare 
				score += "/";
			} else if ( score.Length > 17 && roll == 10 ) { // Last frame strikes
				score += "X";
			} else if ( roll == 10 ) { // Strike
				score += " X"; // Add empty space before strike
			} else {
				score += roll.ToString();
			}
		}

		return score;
	}

	public static int TotalScore ( List<int> rolls ) {
		List<int> scores = ScoreCumulative( rolls );
		return scores[ scores.Count - 1 ];
	}
}
