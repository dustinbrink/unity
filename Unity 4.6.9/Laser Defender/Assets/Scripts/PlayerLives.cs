using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLives : MonoBehaviour {

	public int lives = 3;
	public GameObject extraLifePrefab;
	public int width = 25;
	public int height = 0;

	// Use this for initialization
	void Start () {
		UpdateLives();
	}
	
	public void LifeLost () {
		lives--;
		UpdateLives();
	}
	
	public void ExtraLife () {
		lives++;
		UpdateLives ();
	}
	
	void UpdateLives() {
		foreach ( Transform child in transform ) {
			Destroy( child.gameObject );
		}
	
		for (int i = 0; i < lives; i++) {
			Vector3 pos = new Vector3(  i*width, 0, 0 );
			GameObject life = Instantiate( extraLifePrefab, pos, Quaternion.identity ) as GameObject;
			life.transform.SetParent( transform, false );
		}
	}
}
