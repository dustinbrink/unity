using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;
	private StarDisplay starDisplay;
	private int width = 9;
	private int height = 5;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		parent = GameObject.Find( "Defenders" );

		if ( !parent ) {
			parent = new GameObject( "Defenders" );
		}
	}

	void OnMouseDown () {
		if ( DefenderButton.selectedDefender ) {
			int cost = DefenderButton.selectedDefender.GetComponent<Defenders>().starCost;
			Vector2 worldPos = CalcWorldMousePos();
			if ( !PlaySpaceOccupied( worldPos ) ) {
				if ( starDisplay.UpdateStars( -1 * cost ) == StarDisplay.Status.SUCCESS ) {
					GameObject newDefender = Instantiate( DefenderButton.selectedDefender, worldPos, Quaternion.identity ) as GameObject;
					newDefender.transform.parent = parent.transform;
				}
			}
		}
	}

	Vector2 CalcWorldMousePos () {
		Vector2 mouse = Input.mousePosition;
		Vector2 worldPos = Camera.main.ScreenToWorldPoint( new Vector3( mouse.x, mouse.y, this.transform.position.z - Camera.main.transform.position.z ) );
		return new Vector2( Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y) );
	}

	bool PlaySpaceOccupied (Vector2 newPos) {
		//check bounds
		if ( newPos.x < 1 || newPos.x > width || newPos.y < 1 || newPos.y > height ) {
			return true;
		}

		//check if position is occupied
		foreach ( Transform trans in parent.transform ) {
			Vector3 pos = trans.position;
			if ( pos.x == newPos.x && pos.y == newPos.y ) {
				return true;
			}
		}

		return false;
	}
}
