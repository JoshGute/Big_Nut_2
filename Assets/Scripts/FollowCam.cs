/*******************************  SpaceTube  *********************************
Author: Josh 'Avoids Contact' Gutenberg
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   FollowCam.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour
{
    //follow camera variables
    public bool bFollow = false;
    public Vector3 target;
    public GameObject gPlayer1;
    public GameObject gPlayer2;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    //screen shake variables
    public float ShakeAmount = 0.5f;
    private bool bShake;

    void Start()
    {
        bShake = false;
    }

    public void GetTarget(GameObject gPlayer_, int iPlayer_)
    {
        if (iPlayer_ == 1)
        {
            gPlayer1 = gPlayer_;
        }

        else
        {
            gPlayer2 = gPlayer_;
        }

        bFollow = true;
    }

    private void LateUpdate()
    {
        if (bFollow)
        {
            target = (gPlayer1.transform.position + gPlayer2.transform.position) * 0.5f;
            transform.position = target + offset;
        }

        if (bShake && Time.timeScale != 0)
        {
            transform.position = transform.position + Random.insideUnitSphere * ShakeAmount;
        }
    }

    public void Shake(float fShakeAmount_)
    {
        StartCoroutine(ScreenShaker(fShakeAmount_));
    }

    IEnumerator ScreenShaker(float fShakeAmount_)
    {
        ShakeAmount = fShakeAmount_;
        bShake = true;
        yield return new WaitForSeconds(0.25f);
        ShakeAmount = 0.5f;
        bShake = false;
    }
}
