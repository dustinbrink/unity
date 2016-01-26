using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	[Range(-1f, 9f)]
	public float speed = 1;
	[Range(0f, 100f)]
	public float damage = 1;

	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		sprite = transform.Find("Body").gameObject.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate( Vector3.right * speed * Time.deltaTime );
		if ( !sprite.isVisible ) {
			Destroy( gameObject );
		}
	}

	void OnTriggerEnter2D ( Collider2D collider ) {
		GameObject obj = collider.gameObject;

		if ( obj.GetComponent<Attackers>() ) {
			Health health = obj.GetComponent<Health>();
			if ( health ) {
				health.DealDamage( damage );
				Destroy( gameObject );
			}
		}
	}
}
