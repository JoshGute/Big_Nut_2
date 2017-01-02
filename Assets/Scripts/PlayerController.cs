/******************************* Ducks in a Row *********************************
Author: Josh 'Big G' Gutenberg
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   PlayerController.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour
{
    public PlayerIndex playerIndex;

    private float KeyAxisH;
    private float KeyAxisV;

    private float rotateAxisH;
    private float rotateAxisV;

    public string Horizontal = "Horizontal_P1";
    public string Vertical = "Vertical_P1";
    public string Shoot = "Shoot_P1";
    public string Stab = "Stab_P1";
    public string Jump = "Jump_P1";

    public bool bDisabled = false;

    public BodyScript bBody;
    public GunScript gGun;
    public DashScript dDash;
    public AnimationController aController;

    private GamePadState state;
    private GamePadState prevState;

    private bool bController;
    private bool bRunning = false;
    private bool bDashing = false;

    void Update ()
    {
        if (!bDisabled)
        {
            GamePadState testState = GamePad.GetState(playerIndex);
            if (testState.IsConnected)
            {
                bController = true;
            }
            else if (!testState.IsConnected)
            {
                bController = false;
            }

            if(!bController)
            {
                KeyAxisH = Input.GetAxis(Horizontal);
                KeyAxisV = Input.GetAxis(Vertical);


                if (Input.GetButtonDown(Jump))
                {
                    inputManager(1);
                }
                if (Input.GetButtonDown(Shoot))
                {
                    inputManager(2);
                }
                if (Input.GetButtonDown(Stab))
                {
                    inputManager(3);
                }
            }

            else if(bController)
            {
                prevState = state;
                state = GamePad.GetState(playerIndex);
                KeyAxisH = state.ThumbSticks.Left.X;
                KeyAxisV = state.ThumbSticks.Left.Y;
                rotateAxisH = state.ThumbSticks.Right.X;
                rotateAxisV = state.ThumbSticks.Right.Y;

                if (prevState.Triggers.Left > 0.1f && state.Triggers.Left == 0)
                {
                    inputManager(1);
                }
                if (prevState.Triggers.Right > 0.1f && state.Triggers.Right == 0)
                {
                    aController.changeAnimation(3);
                    inputManager(2);
                }

                if (prevState.Buttons.Back == ButtonState.Released && state.Buttons.Back == ButtonState.Pressed)
                {
                    inputManager(4);
                }
            }
            //this is all movement unfortunately. 
            if (KeyAxisV != 0 && !bDashing)
            {
                bBody.rb.velocity = new Vector3(bBody.rb.velocity.x, (KeyAxisV * bBody.fMoveSpeed * Time.deltaTime), bBody.rb.velocity.z);
            }

            if (KeyAxisH != 0)
            {
                if (!bRunning)
                {
                    aController.changeAnimation(1);
                    bRunning = true;
                }
               
                if (KeyAxisH > 0 && !bDashing)
                {
                    bBody.rb.velocity = new Vector3((KeyAxisH * bBody.fMoveSpeed * Time.deltaTime), bBody.rb.velocity.y, bBody.rb.velocity.z);
                    bBody.transform.localEulerAngles = new Vector3(bBody.transform.rotation.x, 90, bBody.transform.rotation.z);
                }
                else if (KeyAxisH < 0 && !bDashing)
                {
                    bBody.rb.velocity = new Vector3((KeyAxisH * bBody.fMoveSpeed * Time.deltaTime), bBody.rb.velocity.y, bBody.rb.velocity.z);
                    bBody.transform.localEulerAngles = new Vector3(bBody.transform.rotation.x, -90, bBody.transform.rotation.z);
                }
            }

            else if(KeyAxisH == 0)
            {
                if (bRunning)
                {
                    aController.changeAnimation(2);
                    bRunning = false;
                }
            }

            //handles rotation
            if (rotateAxisH != 0 || rotateAxisV != 0)
            {
                print("aaa");
                gGun.transform.rotation = Quaternion.LookRotation(gGun.transform.forward + new Vector3(rotateAxisH, rotateAxisV, 0), gGun.transform.up);
            }
        }
    }

    private void inputManager(int iInput_)
    {
        switch (iInput_)
        {
            case 1:
                {
                    if(bBody.bGrounded)
                    {
                        bBody.rb.velocity = new Vector3(0, bBody.fJumpSpeed, 0);
                    }
                    else if(!bBody.bGrounded && bBody.iJumps > 0)
                    {
                        StartCoroutine(Dash(bBody.fDashTime));
                        bBody.rb.velocity = new Vector3(KeyAxisH, KeyAxisV, 0) * bBody.fJumpSpeed * 2;
                        --bBody.iJumps;
                    }
                    break;
                }
            case 2:
                {
                    gGun.Shoot();
                    break;
                }
            case 3:
                {
                    //sSword.StartCoroutine("Stab");
                    break;
                }
            case 4:
                {
                    bBody.Explode();
                    //bDisabled = true;
                    break;
                }  
        }
    }

    public void TagRobot(GameObject gRobot_)
    {
        bDisabled = false;
        bBody = gRobot_.GetComponent<BodyScript>();
        gGun = gRobot_.GetComponentInChildren<GunScript>();
        dDash = gRobot_.GetComponentInChildren<DashScript>();

        if(gRobot_.GetComponentInChildren<AnimationController>())
        {
            aController = gRobot_.GetComponentInChildren<AnimationController>();
        }

        //this is super superfulous(fuck spelling lmao) and and probably be made into tags. - josh
        //actually it is still useful so we are using it again - linus
        //this is correct - Josh

        bBody.sOwner = tag;
        gGun.sOwner = tag;
        dDash.sOwner = tag;

        bBody.tag = tag;
        gGun.tag = tag;
        dDash.tag = tag;   
    }

    IEnumerator Dash(float dashTime)
    {
        bBody.rb.useGravity = false;
        bDashing = true;
        dDash.gameObject.GetComponent<BoxCollider>().enabled = true;
        dDash.gameObject.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(dashTime);
        bBody.rb.useGravity = true;
        bBody.rb.velocity = new Vector3(0, 0, 0);
        bDashing = false;
        dDash.gameObject.GetComponent<BoxCollider>().enabled = false;
        dDash.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
