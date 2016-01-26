using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour {

	public AudioClip startClip;
	public AudioClip inAreaClip;
	public AudioClip landingClip;
	public Helicopter helicopter;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		audioSource = GetComponent<AudioSource>();
	}

	public void Pause () {
		audioSource.Pause();
	}

	public void UnPause () {
		audioSource.UnPause();
	}

	public void RadioRequest () {
		audioSource.clip = startClip;
		audioSource.Play();
	}

	public void RadioInbound () {
		helicopter.InArea();
		audioSource.clip = inAreaClip;
		audioSource.Play();
	}

	public void RadioLanded () {
		helicopter.Landing();
		audioSource.clip = landingClip;
		audioSource.Play();
	}
}
