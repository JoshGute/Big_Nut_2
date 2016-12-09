/*******************************  DucksInARow  *********************************
Author: Glen Aro
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   PressAtoPlay.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class PressAtoPlay : MonoBehaviour {

    public string LeveltoLoad;
	// Update is called once per frame
	void Update ()
    {
        if(Input.anyKeyDown)
        {
            RebuildLevel(LeveltoLoad);
        }
	
	}

    public void RebuildLevel(string sLevelToLoad)
    {
        Application.LoadLevel(sLevelToLoad);
    }
}
