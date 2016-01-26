using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage = 100f;
	
	public void Hit () {
		Destroy( this.gameObject );
	}
	
	public float getDamage () {
		return damage;
	}
}
