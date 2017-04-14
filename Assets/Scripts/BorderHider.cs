using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHider : MonoBehaviour {

    public MeshRenderer ObjectToReveal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        ObjectToReveal.enabled = true;
    }

    void OnTriggerExit(Collider col)
    {
        ObjectToReveal.enabled = false;
    }
}
