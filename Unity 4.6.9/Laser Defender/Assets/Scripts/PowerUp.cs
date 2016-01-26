using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public enum Powers {Weapons = 0, Shield = 1, Life = 2, Fire = 3};
	public Powers power;
	public AudioClip pickupSound;
	public float soundLevel = 0.3f;
	public int points = 25;
	public float rarity = 0.1f;

	public void Pickup (PlayerController player) {
		switch (power) {
			case Powers.Weapons:
				player.UpgradeWeapons();
				break;
			case Powers.Shield:
				break;
			case Powers.Life:
				PlayerLives life = GameObject.FindObjectOfType<PlayerLives> ();
				life.ExtraLife();
				break;
			case Powers.Fire:
				player.UpgradeFireRate();
				break;
		}
		ScoreKeeper score = GameObject.FindObjectOfType<ScoreKeeper> ();
		score.Score(points);
		AudioSource.PlayClipAtPoint( pickupSound, transform.position, soundLevel );
		Destroy( gameObject );
	}
	
}
