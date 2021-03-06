﻿/*******************************  SpaceTube  *********************************
Author: Glen Aro
Contributors: Josh 'Avoids Contact' Gutenberg, Linus 'Uh' Chan
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
    private tk2dSpriteAnimator BulletAnimator;

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
        BulletAnimator = gameObject.GetComponentInChildren<tk2dSpriteAnimator>();

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
        if (trigger.gameObject.layer != 5 && trigger.gameObject.layer != 2)
        {
            //print("In There " + trigger.gameObject.layer);
            if(trigger.gameObject.layer == 10 && trigger.gameObject.GetComponent<PlayerControllerVer2>())
            {
                //print("Play? " + trigger.gameObject.layer);
                if (trigger.gameObject.GetComponent<PlayerControllerVer2>().sOwner == sOwner)
                {
                    //print("Hit SELF");
                    return;
                }
            }

            else
            {
                //print("working as intended " + trigger.gameObject.layer);
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
        StartCoroutine(PoofBullet());
    }

    private IEnumerator PoofBullet()
    {
        BulletAnimator.Play("Bullet_Die");
        yield return new WaitForSeconds(BulletAnimator.ClipTimeSeconds);
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
