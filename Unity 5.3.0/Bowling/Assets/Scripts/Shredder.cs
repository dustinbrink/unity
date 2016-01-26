using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerExit ( Collider collider ) {
		GameObject thing = collider.gameObject;

		if ( thing.GetComponent<Pin>() ) {
			Destroy( thing );
		}
	}

}
