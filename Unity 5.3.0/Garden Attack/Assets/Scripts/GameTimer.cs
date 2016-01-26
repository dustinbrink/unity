using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	[Range(30f, 300f)]
	public float levelTime = 120;
	public AudioClip soundLevelOver;

	private float timeRemaining;
	private LevelManager levelManager;
	private Slider slider;
	private AudioSource audioSource;
	private bool endOfLevel = false;
	private GameObject winText;

	// Use this for initialization
	void Start () {
		timeRemaining = levelTime;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		audioSource = GameObject.FindObjectOfType<AudioSource>();
		slider = GetComponent<Slider>();
		winText = GameObject.Find( "WinText" );
		winText.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
		slider.value = PercentComplete();
		if ( timeRemaining <= 0  && !endOfLevel ) {
			HandleWinCondition();
		}
	}

	public float PercentComplete () {
		return 1f - (timeRemaining / levelTime);
	}

	void EndLevel () {
		levelManager.LoadNext();
	}

	void HandleWinCondition () {
		DestroyAllTaggedObjects();
		if ( audioSource ) {
			audioSource.clip = soundLevelOver;
			audioSource.Play();
		}
		winText.SetActive( true );
		Invoke( "EndLevel", soundLevelOver.length );
		endOfLevel = true;
	}

	void DestroyAllTaggedObjects () {
		foreach ( GameObject obj in GameObject.FindGameObjectsWithTag( "DestroyOnWin" ) ) {
			Destroy( obj );
		}
	}
}
