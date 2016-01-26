using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startPosition;
	private float laneWidth = 0.6f;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		startPosition = transform.position;
		Reset();
		Enable();
	}

	public void Reset () {
		inPlay = false;
		transform.rotation = Quaternion.identity;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = new Vector3( 0, -1, 0 );
		rigidBody.useGravity = false;
		audioSource.Stop();
		transform.position = startPosition;
		gameObject.SetActive( false );
	}

	public void Enable () {
		gameObject.SetActive( true );
	}

	public void ReadyLaunch () {
		rigidBody.angularVelocity = Vector3.zero;
	}

	public void Launch (Vector3 velocity) {
		if ( !inPlay ) {
			rigidBody.angularVelocity = Vector3.zero;
			rigidBody.useGravity = true;
			rigidBody.velocity = velocity;
			audioSource.Play();
			inPlay = true;
		}
	}

	public void MoveStart (float x) {
		if ( !inPlay && Mathf.Abs( transform.position.x + x ) <= laneWidth ) {
			transform.position += new Vector3( x, 0, 0 );
		}
	}

}
