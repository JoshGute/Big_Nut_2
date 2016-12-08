/*******************************  SpaceTube  *********************************
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

public class GunScript : MonoBehaviour
{
    public string sOwner;

    public GameObject PatternSpawn;

    public float fFireRate;
    public float fTimerForNext = 0;
    //private bool bShot = true;

    public GunPattern gBulletPattern;

    public AudioClip ShootingNoise;
    public AudioClip ReloadNoise;
    public AudioClip MissNoise;

    public AudioSource RobotAudioSource;

    void Update()
    {
        if (fTimerForNext < fFireRate)
        {
            fTimerForNext += Time.deltaTime;
        }
    }

    public virtual void Shoot()
    {
        if (fTimerForNext >= fFireRate)
        {
            RobotAudioSource.PlayOneShot(ShootingNoise);
            GameObject bulletPattern = Instantiate(gBulletPattern.gameObject, PatternSpawn.transform.position, transform.rotation) as GameObject;
            bulletPattern.GetComponent<GunPattern>().sOwner = sOwner;
            fTimerForNext = 0;
        }
    }
}
