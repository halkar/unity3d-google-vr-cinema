using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnReadyBehavior : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        this.GetComponent<GvrVideoPlayerTexture>().SetOnVideoEventCallback(onEvent);
    }

    // Update is called once per frame
	void Update () {
		
	}

    private void onEvent(int eventId)
    {
        if (eventId == (int)GvrVideoPlayerTexture.VideoEvents.VideoReady)
        {
            GetComponent<GvrVideoPlayerTexture>().Play();
        }
    }
}