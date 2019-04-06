using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	List<ComicScene> comicScenes;
	int comicNum = 0;
	int sceneNum = 0;

    void Start()
    {
		if(instance == null){
			instance = this;
		}
		else{
			Destroy(this.gameObject);
		}

		// Init
		comicScenes = new List<ComicScene>();

		// Load all comics
		foreach(Transform child in GameObject.Find("Comics").transform){
			comicScenes.Add(child.GetComponent<ComicScene>());
		}
    }

	void Update(){
		// Update comic num
		comicNum = -1;
		for(int i=0; i < comicScenes.Count; i++){
			if(comicScenes[i].isTracking){
				comicNum = i;
				break;
			}
		}
			
		print(comicNum);
	}

	public void MoveScene(int n){

		if(comicNum < 0){
			return;
		}

		comicScenes[comicNum].MoveScene(n);
	}
}
