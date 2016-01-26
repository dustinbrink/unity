using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float fadeTime;

	private Image panel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		panel = GetComponent<Image>();
		panel.color = currentColor;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Time.timeSinceLevelLoad < fadeTime ) {
			currentColor.a -= Time.deltaTime / fadeTime;
			panel.color = currentColor;
        } else {
			gameObject.SetActive( false );
		}
	}
}
