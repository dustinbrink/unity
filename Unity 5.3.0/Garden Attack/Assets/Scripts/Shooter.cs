using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	
	
	[Range(0f, 20f)]
	public float timeToShoot = 1;

	private float time = 0;
	private Transform gun;
	private GameObject parent;
	private Animator anim;
	private GameObject spawner;

	// Use this for initialization
	void Start () {
		spawner = GameObject.Find( "Spawners" ).transform.GetChild( (int)transform.position.y - 1 ).gameObject;
		gun = transform.Find( "Gun" );
		anim = GameObject.FindObjectOfType<Animator>();
		parent = GameObject.Find( "Projectiles" );

		if ( !parent ) {
			parent = new GameObject( "Projectiles" );
		}
		
	}

	// Update is called once per frame
	void Update () {
		if ( HasTarget() ) {
			UpdateAttackTrigger( true );
		time += Time.deltaTime;
			if ( time > timeToShoot ) {
				Fire();
				time = 0;
			}
		} else if ( anim ) {
			UpdateAttackTrigger( false );
		}
	}

	void UpdateAttackTrigger ( bool isAttacking ) {
		if ( anim ) {
			anim.SetBool( "isAttacking", isAttacking );
		}
	}

	void Fire () {
		GameObject newProjectile = Instantiate( projectile, gun.position, Quaternion.identity ) as GameObject;
		newProjectile.transform.parent = parent.transform;
	}

	bool HasTarget () {
		if ( spawner.transform.childCount > 0 ) {
			foreach ( Transform child in spawner.transform ) {
				if ( child.transform.position.x > transform.position.x ) {
					return true;
				}
			}
		}

		return false;
	}
}
