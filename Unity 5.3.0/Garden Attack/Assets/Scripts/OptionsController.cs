using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();

		if ( musicPlayer ) {
			volumeSlider.value = musicPlayer.GetVolume();
		}

		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		if ( musicPlayer ) {
			musicPlayer.SetVolume( volumeSlider.value );
		}
	}

	public void SaveAndExit () {
		PlayerPrefsManager.SetMasterVolume( volumeSlider.value );
		PlayerPrefsManager.SetDifficulty( difficultySlider.value );
		levelManager.Back();
	}

	public void SetDefaults () {
		volumeSlider.value = 0.2f;
		difficultySlider.value = 2f;
	}
}
