using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject playerShip;
	
	private PlayerLives life;

	// Use this for initialization
	void Start () {
		life = GameObject.FindObjectOfType<PlayerLives> ();
		SpawnPlayerShip();
	}
	
	void SpawnPlayerShip () {
		life.LifeLost();
		GameObject ship = Instantiate( playerShip, this.transform.position, Quaternion.identity ) as GameObject;
		ship.transform.SetParent( transform, true );
	}
	
	public void Died () {
		if ( life.lives <= 0 ) {
			Invoke ("LoadEndGame", 1);
		} else {
			Invoke ("SpawnPlayerShip", 1);
		}
		
	}
	
	void LoadEndGame () {
		LevelManager man = GameObject.FindObjectOfType<LevelManager> ();
		man.LoadLevel( "Win" );
	}
}
