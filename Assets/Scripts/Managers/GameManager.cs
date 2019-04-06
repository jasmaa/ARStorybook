using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages game
/// </summary>
public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	List<Comic> comics;
	public int comicNum = 0;
	public int sceneNum = 0;

    void Start()
    {
		if(instance == null){
			instance = this;
		}
		else{
			Destroy(this.gameObject);
		}

		// Init
		comics = new List<Comic>();

		// Load all comics
		foreach(Transform child in GameObject.Find("Comics").transform){
			comics.Add(child.GetComponent<Comic>());
		}
    }

	void Update(){
		// Update comic num
		comicNum = -1;
		for(int i=0; i < comics.Count; i++){
			if(comics[i].isTracking){
				comicNum = i;
				break;
			}
		}



	}

	/// <summary>
	/// Moves current comic n scenes
	/// </summary>
	/// <param name="n"></param>
	public void MoveScene(int n){

		if(comicNum < 0){
			return;
		}

		comics[comicNum].MoveScene(n);
	}

	public string GetCurrTitle() {
		if(comicNum < 0){
			return "";
		}
		return comics[comicNum].title;
	}
}
