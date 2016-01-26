using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	private AudioSource audioSource;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	public void InArea () {
		audioSource.Play();
		animator.SetTrigger( "InArea" );
	}

	public void Landing () {
		audioSource.Play();
		animator.SetTrigger( "Landing" );
	}
}
