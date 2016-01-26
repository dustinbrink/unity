using UnityEngine;
using System.Collections;

public class ThirdPersonController: MonoBehaviour {

	private Animator animatorZ1;

	float movingTurnSpeed = 360;
	float stationaryTurnSpeed = 180;
	float turnAmount;
	float forwardAmount;

	void Start () {
		animatorZ1 = GetComponent<Animator>();
	}

	public void Move ( Vector3 move ) {
		move = transform.InverseTransformDirection( move );
		turnAmount = Mathf.Atan2( move.x, move.z );
		forwardAmount = move.z;
		ApplyExtraTurnRotation();
		turnAmount = Mathf.Atan2( move.x, move.z );
		UpdateAnimator( move );
	}

	void ApplyExtraTurnRotation () {
		float turnSpeed = Mathf.Lerp( stationaryTurnSpeed, movingTurnSpeed, forwardAmount );
		transform.Rotate( 0, turnAmount * turnSpeed * Time.deltaTime, 0 );
	}

	void UpdateAnimator ( Vector3 move ) {
		if ( forwardAmount == 0 ) {
			animatorZ1.SetBool( "isWalking", false );
		} else {
			animatorZ1.SetBool( "isWalking", true );
		}

	}
}
