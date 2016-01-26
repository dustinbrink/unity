using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Ball ball;
	private float stopOffest = 18f;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if ( !ball.inPlay || (ball.transform.position.z <= stopOffest && ball.transform.position.y > 0) ) {
			transform.position = ball.transform.position + offset;
		}
	}
}
