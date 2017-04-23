/*******************************  Ducks in a Row  *********************************
Author: Josh ':(' Gutenberg
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   HealthPowerUp.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public GameObject gExplosion;

    public delegate void PowerUpAction(string sOwner_);
    public static event PowerUpAction PowerUpCollected;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<PlayerControllerVer2>())
        {
            if (coll.gameObject.GetComponent<PlayerControllerVer2>().iHealth < 3)
            {
                coll.gameObject.GetComponent<PlayerControllerVer2>().iHealth += 1;
                PowerUpCollected(coll.gameObject.GetComponent<PlayerControllerVer2>().sOwner);

                Instantiate(gExplosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
