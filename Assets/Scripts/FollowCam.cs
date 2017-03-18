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
    public bool bZoom = false;
    public Vector3 target;
    public float targetZoom;
    public GameObject gPlayer1;
    public GameObject gPlayer2;
    public Vector3 offset = new Vector3(0f, 0f, -400);
    //screen shake variables
    public float ShakeAmount = 0.5f;
    public int MaxZoomIn = 100;
    public int MinZoomOut = 350;
    public float ZoomInRate;
    public float ZoomOutRate;
    public GameObject ShortBorder;
    public float OldTargetDistance;
    private bool bShake;

    public GameObject BackGroundImage;

    void Start()
    {
        bShake = false;
        transform.position = offset;
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
                float NewTargetDistance = Vector3.Distance(gPlayer1.transform.position,
                                                           gPlayer2.transform.position);

                target = (gPlayer1.transform.position + gPlayer2.transform.position) * 0.5f;
                target.z = transform.position.z;

                Vector3 NoZTarget = new Vector3(target.x, target.y, 0);

                //print(NewTargetDistance);

                if (NewTargetDistance > (OldTargetDistance + 1) && transform.position.z > (offset.z - MaxZoomIn))
                {
                    //print("Bigger");
                    target.z -= 7;
                    BackGroundImage.transform.position = new Vector3(BackGroundImage.transform.position.x, BackGroundImage.transform.position.y, BackGroundImage.transform.position.z - 7);

                }
                else if (NewTargetDistance < (OldTargetDistance - 1) && transform.position.z < (offset.z + MinZoomOut))
                {
                    //print("Smaller");
                    target.z += 4;
                    BackGroundImage.transform.position = new Vector3(BackGroundImage.transform.position.x, BackGroundImage.transform.position.y, BackGroundImage.transform.position.z + 4);
                }

                transform.position = Vector3.Lerp(transform.position, target, 100f);

                ShortBorder.transform.position = Vector3.Lerp(transform.position, NoZTarget, 100f);

                //BackGroundImage.transform.position = Vector3.Lerp(BackGroundImage.transform.position, new Vector3(BackGroundImage.transform.position.x,
                                                                                                                  //BackGroundImage.transform.position.y, target.z), 100f);

                OldTargetDistance = NewTargetDistance;
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
