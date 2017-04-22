/*******************************  SpaceTube  *********************************
Author: Josh 'why am I so tired' Gutenberg
Contributors: Glen Aro
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
    public int MaxZoomIn = 150;
    public int MinZoomOut = 150;
    public float ZoomInRate;
    public float ZoomOutRate;
    public GameObject ShortBorder;
    private float OldTargetDistance;
    private bool bShake;
    public float XCap;
    public float YCap;

    private float ZOOMINCAP;
    private float ZOOMOUTCAP;

    private bool CanZoomIn = true;
    private Vector3 PositionToResetToAfterDeath;

    public GameObject BackGroundImage;

    void OnEnable()
    {
        PlayerControllerVer2.Die += DeadZoom;
    }

    void OnDisable()
    {
        PlayerControllerVer2.Die -= DeadZoom;
    }

    void Start()
    {
        bShake = false;
        transform.position = offset;
        ChangeCameraOffest(offset.z);
        bFollow = true;
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
    }

    private void LateUpdate()
    {
        if (bFollow)
        {
            if (gPlayer1 && gPlayer2)
            {
                //determines how far apart the players are.
                float NewTargetDistance = Vector3.Distance(gPlayer1.transform.position,
                                                           gPlayer2.transform.position);

                //Sets the target point between the players
                target = (gPlayer1.transform.position + gPlayer2.transform.position) * 0.5f;

                //makes sure our Z doesn't change normally.
                target.z = transform.position.z;

                //Check our declared boundaries. 
                if (target.x >= XCap || target.x <= -XCap)
                {
                    if (target.x >= XCap)
                    {
                        target.x = XCap;
                    }
                    else
                    {
                        target.x = -XCap;
                    }
                    CanZoomIn = false;
                }

                //Check our declared boundaries. 
                if (target.y >= YCap || target.y <= -YCap)
                {
                    if (target.y >= YCap)
                    {
                        target.y = YCap;
                    }
                    else
                    {
                        target.y = -YCap;
                    }
                    CanZoomIn = false;
                }

                //Sets the position to move the ShortBorder to.
                Vector3 NoZTarget = new Vector3(target.x, target.y, 0);

                //Checks if our distance has expanded and if we are too zoomed out.
                if (NewTargetDistance > (OldTargetDistance + 1) && transform.position.z > ZOOMOUTCAP)
                {
                    target.z -= ZoomOutRate;
                    //BackGroundImage.transform.position = new Vector3(BackGroundImage.transform.position.x, BackGroundImage.transform.position.y, BackGroundImage.transform.position.z - ZoomOutRate);
                }

                //Checks if our distance decreased and if we are too zoomed out.
                else if (CanZoomIn && NewTargetDistance < (OldTargetDistance - 1) && transform.position.z < ZOOMINCAP)
                {
                    target.z += ZoomInRate;
                    //BackGroundImage.transform.position = new Vector3(BackGroundImage.transform.position.x, BackGroundImage.transform.position.y, BackGroundImage.transform.position.z + ZoomInRate);
                }

                transform.position = Vector3.Lerp(transform.position, target, 100f);

                ShortBorder.transform.position = Vector3.Lerp(transform.position, NoZTarget, 100f);

                OldTargetDistance = NewTargetDistance;

                CanZoomIn = true;
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

    //Used to change the offset for the camera and the zoom maximum
    public void ChangeCameraOffest(float INfNewOffset)
    {
        offset.z = INfNewOffset;
        ZOOMINCAP = offset.z + MaxZoomIn;
        ZOOMOUTCAP = offset.z - MinZoomOut;
    }

    private void DeadZoom(string sOwner_)
    {
        PositionToResetToAfterDeath = transform.position;
        bFollow = false;
        bShake = false;

        if (sOwner_ == "PLAYER1")
        {
            StartCoroutine(ZoomingIn(gPlayer1.transform.position));
        }

        else
        {
            StartCoroutine(ZoomingIn(gPlayer2.transform.position));
        }
    }

    IEnumerator ZoomingIn(Vector3 vTarget)
    {
        transform.position = new Vector3(vTarget.x, vTarget.y, -60);
        //BackGroundImage.transform.position = new Vector3(BackGroundImage.transform.position.x, BackGroundImage.transform.position.y, BackGroundImage.transform.position.z -150);
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        transform.position = PositionToResetToAfterDeath;
        bFollow = true;       
    }

    IEnumerator ScreenShaker(float fShakeAmount_)
    {
        ShakeAmount = fShakeAmount_;
        bShake = true;
        yield return new WaitForSeconds(0.5f);
        bShake = false;
    }
}
