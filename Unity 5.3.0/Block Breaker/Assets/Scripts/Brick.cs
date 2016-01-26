using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	public AudioClip crackSound;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		isBreakable  = (this.tag == "Breakable");
		
		if ( isBreakable ) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter2D ( Collision2D collision ) {
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		timesHit++;
		
		AudioSource.PlayClipAtPoint( crackSound, transform.position, 0.1f );
		
		if ( timesHit >= hitSprites.Length ) {
			breakableCount--;
			levelManager.BrickDestroyed();
			puffSmoke();
			Destroy ( gameObject );
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		
		if ( hitSprites[ spriteIndex ] ) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[ spriteIndex ];
		} else {
			Debug.LogError( "Missing Brick sprite @ index: " + spriteIndex );
		}
	}
	
	// TODO Remove this method once we can actually win!
	void puffSmoke() {
		GameObject smokePuff = Instantiate( smoke, transform.position, Quaternion.identity ) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
}
