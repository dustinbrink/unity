using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[Range(0f, 100f)]
	public float health = 50f;

	public void DealDamage ( float damage ) {
		if ( (health -= damage) <= 0 ) {
			DestroyObject();
		}
	}

	public void DestroyObject () {
		Destroy( gameObject );
	}
}
