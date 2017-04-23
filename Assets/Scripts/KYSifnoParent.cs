/*******************************  Ducks in a Row  *********************************
Author: Josh 'KYS' Gutenberg
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   KYSifnoParent.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYSifnoParent : MonoBehaviour
{
	// Update is called once per frame
    public bool TimedDeath = false;
    public float Timer = 2;
	void Update ()
    {
		if(GetComponentInParent<BulletScript>() == null)
        {
            if (TimedDeath)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    TimedDeath = false;
                }
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
	}
}
