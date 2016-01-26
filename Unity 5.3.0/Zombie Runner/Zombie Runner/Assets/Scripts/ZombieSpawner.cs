using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {

	public Zombie zombiePrefab;

	private Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player>();
	}

	public void RandomSpawn () {
		Spawn( transform.GetChild( Random.Range( 0, transform.childCount ) ) );
	}

	public void SpawnAll () {
		foreach ( Transform location in transform ) {
			Spawn( location );
		}
	}

	public void DestroyZombies () {
		foreach ( Transform location in transform ) {
			foreach ( Transform zombie in location ) {
				Destroy( zombie.gameObject );
			}
		}
	}

	void Spawn (Transform location) {
		Zombie zombie = Instantiate( zombiePrefab, location.position, Quaternion.identity ) as Zombie;
		zombie.transform.SetParent( location );

		AICharacterControl ai = zombie.GetComponent<AICharacterControl>();
		ai.SetTarget( player.transform );
	}
}
