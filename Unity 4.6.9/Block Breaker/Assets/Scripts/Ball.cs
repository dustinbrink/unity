using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle	paddle;
	private Vector3 paddleToBallVector;
	private bool	gameStarted = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		// Debug.Log( paddleToBallVector.y );
	}
	
	// Update is called once per frame
	void Update () {
		if ( !gameStarted ) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if ( Input.GetMouseButtonDown(0) ) {
				// Debug.Log( "Mouse Click, launching ball" );
				this.rigidbody2D.velocity = new Vector2( Random.Range(-2f, 2f), 10f );
				gameStarted = true;
			}
		}
	}
	
	void OnCollisionEnter2D ( Collision2D collision ) {
		
		if ( gameStarted ) {
			audio.Play ();
			this.rigidbody2D.velocity += new Vector2( Random.Range(0f, 0.2f), Random.Range(0f, 0.2f) );
		}
	}

}
