using UnityEngine;
using System.Collections;

public class MusicPlayer: MonoBehaviour {

	public AudioClip[] levelMusic;

	private AudioSource audioSource;

	void Awake () {
		DontDestroyOnLoad( gameObject );
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();
		SetVolume( PlayerPrefsManager.GetMasterVolume() );
		OnLevelWasLoaded( 0 );
	}

	void OnLevelWasLoaded ( int level ) {
		AudioClip music = levelMusic[ level ];
		if ( music && audioSource && audioSource.clip != music ) {
			audioSource.Stop();
			audioSource.clip = music;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void SetVolume ( float volume ) {
		audioSource.volume = volume;
	}

	public float GetVolume () {
		return audioSource.volume;
	}
}
