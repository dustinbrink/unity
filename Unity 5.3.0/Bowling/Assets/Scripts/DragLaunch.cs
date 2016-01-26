using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private float timeStart, timeEnd;
	private Vector3 dragStart, dragEnd;
	private float xOffset = 0.004f; //0.004f
	private float zOffset = 0.005f; //0.008f

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}

	public void DragStart () {
		if ( !ball.inPlay && ball.gameObject.activeSelf ) {
			// capture time & position of drag
			dragStart = Input.mousePosition;
			timeStart = Time.time;
			ball.ReadyLaunch();
		}
	}

	public void DragEnd () {
		if ( !ball.inPlay && ball.gameObject.activeSelf ) {
			// Launch ball
			dragEnd = Input.mousePosition;
			timeEnd = Time.time;

			float dragDuration = timeEnd - timeStart;
			float launchX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchZ = (dragEnd.y - dragStart.y) / dragDuration;

			//print( launchX );
			//print( launchZ );

			launchX = launchX * xOffset;
			launchZ = 8 + (launchZ * zOffset);

			//print( launchX );
			//print( launchZ );

			launchX = Mathf.Clamp( launchX, -1f, 1f );
			launchZ = Mathf.Clamp( launchZ, 0f, 20f);

			//print( launchX );
			//print( launchZ );
			//print( "LAUNCH---------" );

			ball.Launch( new Vector3( launchX, 0, launchZ ) );
			//if ( Random.value > 0.5 ) {
			//	ball.Launch( new Vector3( 0, 0, 15.9f ) ); // Strike
			//} else {
			//	ball.Launch( new Vector3( 0, 0, 17f ) ); // 6
			//}
			
		}
	}

	public void MoveStart ( float xNudge ) {
		ball.MoveStart( xNudge );
	}
}
