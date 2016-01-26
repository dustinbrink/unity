using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public enum Weapons {Single = 0, Dual = 1, Tri = 2};
	public Weapons weapon;
	public float health = 50f;
	public float speed = 15.0f;
	public float xOffset = 0.5f;
	public GameObject projectile;
	public float projectileSpeed = 5.0f;
	public float projectileFireRate = 0.5f;
	public AudioClip fireSound;
	public AudioClip shieldSound;
	public AudioClip deathSound;
	public GameObject explosionObj;
	public bool invulnerable = false;
	
	private float xMin;
	private float xMax;
	private float soundLevel = 0.2f;
	

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		xMin = Camera.main.ViewportToWorldPoint( new Vector3( 0, 0, distanceToCamera) ).x + xOffset;
		xMax = Camera.main.ViewportToWorldPoint( new Vector3( 1, 0, distanceToCamera) ).x - xOffset;
		StartWarmup();
		Invoke ("EndWarmup", 3);
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			InvokeRepeating( "Fire", 0.000001f, projectileFireRate );
		}
		
		if ( Input.GetKeyUp( KeyCode.Space ) ) {
			CancelInvoke( "Fire" );
		}
		
		if ( Input.GetKey( KeyCode.LeftArrow ) ) {
			transform.position += Vector3.left * speed * Time.deltaTime;	
		} else if ( Input.GetKey( KeyCode.RightArrow ) ) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		checkBounds();
	}
	
	void checkBounds () {
		// restrict player to gamespace
		transform.position = new Vector3( Mathf.Clamp( transform.position.x, xMin, xMax ), 
												transform.position.y, 
												transform.position.z);
	}
	
	void Fire () {
		Vector3 pos = transform.position;
		float offset = 0.4f;
		switch (weapon) {
			case Weapons.Single:
				ShootLaser(pos);
				break;
			case Weapons.Dual:
				ShootLaser( (Vector3.left * offset) + pos );
				ShootLaser( (Vector3.right * offset) + pos );
				break;
			case Weapons.Tri:
				ShootLaser(pos);
				ShootLaser( (Vector3.left * offset) + pos );
				ShootLaser( (Vector3.right * offset) + pos );
				break;
		}
	}
	
	void ShootLaser (Vector3 pos) {
		GameObject laser = Instantiate( projectile, pos, Quaternion.identity ) as GameObject;
		laser.rigidbody2D.velocity = new Vector3( 0, projectileSpeed );
		AudioSource.PlayClipAtPoint( fireSound, pos, soundLevel );
	}
	
	void OnTriggerEnter2D ( Collider2D col ) {
		Projectile projectile = col.gameObject.GetComponent<Projectile>();
		PowerUp pill = col.gameObject.GetComponent<PowerUp>();
		
		if ( pill ) {
			pill.Pickup(this);
		} else if ( projectile && !invulnerable ) {
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
		Explode ();
		Player player = GameObject.FindObjectOfType<Player> ();
		player.Died();
		Destroy( gameObject );
	}
	
	void Explode () {
		AudioSource.PlayClipAtPoint( deathSound, transform.position, soundLevel );
		GameObject explosion = Instantiate( explosionObj, transform.position, Quaternion.identity ) as GameObject;
		Destroy(explosion, 1);
	}
	
	void StartWarmup () {
		invulnerable = true;
	}
	
	void EndWarmup () {
		invulnerable = false;
	}
	
	public void UpgradeWeapons () {
		if ( weapon < Weapons.Tri ) {
			weapon++;
			projectileFireRate += 0.1f;
		}
	}
	
	public void UpgradeFireRate () {
		if ( projectileFireRate > 0.2f ) {
			projectileFireRate = projectileFireRate * 0.75f;
			speed = speed * 1.25f;
		}
	}
}
