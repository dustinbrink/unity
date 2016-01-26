using UnityEngine;
using System.Collections;

public class Attackers : MonoBehaviour {

	[Range(-1f, 1.5f)]
	public float defaultWalkSpeed = 1;

	[Range(0f, 100f)]
	public float damage = 5;

	[Tooltip("Average number of seconds bettween spawns")]
	[Range(0f, 100f)]
	public float rarity = 5;

	private float walkSpeed = 0;
	private GameObject currentTarget;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( Vector3.left * walkSpeed * Time.deltaTime );
		if ( !currentTarget ) {
			anim.SetBool( "isAttacking", false );
		}
	}

	public void setSpeed ( float speed ) {
		walkSpeed = speed;
	}

	public void isWalking ( float walking ) {
		if ( walking > 0) {
			walkSpeed = defaultWalkSpeed;
		} else {
			walkSpeed = 0;
		}
	}

	public void StrikeCurrentTarget () {
		if ( currentTarget ) {
			Defenders defender = currentTarget.GetComponent<Defenders>();
			Health health = currentTarget.GetComponent<Health>();

			if ( defender ) {
				defender.UnderAttack();
			}

			if ( health ) {
				health.DealDamage( damage );
			}

			
		}
	}

	public void Attack ( GameObject obj ) {
		currentTarget = obj;
	}
}
