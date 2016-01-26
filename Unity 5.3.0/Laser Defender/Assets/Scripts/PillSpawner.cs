using UnityEngine;
using System.Collections;

public class PillSpawner : MonoBehaviour {

	public GameObject[] pills;
	public float[] rarities;
	public float fallSpeed = 4f;
	
	public void DropPill ( Vector3 pos ) {
		int index = Random.Range ( 0, pills.Length );
		GameObject pill = pills[ index ];
		if ( rarities[ index ] > Random.value ) {
			GameObject pil = Instantiate( pill, pos, Quaternion.identity ) as GameObject;
			pil.GetComponent<Rigidbody2D>().velocity = new Vector3( 0, -fallSpeed );
		}
	}

}
