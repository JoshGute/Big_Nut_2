/*******************************  Ducks in a Row  *********************************
Author: Josh 'is Dead' Gutenberg
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   DeathScript.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    private GameObject cCamera;

	// Use this for initialization
	void Start ()
    {
        cCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cCamera.GetComponent<FollowCam>().Shake(3f);
        StartCoroutine(timedDestroy(2));

        foreach (Transform child in transform)
        {
            if (child.GetComponent<Rigidbody>())
            {
                child.GetComponent<Rigidbody>().AddExplosionForce(5000, child.transform.position, 20.0f);
                child.SetParent(null);
            }
        }
	}

    private IEnumerator timedDestroy(int iWaitTime)
    {
        yield return new WaitForSeconds(iWaitTime);
        Destroy(gameObject);
    }
}
