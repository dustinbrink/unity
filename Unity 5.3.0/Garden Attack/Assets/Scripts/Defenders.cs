using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	[Range(0f, 300f)]
	public int starCost = 0;
	[Range(0f, 100f)]
	public int starAmt = 25;

	private StarDisplay starDisplay;
	private Animator anim;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		anim = GetComponent<Animator>();
	}

	public void spawnStar () {
		starDisplay.UpdateStars( starAmt );
	}

	public void UnderAttack () {
		anim.SetTrigger( "underAttack Trigger" );
	}
}
