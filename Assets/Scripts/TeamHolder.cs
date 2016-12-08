/*******************************  SpaceTube  *********************************
Author:Josh 'Avoids Contact' Gutenberg
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   TeamHolder.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class TeamHolder : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
