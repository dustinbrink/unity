using UnityEngine;
using System.Collections;

public class Daycycle : MonoBehaviour {

	private float dayLength = 300.0f;
	private Quaternion originalRotation;
	private ParticleSystem partSystem;
	private Light sunlight;
	private Light moonlight;
	private float sunIntensity;
	private float sunFade = 0.2f;
	private float moonIntensity;
	private bool sunset = false;
	private Color fogDay = new Color(0.176f, 0.176f, 0.176f, 1.0f);
	private Color fogNight = Color.black;

	// Use this for initialization
	void Start () {
		partSystem = GetComponent<ParticleSystem>();
		sunlight = GameObject.Find( "Sun" ).GetComponent<Light>();
		moonlight = GameObject.Find( "Moonlight" ).GetComponent<Light>();
		sunIntensity = sunlight.intensity;
		moonIntensity = moonlight.intensity;
		originalRotation = transform.rotation;
		moonlight.intensity = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		// Spin Starsystem
		transform.Rotate( Vector3.forward * (180 / dayLength) * Time.deltaTime );

		// Determine if day or night
		float angle = transform.rotation.eulerAngles.z;
		if ( angle > 160.0f && !sunset ) {
			StartNight();
		} else if ( angle > 360.0f ) {
			StartDay();
		}

		// Fade out Sunlight
		if ( sunset && sunlight.intensity >= 0.2f ) {
			sunlight.intensity -= Time.deltaTime * sunFade;
		}

		// Fade in Sunlight
		if ( !sunset && sunlight.intensity <= sunIntensity ) {
			sunlight.intensity += Time.deltaTime * sunFade;
		}

	}

	void StartNight () {
		print( "night" );
		if ( !partSystem.isPlaying ) {
			partSystem.Play();
		}
			
		moonlight.intensity = moonIntensity;
		RenderSettings.fogColor = fogNight;
		sunset = true;
	}

	void StartDay () {
		print( "day" );
		if ( partSystem.isPlaying ) {
			partSystem.Stop();
			partSystem.Clear();
		}

		moonlight.intensity = 0.0f;
		RenderSettings.fogColor = fogDay;
		sunset = false;
	}

	public void Reset () {
		StartDay();
		sunlight.intensity = sunIntensity;
		transform.rotation = originalRotation;
	}

	public void SetTimeScale (float timeScale) {
		dayLength = timeScale;
	}
}
