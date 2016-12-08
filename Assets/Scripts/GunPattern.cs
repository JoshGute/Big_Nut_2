/*******************************  SpaceTube  *********************************
Author: Glen Aro
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   GunPattern.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class GunPattern : MonoBehaviour {

    public string sOwner;

    public BulletScript[] aBullets;

    public float fFireRate;

    public int iBulletsPerTick;
    private float fCoolDown;
    public float fLifeTime;
    private float fTimeAlive;

    void Start()
    {

    }

    void Update()
    {
        fCoolDown += Time.deltaTime;
        fTimeAlive += Time.deltaTime;

        if(fCoolDown >= fFireRate)
        {
            for(int i = 0; i < iBulletsPerTick; i++)
            {
                GameObject newBullet;
                newBullet = Instantiate(aBullets[i].gameObject, transform.position, transform.rotation) as GameObject;
                //print(sOwner);
                newBullet.GetComponent<BulletScript>().sOwner = sOwner;
                //aBullets[i].sOwner = sOwner;
            }

            fCoolDown = 0;
        }

        if (fTimeAlive >= fLifeTime)
        {
            Destroy(gameObject);
        }
    }
}
