﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	void Awake () {
		if ( instance != null ) {
			Destroy( gameObject );
			// Debug.Log( "Destroy music player" );
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad( gameObject );
		}
	}
}
