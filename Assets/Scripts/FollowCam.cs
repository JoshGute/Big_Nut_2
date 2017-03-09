/*******************************  SpaceTube  *********************************
Author: Josh Gutenberg
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
    public float targetZoom;
    public GameObject gPlayer1;
    public GameObject gPlayer2;
    public Vector3 offset = new Vector3(0f, 0f, -400);
    //screen shake variables
    public float ShakeAmount = 0.5f;
    public GameObject ShortBorder;
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
            if (gPlayer1 && gPlayer2)
            {
                target = (gPlayer1.transform.position + gPlayer2.transform.position) * 0.5f;
                target.z = offset.z;

                transform.position = Vector3.Lerp(transform.position, target, 100f);

                Vector3 NoZTarget = new Vector3(target.x, target.y, 0);

                print(Vector3.Normalize(NoZTarget));

                //ShortBorder.transform.position += Vector3.Normalize(NoZTarget) * 2;

                ShortBorder.transform.position = Vector3.Lerp(transform.position, NoZTarget, 100f);
                
                /*targetZoom = target.magnitude;

                target = new Vector3(target.x, target.y, targetZoom);
                target += offset;

                if (target.z > -300)
                {
                    target = new Vector3(target.x, target.y, -300);
                    transform.position = Vector3.Lerp(transform.position, target, 100f);
                }

                else
                {
                    transform.position = Vector3.Lerp(transform.position, target, 100f);

                    //Vector3 billy = new Vector3(transform.position.x);

                    Vector3 NoZPosition = new Vector3(transform.position.x, transform.position.y, 0);
                    Vector3 NoZTarget = new Vector3(target.x, target.y, 0);

                    ShortBorder.transform.position += Vector3.Normalize(NoZTarget);
                }*/
            }
             
            else
            {
                bFollow = false;
            }

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
        yield return new WaitForSeconds(0.5f);
        bShake = false;
    }
}
