using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager levelManager;
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	// called on collision
	void OnCollisionEnter2D ( Collision2D collision ) {
		// Debug.Log( "Collision" );
	}
	
	// called on trigger
	void OnTriggerEnter2D ( Collider2D trigger ) {
		// Debug.Log( "Tigger" );
		levelManager.LoadLevel( "Lose" );
	}
}
