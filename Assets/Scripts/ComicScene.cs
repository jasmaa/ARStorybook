using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ComicScene : MonoBehaviour, ITrackableEventHandler
{

	private TrackableBehaviour trackableBehaviour;
	public bool isTracking = false;
	public int currScene = 0;
	public int maxScenes;

    // Start is called before the first frame update
    void Start()
    {
		trackableBehaviour = GetComponent<TrackableBehaviour>();
		if(trackableBehaviour){
			trackableBehaviour.RegisterTrackableEventHandler(this);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void MoveScene(int n){
		currScene = Mathf.Clamp(currScene + n, 0, maxScenes);
	}

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
