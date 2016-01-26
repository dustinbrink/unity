using UnityEngine;
using UnityStandardAssets.Water;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints;
	public Radio radio;

	private Transform[] spawnPoints;
	private GameController gameController;
	private FirstPersonController fpc;
	private float runSpeed = 5.0f;
	private float walkSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
		gameController = GameObject.FindObjectOfType<GameController>();
		radio = GetComponentInChildren<Radio>();
		fpc = GetComponent<FirstPersonController>();
	}

	public void ReSpawn () {
		int i = Random.Range( 1, spawnPoints.Length );
		transform.position = spawnPoints[ i ].position;
	}

	void OnControllerColliderHit ( ControllerColliderHit hit ) {
		GameObject obj = hit.gameObject;
		if ( obj.GetComponent<Zombie>() ) {
			gameController.ChangeState( GameController.GameState.LoseMenu );
		} else if ( obj.GetComponent<Helicopter>() ) {
			gameController.ChangeState( GameController.GameState.WinMenu );
		} else if ( obj.GetComponent<Water>() ) {
			fpc.SetWalkSpeed( walkSpeed );
		} else {
			fpc.SetWalkSpeed( runSpeed );
		}
	}

}
