using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string SCORE_KEY = "score";
	const string HIGH_SCORE_KEY = "high_score";

	public static void SetMasterVolume ( float volume ) {
		if ( volume >= 0f && volume <= 1f ) {
			PlayerPrefs.SetFloat( MASTER_VOLUME_KEY, volume );
		} else {
			Debug.LogError( "Trying to set Master volume out of range" );
		}
	}

	public static void SetScore( int score ) {
		PlayerPrefs.SetFloat( SCORE_KEY, (float)score );
	}

	public static void SetHighScore ( int score ) {
		PlayerPrefs.SetFloat( HIGH_SCORE_KEY, (float)score );
	}

	public static float GetMasterVolume () {
		if ( !PlayerPrefs.HasKey( MASTER_VOLUME_KEY ) ) {
			PlayerPrefsManager.SetMasterVolume( 0.2F );
		}
		return PlayerPrefs.GetFloat( MASTER_VOLUME_KEY );
	}

	public static int GetScore () {
		return (int)PlayerPrefs.GetFloat( SCORE_KEY );
	}

	public static int GetHighScore () {
		return (int)PlayerPrefs.GetFloat( HIGH_SCORE_KEY );
	}
}
