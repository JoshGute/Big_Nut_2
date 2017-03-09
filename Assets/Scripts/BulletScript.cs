/*******************************  SpaceTube  *********************************
Author: Glen Aro
Contributors: Josh 'Avoids Contact' Gutenberg
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   BulletScript.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public float MaxDistance;
    //Change the y value only. 1.0 = 90 degress facing top of screen.
    public Vector3 Direction = new Vector3(0,0,0);
    private Vector3 StartPos;

    public string sOwner;
    public float fSpeed = 10.0f;
    private Rigidbody rb;

    public bool BlowUpWithTime;
    public float TimeToBlowUp;

    [SerializeField]
    private float fDamage;

    public float Damage
    {
      get
      {
        return fDamage;
      }
    }

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        if(Direction.y == 0)
        {
            Direction = transform.forward;
        }
        StartPos = transform.position;

        foreach (BulletScript kiddbullet in GetComponentsInChildren<BulletScript>())
        {
            kiddbullet.sOwner = sOwner;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.velocity = Direction * fSpeed;

        if (Vector3.Distance(transform.position, StartPos) >= MaxDistance)
        {
            //print("Distance dead");
            KillBullet();
        }

        if (BlowUpWithTime)
        {
            TimeToBlowUp -= Time.deltaTime;
            if (TimeToBlowUp <= 0)
            {
                //print("Time Dead");
                KillBullet();
            }
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.layer != 5)
        {
            if(trigger.gameObject.layer == 10 && trigger.gameObject.GetComponent<PlayerControllerVer2>())
            {
                if (trigger.gameObject.GetComponent<PlayerControllerVer2>().sOwner == sOwner)
                {
                    return;
                }
            }

            else
            {
                KillBullet();
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != sOwner && col.gameObject.layer != 0 && BlowUpWithTime)
        {
            //print("Col enter");
            KillBullet();
        }
    }

    void KillBullet()
    {
        transform.DetachChildren();
        Destroy(gameObject); 
    }
}
