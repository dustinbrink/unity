using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public enum State { Raising, Raised, Lowering, Lowered }
	public State currentState;
	public static float distanceToRaise = 0.3f;

	private float threshold = 5f;
	private Rigidbody rigidBody;
	private float moveSpeed = 1f;

	// Use this for initialization
	void Awake () {
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.useGravity = false;
		currentState = State.Lowering;
	}

	// Update is called once per frame
	void Update () {
		switch ( currentState ) {
			case State.Raising:
				if ( transform.position.y >= distanceToRaise ) {
					transform.position.Set( transform.position.x, distanceToRaise, transform.position.z );
					currentState = State.Raised;
				} else {
					transform.Translate( 0, moveSpeed * Time.deltaTime, 0, Space.World );
				}
				break;
			case State.Lowering:
				if ( transform.position.y <= 0 ) {
					transform.position.Set( transform.position.x, distanceToRaise, transform.position.z );
					currentState = State.Lowered;
					rigidBody.useGravity = true;
				} else {
					transform.Translate( 0, moveSpeed * Time.deltaTime * -1, 0, Space.World );
				}
				break;
		}
	}

	public bool IsStanding () {
		float tiltX = Mathf.Abs( 270 - transform.rotation.eulerAngles.x );
		return (tiltX < threshold || (360f - tiltX) < threshold);
	}

	public void Raise () {
		if ( IsStanding() && currentState == State.Lowered ) {
			rigidBody.useGravity = false;
			transform.rotation = Quaternion.Euler(270f, 0, 0);
			//transform.Translate( new Vector3( 0, distanceToRaise, 0 ), Space.World );
			currentState = State.Raising;
		}
	}

	public void Lower () {
		if ( currentState == State.Raised ) {
			//rigidBody.useGravity = true;
			//transform.Translate( new Vector3( 0, -1f * distanceToRaise, 0 ), Space.World );
			currentState = State.Lowering;
		}
	}
}
