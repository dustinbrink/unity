using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private Ball ball;
	private PinSetter pinSetter;
	private ScoreDisplay scoreDisplay;
	private List<int> rolls = new List<int>();

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Bowl ( int pins ) {
		try {
			rolls.Add( pins );
			PerformAction( ActionMaster.NextAction( rolls ) );
			scoreDisplay.FillRollCard( rolls );
			ball.Reset();
		} catch {
			Debug.LogError( "Something went wrong in game loop" );
		}
	}

	void PerformAction (ActionMaster.Action action) {
		// Debug.Log( action );

		switch ( action ) {
			case ActionMaster.Action.Tidy:
				pinSetter.ActionTidy();
				break;
			case ActionMaster.Action.Reset:
			case ActionMaster.Action.EndTurn:
				pinSetter.ActionReset();
				break;
			case ActionMaster.Action.EndGame:
				EndGame();
				break;
		}
	}

	void EndGame () {
		PlayerPrefsManager.SetScore( ScoreMaster.TotalScore( rolls ) );
		LevelManager levelManager = FindObjectOfType<LevelManager>();
		levelManager.AutoloadNext( 3f );
	}
}
