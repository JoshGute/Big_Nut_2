/*******************************  SpaceTube  *********************************
Author: Josh 'Avoids Contact' Gutenberg
Contributors: Glen Aro
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   Spawnpoint.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour
{
    public bool bIsSafe = true;

    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.gameObject.layer == 11)
        {
            //print("sawn unsafe");
            bIsSafe = true;
        }
    }

    void OnTriggerStay(Collider Coll)
    {
        if(Coll.gameObject.layer == 10)
        {
            //print("sawn unsafe");
            bIsSafe = false;
        }
    }

    void OnTriggerExit(Collider Coll)
    {
        if (Coll.gameObject.layer == 10)
        {
            //print("sawn safe");
            bIsSafe = true;
        }
    }

}
