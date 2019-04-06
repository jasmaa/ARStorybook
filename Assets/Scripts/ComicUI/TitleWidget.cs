using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// AR Comic title
/// </summary>
public class TitleWidget : MonoBehaviour {
	void Update() {
		// Toggles UI when comic is present
		var isTurnOn = GameManager.instance.comicNum >= 0;
		this.GetComponent<Image>().enabled = isTurnOn;
		this.transform.Find("Text").GetComponent<Text>().enabled = isTurnOn;

		transform.Find("Text").GetComponent<Text>().text = GameManager.instance.GetCurrTitle();
	}
}
