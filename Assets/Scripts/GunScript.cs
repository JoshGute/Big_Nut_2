﻿/*******************************  SpaceTube  *********************************
Author: Glen Aro
Contributors: Linus Chan, Josh 'Avoids Contact' Gutenberg
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   GunScript.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public string sOwner;

    public GameObject PatternSpawn;

    public float fFireRate;
    private float fTimeSinceLastShot;
    private bool bShot = false;

    public GameObject[] BulletsShotPerTick;

    public int iNumberofTicks;
    public float fLengthOfTick;
    public float fBulletSpacing;

    public AudioClip ShootingNoise;
    public AudioClip ReloadNoise;
    public AudioClip MissNoise;

    public AudioSource RobotAudioSource;

    public tk2dSprite Reticle;
    public RectTransform GunBar;

    void Update()
    {
        if (bShot)
        {
            fTimeSinceLastShot += Time.deltaTime;

            if (fTimeSinceLastShot >= fFireRate)
            {
                bShot = false;
                RobotAudioSource.PlayOneShot(ReloadNoise);
                //Reticle.color = Color.white;
                fTimeSinceLastShot = 0;
            }
        }
        Reticle.color = new Vector4(1, 1, 1, (fTimeSinceLastShot / fFireRate));
        print(fTimeSinceLastShot / fFireRate);
    }

    public virtual void Shoot()
    {
        if (!bShot)
        {
            StartCoroutine(ShootingGun());
            bShot = true;
            //Reticle.color = Color.clear;
        }
    }

    private IEnumerator ShootingGun()
    {
        for (int i = 0; i < iNumberofTicks; i++)
        {
            
            for (int j = 0; j < BulletsShotPerTick.Length; j++)
            {
                GameObject newBullet;

                newBullet = Instantiate(BulletsShotPerTick[j].gameObject, PatternSpawn.transform.position, 
                                                                          PatternSpawn.transform.rotation) as GameObject;
                if (newBullet.GetComponent<BulletScript>())
                {
                    newBullet.GetComponent<BulletScript>().sOwner = sOwner;
                }
                else
                {
                    newBullet.GetComponent<FlakGunScript>().sOwner = sOwner;
                }
                

                yield return new WaitForSeconds(fBulletSpacing);
            }

            yield return new WaitForSeconds(fLengthOfTick); 
        }

        yield return new WaitForSeconds(0f);
    }
}
