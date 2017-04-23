/*******************************  Ducks in a Row  *********************************
Author: Glen Aro
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   BGMSelector.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
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
