/*******************************  Ducks in a Row  *********************************
Author: Josh 'welp' Gutenberg
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   EnvironmentModifier.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentModifier : MonoBehaviour
{
    public float fSpeedModifier = 0.5f;

    void OnTriggerStay(Collider trigger)
    {
        if (trigger.tag == "Player1" || trigger.tag == "Player2")
        {
            trigger.GetComponent<Rigidbody>().velocity = trigger.GetComponent<Rigidbody>().velocity * fSpeedModifier;
        }
    }
}
