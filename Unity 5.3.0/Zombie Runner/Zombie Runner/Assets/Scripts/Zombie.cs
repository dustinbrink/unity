using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public AudioClip[] growlCips;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating( "Growl", 10.0f, Random.Range( 10, 20 ) );
	}

	void Growl () {
		audioSource.clip = growlCips[ Random.Range( 0, growlCips.Length ) ];
		audioSource.Play();
	}

}
