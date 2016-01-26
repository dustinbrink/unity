using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log( "here" );
		Destroy( collider.gameObject );
	}
}
