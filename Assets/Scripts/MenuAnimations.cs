/*******************************  Ducks in a Row  *********************************
Author: Matty Lanouette
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   MenuAnimations.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;

    public GameObject Me;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayAnimaion()
    {
        Me.GetComponent<Animator>().enabled = true;
    }

    public void StopAnimation()
    {
        Me.GetComponent<Animator>().enabled = false;
    }

}
