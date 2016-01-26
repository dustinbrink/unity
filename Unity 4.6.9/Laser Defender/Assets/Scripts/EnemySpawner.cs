using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefabs;
	public float speed = 1.0f;
	public float width = 6.0f;
	public float height = 6.0f;
	public float spawnDelay = 0.5f;
	public int points = 20;
	
	private float xMin;
	private float xMax;
	private bool moveRight = true;
	private ScoreKeeper score;
	
	public void OnDrawGizmos () {
		Gizmos.DrawWireCube( this.transform.position, new Vector3( this.width, this.height ) );
	}

	// Use this for initialization
	void Start () {
		float distanceToCamera = this.transform.position.z - Camera.main.transform.position.z;
		this.xMin = Camera.main.ViewportToWorldPoint( new Vector3( 0, 0, distanceToCamera) ).x + (this.width / 2);
		this.xMax = Camera.main.ViewportToWorldPoint( new Vector3( 1, 0, distanceToCamera) ).x - (this.width / 2);
		
		this.score = GameObject.FindObjectOfType<ScoreKeeper> ();
	
		this.SpawnUntilFull();
	}
	
	// Update is called once per frame
	void Update () {
		if ( this.AllMembersDead() ) {
			this.score.Score( this.points );
			this.SpawnUntilFull();
		}
	
		if ( moveRight ) {
			this.transform.position += Vector3.right * this.speed * Time.deltaTime;	
		} else  {
			this.transform.position += Vector3.left * this.speed * Time.deltaTime;
		}
	
		this.changeDirection();
	}
	
	void changeDirection () {
		float xNow = this.transform.position.x;
		if ( xNow <= this.xMin ) { this.moveRight = true; }
		else if ( xNow >= this.xMax ) { this.moveRight = false; }
	}
	
	bool AllMembersDead () {
		foreach ( Transform child in transform ) {
			if ( child.childCount > 0 ) {
				return false;
			}
		}
		
		return true;
	}
	
	void SpawnUntilFull () {
		Transform freePosition = this.NextFreePosition();
		if (freePosition) {
			GameObject enemy = Instantiate( enemyPrefabs[Random.Range( 0, enemyPrefabs.Length )], freePosition.position, Quaternion.identity ) as GameObject;
			enemy.transform.parent = freePosition;
		}
		
		if (this.NextFreePosition()) {
			Invoke( "SpawnUntilFull", this.spawnDelay );
		}
	}
	
	Transform NextFreePosition () {
		foreach ( Transform child in transform ) {
			if ( child.childCount == 0 ) {
				return child;
			}
		}
		
		return null;
	}
}
