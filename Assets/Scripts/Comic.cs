using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

/// <summary>
/// AR comic
/// </summary>
public class Comic : MonoBehaviour, ITrackableEventHandler
{

	private TrackableBehaviour trackableBehaviour;
	public bool isTracking = false;
	public int currSceneNum = 0;
	public string title;

	public GameObject[] comicScenes;
	private GameObject currScene;

    // Start is called before the first frame update
    void Start()
    {
		trackableBehaviour = GetComponent<TrackableBehaviour>();
		if(trackableBehaviour){
			trackableBehaviour.RegisterTrackableEventHandler(this);
		}

		// init comic scene
		currScene = Instantiate(comicScenes[currSceneNum], this.transform);
	}

	/// <summary>
	/// Moves scene n places
	/// </summary>
	/// <param name="n"></param>
	public void MoveScene(int n){

		if(currSceneNum + n < 0 || currSceneNum + n >= comicScenes.Length) {
			return;
		}

		currSceneNum += n;

		// Replace comic scene
		Destroy(currScene);
		currScene = Instantiate(comicScenes[currSceneNum], this.transform);
	}

	/// <summary>
	/// Detects if tracking current comic scene
	/// </summary>
	/// <param name="previousStatus"></param>
	/// <param name="newStatus"></param>
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED){

			isTracking = true;
		}
		else{
			isTracking = false;
		}
	}
}
