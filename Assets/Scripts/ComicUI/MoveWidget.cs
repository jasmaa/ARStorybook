using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Button for moving scenes
/// </summary>
public class MoveWidget : MonoBehaviour {

	void Update() {
		// Toggles UI when comic is present
		var isTurnOn = GameManager.instance.comicNum >= 0;
		this.GetComponent<Button>().enabled = isTurnOn;
		this.GetComponent<Image>().enabled = isTurnOn;
		this.transform.Find("Text").GetComponent<Text>().enabled = isTurnOn;
	}

	/// <summary>
	/// Moves comic scene n places
	/// </summary>
	/// <param name="n"></param>
	public void MoveScene(int n) {
		GameManager.instance.MoveScene(n);
	}
}
