/*******************************  SpaceTube  *********************************
Author: Glen Aro
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   CBoy_Gun.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class CBoy_Gun : GunScript
{
    public int iMaxRounds = 6;
    public float fReloadSpeed;
    public float fReloadTimer;
    private int iBullets = 6;

    void Update()
    {
        if(RobotAudioSource)
        {
            if (fTimerForNext < fFireRate)
            {
                fTimerForNext += Time.deltaTime;
            }

            if (iBullets < iMaxRounds)
            {
                fReloadTimer += Time.deltaTime;
                if (fReloadTimer >= fReloadSpeed)
                {
                    RobotAudioSource.PlayOneShot(ReloadNoise);
                    iBullets += 1;
                    fReloadTimer = 0;
                    //print(iBullets);
                }
            }
        }
    }

    public override void Shoot()
    {
        if (fTimerForNext >= fFireRate && iBullets > 0)
        {
            //print("umm");
            RobotAudioSource.PlayOneShot(ShootingNoise);
            GameObject bulletPattern;
            bulletPattern = Instantiate(gBulletPattern.gameObject, PatternSpawn.transform.position, transform.rotation) as GameObject;
            bulletPattern.GetComponent<GunPattern>().sOwner = sOwner;
            fTimerForNext = 0;
            iBullets -= 1;
        }
    }
}
