using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public int[] sceneCounts;

	int comicNum = 2;
	int sceneNum = 0;

    void Start()
    {
		if(instance == null){
			instance = this;
		}
		else{
			Destroy(this.gameObject);
		}
    }

	public void MoveScene(int n){
		sceneNum = Mathf.Clamp(sceneNum + n, 0, sceneCounts[comicNum] - 1);
		print(sceneNum);
	}
}
