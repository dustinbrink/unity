using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager: MonoBehaviour {

	public float autoloadSeconds;

	void Start () {
		if ( autoloadSeconds > 0 ) {
			Invoke( "LoadNext", autoloadSeconds );
		}
	}

	public void LoadLevel ( string name ) {
		SceneManager.LoadScene( name );
	}

	public void LoadNext () {
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
	}

	public void Back () {
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex - 1 );
	}

	public void QuitRequest () {
		Application.Quit();
	}

}
