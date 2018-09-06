﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour
{
    private List<Behaviour> _lights;

    // Use this for initialization
    void Start () {
        _lights = GameObject
            .FindGameObjectsWithTag("Lights")
            .Select(go => go.GetComponent<Behaviour>())
            .ToList();

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
            foreach (var l1 in _lights)
            {
                var light1 = (Light)l1;
                light1.intensity = texture.IsPaused ? 2f : 0.2f;
            }
        }
    }
}
