using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public enum Weapons {Single = 0, Dual = 1, Tri = 2, Spinner = 3, Blink = 4, Fast = 5};
	public Weapons weapon;
	public float health = 150;
	public GameObject projectile;
	public float projectileSpeed = 5.0f;
	public float shotsPerSecond = 0.5f;
	public int points = 5;
	public AudioClip fireSound;
	public AudioClip shieldSound;
	public AudioClip deathSound;
	public GameObject explosionObj;
	public bool dualLasers = false;
	
	private ScoreKeeper score;
	private PillSpawner pillSpawner;
	private float soundLevel = 0.2f;

	// Use this for initialization
	void Start () {
		score = GameObject.FindObjectOfType<ScoreKeeper> ();
		pillSpawner = GameObject.FindObjectOfType<PillSpawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ( Random.value < Time.deltaTime * shotsPerSecond ) {
			Fire();
		}
	}
	
	void Fire () {
		Vector3 pos = transform.position;
		float offset = 0.4f;
		
		switch (weapon) {
			case Weapons.Single:
				ShootLaser(pos, 0);
				break;
			case Weapons.Dual:
				ShootLaser( (Vector3.left * offset) + pos, 0);
				ShootLaser( (Vector3.right * offset) + pos, 0);
				break;
			case Weapons.Tri:
				ShootLaser(pos, 0);
				ShootLaser( (Vector3.left * offset) + pos, 0);
				ShootLaser( (Vector3.right * offset) + pos, 0);
				break;
			case Weapons.Spinner:
				ShootLaser(pos, Random.Range(1, -1));
				break;
			case Weapons.Blink:
				Player player = GameObject.FindObjectOfType<Player> ();
				foreach ( Transform ship in player.transform ) {
					float target = ship.position.x - transform.position.x;
					ShootLaser(pos, target);
				}
				break;
		}	
	}
	
	void ShootLaser (Vector3 pos, float x) {
		GameObject laser = Instantiate( projectile, pos, Quaternion.identity ) as GameObject;
		laser.rigidbody2D.velocity = new Vector3( x, -projectileSpeed );
		AudioSource.PlayClipAtPoint( fireSound, pos, soundLevel );
	}
	
	void OnTriggerEnter2D ( Collider2D col ) {
		Projectile projectile = col.gameObject.GetComponent<Projectile>();
		
		if ( projectile ) {
			health -= projectile.getDamage();
			projectile.Hit();
			
			if ( health <= 0 ) {
				Die();
			} else {
				AudioSource.PlayClipAtPoint( shieldSound, transform.position, soundLevel );
			}
		}
	}
	
	void Die () {
		score.Score( points );
		SpawnPowerUp();
		Explode();
		Destroy( gameObject );
	}
	
	void Explode () {
		AudioSource.PlayClipAtPoint( deathSound, transform.position, soundLevel );
		GameObject explosion = Instantiate( explosionObj, transform.position, Quaternion.identity ) as GameObject;
		Destroy(explosion, 1);
	}
	
	void SpawnPowerUp () {
		pillSpawner.DropPill( transform.position );
	}
}
