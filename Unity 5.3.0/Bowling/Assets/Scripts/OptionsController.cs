using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public float volumeDefault = 0.5f;

	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();

		if ( musicPlayer ) {
			volumeSlider.value = musicPlayer.GetVolume();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( musicPlayer ) {
			musicPlayer.SetVolume( volumeSlider.value );
		}
	}

	public void SaveAndExit () {
		PlayerPrefsManager.SetMasterVolume( volumeSlider.value );
		LevelManager levelManager = FindObjectOfType<LevelManager>();
		levelManager.Back();
	}

	public void SetDefaults () {
		volumeSlider.value = volumeDefault;
	}
}
