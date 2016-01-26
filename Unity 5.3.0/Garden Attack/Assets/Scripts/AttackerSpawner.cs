using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackers;
	public GameTimer gameTimer;

	private float timeSinceSpawn = 0;
	private float difficultyModifier = 0.05f;
	
	// Use this for initialization
	void Start () {
		gameTimer = GameObject.FindObjectOfType<GameTimer>();
	}

	// Update is called once per frame
	void Update () {
		timeSinceSpawn += Time.deltaTime;
		foreach ( GameObject attacker in attackers ) {
			if ( isTimeToSpawn( attacker ) ) {
				Spawn( attacker );
				timeSinceSpawn = 0;
			}
		}
	}

	void Spawn (GameObject gameObj) {
		Transform parent = transform.GetChild( Random.Range( 0, transform.childCount ) );
		GameObject newAttacker = Instantiate( gameObj, parent.position, Quaternion.identity ) as GameObject;
		newAttacker.transform.parent = parent;
	}

	bool isTimeToSpawn ( GameObject gameObj ) {
		Attackers attacker = gameObj.GetComponent<Attackers>();
		float difficulty = PlayerPrefsManager.GetDifficulty() / 3;
		float threshhold = gameTimer.PercentComplete() * (1 / attacker.rarity) * difficulty * timeSinceSpawn * difficultyModifier;
		return Random.value < threshhold;
	}
}
