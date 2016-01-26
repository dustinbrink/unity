using UnityEngine;

public class PinSetter : MonoBehaviour {

	public enum Action { Tidy, Reset }
	public GameObject pinSet;

	private Animator animator;
	private PinCounter pinCounter;
	private Ball ball;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		ball = GameObject.FindObjectOfType<Ball>();
	}

	public void ActionTidy () {
		animator.SetTrigger( "tidyTrigger" );
	}

	public void ActionReset () {
		animator.SetTrigger( "resetTrigger" );
		pinCounter.Reset();
	}

	public void RaisePins () {
		foreach ( Pin pin in FindObjectsOfType<Pin>() ) {
			pin.Raise();
		}
	}

	public void LowerPins () {
		foreach ( Pin pin in FindObjectsOfType<Pin>() ) {
			pin.Lower();
		}
		ball.Enable();
	}

	public void RenewPins () {
		Instantiate( pinSet, new Vector3( 0, Pin.distanceToRaise, 18.29f ), Quaternion.identity );
		RaisePins();
	}

	public static bool IsPinsReady () {
		bool isReady = true;

		foreach ( Pin pin in FindObjectsOfType<Pin>() ) {
			if ( pin.currentState != Pin.State.Lowered ) {
				isReady = false;
				break;
			}
		}

		return isReady;
	}

	
}

	
