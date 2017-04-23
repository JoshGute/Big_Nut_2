/*******************************  Ducks in a Row  *********************************
Author: Josh 'Gibs 24/7' Gutenberg
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   GibScript.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibScript : MonoBehaviour
{
    public GameObject[] Gibs;
    int randNum;

    public void SpawnGibs(int iHealth_)
    {
        for (int i = 0; i <= 6 -iHealth_; i++)
        {
            randNum = Random.Range(0, Gibs.Length);
            GameObject Gib = Instantiate(Gibs[randNum], new Vector3(transform.position.x + Random.insideUnitCircle.x, 
                transform.position.y + Random.insideUnitCircle.y, transform.position.z), Random.rotation) as GameObject;
            Gib.GetComponent<Rigidbody>().AddExplosionForce(5000, Gib.transform.position, 20.0f);
        }
    }
}
