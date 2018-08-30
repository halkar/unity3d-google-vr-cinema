using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour {

    private Renderer myRenderer;

    public Material inactiveMaterial;
    public Material gazedAtMaterial;

    // Use this for initialization
    void Start () {
        myRenderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
        }
    }

    public void OnPlay(BaseEventData data)
    {
        var texture = data.selectedObject.GetComponent<GvrVideoPlayerTexture>();
        texture.Play();
        Console.Write("1");
    }
}
