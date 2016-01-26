using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume ( float volume ) {
		if ( volume >= 0f && volume <= 1f ) {
			PlayerPrefs.SetFloat( MASTER_VOLUME_KEY, volume );
		} else {
			Debug.LogError( "Trying to set Master volume out of range" );
		}
	}

	public static void SetDifficulty ( float difficulty ) {
		if ( difficulty >= 1f && difficulty <= 3f ) {
			PlayerPrefs.SetFloat( DIFFICULTY_KEY, difficulty );
		} else {
			Debug.LogError( "Trying to set difficulty out of range" );
		}
	}

	public static void UnlockLevel ( int level ) {
		if ( level >= 0 && level <= SceneManager.sceneCountInBuildSettings - 1 ) {
			PlayerPrefs.SetInt( LEVEL_KEY + level.ToString(), 1 );
		} else {
			Debug.LogError( "Trying to unlock level not in build order" );
		}
	} 

	public static float GetMasterVolume () {
		if ( !PlayerPrefs.HasKey( MASTER_VOLUME_KEY ) ) {
			PlayerPrefsManager.SetMasterVolume( 0.2F );
		}
		return PlayerPrefs.GetFloat( MASTER_VOLUME_KEY );
	}

	public static float GetDifficulty () {
		if ( !PlayerPrefs.HasKey( DIFFICULTY_KEY ) ) {
			PlayerPrefsManager.SetDifficulty( 2F );
		}
		return PlayerPrefs.GetFloat( DIFFICULTY_KEY );
	}

	public static bool IsLevelUnlocked ( int level ) {
		bool isLevelUnlocked = false;

		if ( level >=  0 && level <= SceneManager.sceneCountInBuildSettings - 1 ) {
			isLevelUnlocked = PlayerPrefs.GetInt( LEVEL_KEY + level ) == 1;
		} else {
			Debug.LogError( "Trying to request isunlocked level not in build order" );
		}

		return isLevelUnlocked;
	}
}
