using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private Ball ball;
	private float minX = 0.8f;
	private float maxX = 15.2f;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if ( !autoPlay ) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		this.transform.position = new Vector3(	Mathf.Clamp( mousePosInBlocks, minX, maxX ),
		                                      	this.transform.position.y, 
		                                      	this.transform.position.z ); 
	}
	
	void AutoPlay() {
		this.transform.position = new Vector3(	Mathf.Clamp( ball.transform.position.x, minX, maxX ),
												this.transform.position.y, 
												this.transform.position.z ); 
	}
}
