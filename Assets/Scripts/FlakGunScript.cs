/*******************************  Ducks in a Row  *********************************
Author: Glen 'Guns guns guns' Aro
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   FlakGunScript.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakGunScript : BulletScript {

    //public float MaxDistance;
    //Change the y value only. 1.0 = 90 degress facing top of screen.
    //public Vector3 Direction = new Vector3(0, 0, 0);
    private Vector3 StartPos2;

    //public string sOwner;
    //public float fSpeed = 10.0f;
    private Rigidbody rb2;

    public GameObject[] BulletsToSpawn;
    public float AnglePerBullet;

    /*
    [SerializeField]
    private float fDamage;

    public float Damage
    {
        get
        {
            return fDamage;
        }
    }
    */
    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        if (Direction.y == 0)
        {
            Direction = transform.forward;
        }
        StartPos2 = transform.position;
    }

    void Update()
    {
        rb2.velocity = Direction * fSpeed;

        if (Vector3.Distance(transform.position, StartPos2) >= MaxDistance)
        {
            ExplodeTheFlak();
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.layer != 5 && trigger.gameObject.layer != 2)
        {
            if (trigger.gameObject.layer == 10 && trigger.gameObject.GetComponent<PlayerControllerVer2>())
            {
                if (trigger.gameObject.GetComponent<PlayerControllerVer2>().sOwner == sOwner)
                {
                    return;
                }
            }

            else
            {
                ExplodeTheFlak();
            }
        }
    }

    void ExplodeTheFlak()
    {
        for (int j = 0; j < BulletsToSpawn.Length; j++)
        {
            GameObject newBullet;

            newBullet = Instantiate(BulletsToSpawn[j].gameObject, transform.position, transform.rotation) as GameObject;

            newBullet.GetComponent<BulletScript>().sOwner = sOwner;
        }
        //transform.DetachChildren();
        Destroy(gameObject);
    }
}

