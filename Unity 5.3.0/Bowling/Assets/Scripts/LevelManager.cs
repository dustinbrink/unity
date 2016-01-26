using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour {

	public float secondsToAutoload = 0;

	void Start () {
		if ( secondsToAutoload > 0 ) {
			AutoloadNext( secondsToAutoload );
		}
	}

	public void AutoloadNext (float secondsToLoad) {
		Invoke ( "LoadNext", secondsToLoad );
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
