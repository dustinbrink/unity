using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PinCounter : MonoBehaviour {

	public Text text;

	private GameManager gameManager;
	private float lastChangeTime;
	private int lastStandingCount;
	private float settleThreshold = 3f;
	private int standingCount = -1;
	private int startingPinCount = 10;
	private bool ballOutOfPlay = false;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
		Reset();
	}

	// Update is called once per frame
	void Update () {
		if ( ballOutOfPlay ) {
			CheckStanding();
		}
	}

	public void Reset () {
		lastStandingCount = startingPinCount;
		UpdateCountText( lastStandingCount );
	}

	void CheckStanding () {
		int count = CountStanding();

		if ( count == standingCount ) {

			if ( Time.time - lastChangeTime > settleThreshold ) {
				PinsHaveSettled();
			}

		} else {
			standingCount = count;
			lastChangeTime = Time.time;
		}
	}

	void PinsHaveSettled () {
		int pinsFallen = lastStandingCount - standingCount;
		UpdateCountText( standingCount );
		lastStandingCount = standingCount;
		standingCount = -1;
		ballOutOfPlay = false;
		gameManager.Bowl( pinsFallen );
	}

	void UpdateCountText (int count) {
		text.text = count.ToString();
	}

	int CountStanding () {
		int count = 0;

		foreach ( Pin pin in FindObjectsOfType<Pin>() ) {

			if ( pin.IsStanding() ) {
				count++;
			}
		}

		return count;
	}

	void OnTriggerExit ( Collider collider ) {
		GameObject thing = collider.gameObject;

		if ( thing.GetComponent<Ball>() ) {
			ballOutOfPlay = true;

		}
	}
}
