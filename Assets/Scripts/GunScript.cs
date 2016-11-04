﻿using UnityEngine;
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