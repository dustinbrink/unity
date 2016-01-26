using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DefenderButton: MonoBehaviour {

	public static GameObject selectedDefender;

	public GameObject defenderPrefab;

	private Color disabledColor = Color.black;
	private Color clickedColor = Color.white;
	private Text costText;


	private DefenderButton[] buttons;

	void Start () {
		buttons = GameObject.FindObjectsOfType<DefenderButton>();
		costText = GetComponentInChildren<Text>();
		costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();
	}

	void OnMouseDown () {
		foreach ( DefenderButton btn in buttons ) {
			btn.GetComponent<SpriteRenderer>().color = disabledColor;
		}
		GetComponent<SpriteRenderer>().color = clickedColor;
		selectedDefender = defenderPrefab;
	}


}
