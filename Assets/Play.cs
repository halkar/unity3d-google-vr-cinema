using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour {

    // Use this for initialization
    void Start () {
        SetGazedAt(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGazedAt(bool gazedAt)
    {
        var halo = (Behaviour)GetComponent("Halo");
        halo.enabled = gazedAt;
    }

    public void OnPlay(BaseEventData data)
    {
        var texture = GetComponent<GvrVideoPlayerTexture>();
        if (texture.VideoReady)
        {
            if (texture.IsPaused)
            {
                texture.Play();
            }
            else
            {
                texture.Pause();
            }
        }
    }
}
