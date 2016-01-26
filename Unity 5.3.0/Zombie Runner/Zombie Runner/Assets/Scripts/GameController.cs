using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController: MonoBehaviour {

	public enum GameState {
		MainMenu,
		OptionsMenu,
		Playing,
		LoseMenu,
		WinMenu,
		Exit
	}

	public enum PlayState {
		Start,
		Request,
		Inbound,
		Landed
	}

	GameState currentState = GameState.Exit;
	GameState previousState;
	PlayState currentPlayState = PlayState.Start;
	Canvas mainMenuCanvas, optionsCanvas, loseCanvas, winCanvas;
	Player player;
	Daycycle daycycle;
	ZombieSpawner zombieSpawner;
	FirstPersonController firstPersonController;
	float gameTime;
	float zombieTime;
	float zombieSpawnRate = 10.0f;
	float requestTime = 5f;
	float inboundTime = 240f;
	float landedTime = 300f;
	float timeScale = 340f;

	// Use this for initialization
	void Start () {
		mainMenuCanvas = GameObject.Find( "MainMenu" ).gameObject.GetComponent<Canvas>();
		optionsCanvas = GameObject.Find( "OptionsMenu" ).gameObject.GetComponent<Canvas>();
		loseCanvas = GameObject.Find( "LoseMenu" ).gameObject.GetComponent<Canvas>();
		winCanvas = GameObject.Find( "WinMenu" ).gameObject.GetComponent<Canvas>();
		player = GameObject.Find( "Player" ).gameObject.GetComponent<Player>();
		daycycle = GameObject.Find( "Stars" ).gameObject.GetComponent<Daycycle>();
		zombieSpawner = GameObject.Find( "ZombieSpawnPoints" ).gameObject.GetComponent<ZombieSpawner>();
		firstPersonController = GameObject.Find( "Player" ).GetComponent<FirstPersonController>();

		ChangeState( GameState.MainMenu );
		firstPersonController.enabled = false;
		Cursor.visible = true;
		daycycle.SetTimeScale( 20f );
	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown( "Menu" ) ) {
			ToggleMainMenu();
		}

		if ( currentState == GameState.Playing ) {
			gameTime += Time.deltaTime;
			zombieTime += Time.deltaTime;

			//spawn zombies 
			if ( zombieTime > zombieSpawnRate ) {
				zombieTime = 0.0f;
				//zombieSpawner.RandomSpawn();
			}
			

			// update playing state
			switch ( currentPlayState ) {
				case PlayState.Start:
					if ( gameTime > requestTime ) {
						player.radio.RadioRequest();
						currentPlayState = PlayState.Request;
					}
					break;
				case PlayState.Request:
					if ( gameTime > inboundTime ) {
						player.radio.RadioInbound();
						currentPlayState = PlayState.Inbound;
					}
					break;
				case PlayState.Inbound:
					if ( gameTime > landedTime ) {
						player.radio.RadioLanded();
						currentPlayState = PlayState.Landed;
					}
					break;
				case PlayState.Landed:
					break;
			}
		}
	}

	public void StartNewGame () {
		gameTime = 0.0f;
		currentPlayState = PlayState.Start;
		player.ReSpawn();
		daycycle.SetTimeScale( timeScale );
		daycycle.Reset();
		zombieSpawner.DestroyZombies();
		zombieSpawner.SpawnAll();
		ChangeState( GameState.Playing );
	}

	public void OpenMainMenu () {
		ChangeState( GameState.MainMenu );
		previousState = GameState.Exit;
	}

	public void OpenOptions () {
		ChangeState( GameState.OptionsMenu );
	}

	public void ExitGame () {
		ChangeState( GameState.Exit );
	}

	public void ChangeState ( GameState newState ) {
		previousState = currentState;
		currentState = newState;
		StartCoroutine( newState.ToString() + "State" );
	}

	void ToggleMainMenu () {
		if ( currentState == GameState.MainMenu ) {
			ChangeState( previousState );
		} else {
			ChangeState( GameState.MainMenu );
		}
	}

	IEnumerator MainMenuState () {
		mainMenuCanvas.enabled = true;

		while ( currentState == GameState.MainMenu ) {
			yield return null;
		}

		mainMenuCanvas.enabled = false;
	}

	IEnumerator OptionsMenuState () {
		optionsCanvas.enabled = true;

		while ( currentState == GameState.OptionsMenu ) {
			yield return null;
		}

		optionsCanvas.enabled = false;
	}

	IEnumerator LoseMenuState () {
		loseCanvas.enabled = true;

		while ( currentState == GameState.LoseMenu ) {
			yield return null;
		}

		loseCanvas.enabled = false;
	}

	IEnumerator WinMenuState () {
		winCanvas.enabled = true;

		while ( currentState == GameState.WinMenu ) {
			yield return null;
		}

		winCanvas.enabled = false;
	}

	IEnumerator PlayingState () {
		player.radio.UnPause();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		firstPersonController.enabled = true;
		Time.timeScale = 1;

		while ( currentState == GameState.Playing ) {
			yield return null;
		}

		Time.timeScale = 0;
		player.radio.Pause();
		firstPersonController.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	IEnumerator ExitState () {
		Debug.Log( "Exit Game" );
		Application.Quit();
		return null;
	}

}
