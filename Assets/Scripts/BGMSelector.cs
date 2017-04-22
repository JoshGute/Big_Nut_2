using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSelector : MonoBehaviour {
    public AudioClip[] Tracks;
    public AudioSource BGMplayer;
	// Use this for initialization
	void Start () 
    {
        BGMplayer.PlayOneShot(Tracks[Random.RandomRange(0, Tracks.Length)]);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
