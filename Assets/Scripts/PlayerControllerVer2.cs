﻿/*******************************  Ducks in a Row  *********************************
Author: Linus 'Fills in the Blanks' Chan
Contributors: Glen Aro
Course: GAM450
Game:   Bolt Blitz
Date:   1/18/2017
File:   ImprovedDashScript.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerControllerVer2 : MonoBehaviour
{
  private Rigidbody Rb;
  private Transform Tr;

  public string sOwner;
  //Dashing
  [SerializeField]
  private Transform dashTargetPos;

  //Used to store an instance of the dash position to move towards
  private Vector3 curDashTargetPos;

  public GameObject DashHitbox;

  [SerializeField]
  private int maxDashes = 1;
  [SerializeField]
  private int curDashes = 0;
  [SerializeField]
  private float secDashRegenTime = 1f;

  [SerializeField]
  private float DashSpeed = 10f;

  private bool isDashing = false;

  private bool RegenDash = false;

  private enum RotateState { UpRight, Reverse }

  private RotateState curRotateState;
  private RotateState prevRotateState;

  private bool lockBoost = false;
  private bool lockShoot = false;

  //Turning
  [SerializeField]
  private float TurnSpeed = 5f;

  //Moving
  [SerializeField]
  private float maxSpeed = 25f;
  [SerializeField]
  private float Speed = 100f;

  private float regentime = 0f;

  public AnimationControllerVer2 aController;

  public GameObject Shield;

  //public int PlayerNumber;

  public PlayerIndex playerIndex;

  private GamePadState state;
  private GamePadState prevState;

  private float KeyAxisH;
  private float KeyAxisV;

  private float rotateAxisH;
  private float rotateAxisV;

  private bool bController;
  public bool bDisabled = false;

  private GunScript ShootScript;

  public int iHealth;
    public AudioSource asNoiseMaker;
    public AudioClip acHitNoise;

    public GameObject gDeathObject;

  private bool Shielding;
    ////Deprecated////
    //[SerializeField]
    //private float DashDistance = 5f;
    ////Deprecated////

    public delegate void DeathAction(string sOwner_);
    public static event DeathAction Die;

    // Use this for initialization
    void Start()
  {
    curDashes = maxDashes;

    Rb = GetComponent<Rigidbody>();
    Tr = GetComponent<Transform>();
    ShootScript = GetComponent<GunScript>();

    aController = GetComponent<AnimationControllerVer2>();
  }

  //Update is called once per frame.
  void Update()
  {
    if (Tr.rotation.eulerAngles.z >= 0 && Tr.rotation.eulerAngles.z < 180)
    {
      curRotateState = RotateState.UpRight;
    }

    else if (Tr.rotation.eulerAngles.z >= 180 && Tr.rotation.eulerAngles.z < 359)
    {
      curRotateState = RotateState.Reverse;
    }

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
    }

    if (!bController)
    {
      ////Dash logic////
      if (Input.GetKeyDown(KeyCode.X))
      {
        if (curDashes > 0)
        {
          curDashes -= 1;

          Dash();

          if (curDashes < maxDashes)
          {
            RegenDash = true;
          }
        }

        else
        {
          return;
        }
      }
    }

    /////DEPRECATED/////
    /*else if(bController)
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        if (prevState.Triggers.Left > 0.1f && state.Triggers.Left == 0)
        {
            curDashes -= 1;
            Dash();

            if (curDashes < maxDashes)
            {
                RegenDash = true;
            }
        }
        if (prevState.Triggers.Right > 0.1f && state.Triggers.Right == 0)
        {
            Shoot();
        }
    }*/

    if (RegenDash == true)
    {
      regentime += Time.deltaTime;

      if (regentime >= secDashRegenTime && curDashes < maxDashes)
      {
        regentime = 0f;
        curDashes += 1;
      }

      else if (regentime >= secDashRegenTime && curDashes == maxDashes)
      {
        //turn off regen
        RegenDash = false;
        //reset to 0
        regentime = 0f;
      }
    }

    if (isDashing == true)
    {
      DashHitbox.GetComponent<DashScript>().TurnOnDash();

      Tr.position = Vector3.MoveTowards(Tr.position, curDashTargetPos, DashSpeed);

      if (Tr.position == curDashTargetPos)
      {
        isDashing = false;
        DashHitbox.GetComponent<DashScript>().TurnOffDash();
        curDashTargetPos = Vector3.zero;
      }

    }
  }

  // Physics Update
  void FixedUpdate()
  {
    if (!bController)
    {
      Vector3 ShipDirection = new Vector3(0f, 1f, 0f);

      if (Input.GetKey(KeyCode.LeftArrow))
      {
        Tr.Rotate(new Vector3(0f, 0f, 1f), TurnSpeed);
      }

      if (Input.GetKey(KeyCode.RightArrow))
      {
        Tr.Rotate(new Vector3(0f, 0f, 1f), -TurnSpeed);
      }

      if (Input.GetKey(KeyCode.UpArrow))
      {
        //Animation
        if (curRotateState == RotateState.UpRight && prevRotateState != RotateState.UpRight)
        {
          //Rolling to Reverse
          aController.ChangeAnimation(1);
          prevRotateState = RotateState.UpRight;
        }

        else if (curRotateState == RotateState.Reverse && prevRotateState != RotateState.Reverse)
        {
          //Rolling back to UpRight
          aController.ChangeAnimation(2);
          prevRotateState = RotateState.Reverse;
        }

        Rb.AddRelativeForce(ShipDirection * Speed);
      }

      if (Rb.velocity.magnitude > maxSpeed)
      {
        Rb.velocity = Rb.velocity.normalized * maxSpeed;
      }
    }

    else if (bController)
    {
      prevState = state;
      state = GamePad.GetState(playerIndex);
      KeyAxisH = state.ThumbSticks.Left.X;
      KeyAxisV = state.ThumbSticks.Left.Y;
      rotateAxisH = state.ThumbSticks.Right.X;
      rotateAxisV = state.ThumbSticks.Right.Y;

      Vector3 ShipDirection = new Vector3(0f, 1f, 0f);

      //Dashing
      if (prevState.Triggers.Left > 0.1f && state.Triggers.Left == 0)
      {
        if(curDashes > 0)
        {
          curDashes -= 1;
          Dash();
        }

        if (curDashes < maxDashes)
        {
          RegenDash = true;
        }
      }

      //Shooting
      if (prevState.Triggers.Right > 0.1f && state.Triggers.Right == 0)
      {
        FireTheLasers();
      }

      //Shielding
      if (prevState.Buttons.RightShoulder == ButtonState.Pressed)
      {
        //lockBoost = true;

        lockShoot = true;

        Shield.GetComponent<ShieldScript>().TurnOnShield();
      }

      else if(prevState.Buttons.RightShoulder == ButtonState.Released)
      {
        //lockBoost = false;

        lockShoot = false;

        Shield.GetComponent<ShieldScript>().TurnOffShield();
      }

      if (KeyAxisH < 0)
      {
        Tr.Rotate(new Vector3(0f, 0f, 1f), TurnSpeed);
      }
      else if (KeyAxisH > 0)
      {
        Tr.Rotate(new Vector3(0f, 0f, 1f), -TurnSpeed);
      }

      //Boosting
      if (prevState.Buttons.A == ButtonState.Pressed && lockBoost == false)
      {
        //Animation
        if (curRotateState == RotateState.UpRight && prevRotateState != RotateState.UpRight)
        {
          //Rolling to Reverse
          aController.ChangeAnimation(1);
          prevRotateState = RotateState.UpRight;
        }

        else if (curRotateState == RotateState.Reverse && prevRotateState != RotateState.Reverse)
        {
          //Rolling back to UpRight
          aController.ChangeAnimation(2);
          prevRotateState = RotateState.Reverse;
        }

        //Function
        Rb.AddRelativeForce(ShipDirection * Speed);
      }

      if (Rb.velocity.magnitude > maxSpeed)
      {
        Rb.velocity = Rb.velocity.normalized * maxSpeed;
      }
    }

  }

  /* Dash Function
   * Change the 'y' pos of the dash target's translation if you want to change the distance traveled.
  */
  void Dash()
  {
    //Instant Dash
    /*
    Tr.position = dashTargetPos.position;
    */

    //Updating the position to dash towards;
    curDashTargetPos = dashTargetPos.position;

    isDashing = true;

    ////Deprecated////
    //Imperfect, but ultimately not needed because I realized I could just parent a target object the desired
    // dashdistance away and use that as the target pos to dash to.
    /*
    Vector3 DashPos = new Vector3(Mathf.Pow(((Tr.position.x + DashDistance) - Tr.position.x),2), Mathf.Pow(((Tr.position.y + DashDistance) - Tr.position.y),2), 
      Tr.position.z);

    Tr.position = DashPos;
    */
    ////Deprecated////
  }

  public void FireTheLasers()
  {
    if(lockShoot == false)
    {
      ShootScript.Shoot();
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Bullet" && collision.gameObject.GetComponent<BulletScript>().sOwner != sOwner 
      && !lockShoot)
    {
      TakeDamage();
    }
  }

  void OnTriggerEnter(Collider trigger)
  {
    //Being hit by Bullet
    if (trigger.gameObject.tag == "Bullet" && trigger.gameObject.GetComponent<BulletScript>().sOwner != sOwner
      && !lockShoot)
    {
      TakeDamage();
    }

    //Being hit by a Dash
    //(trigger is the hitbox attached to sword in this case. the info is in the sword arm parent so that's why do getcomponentinparent)
    else if (trigger.gameObject.name == "DashHitBox" && trigger.gameObject.GetComponentInParent<DashScript>().sOwner != sOwner)
    {
      TakeDamage();
      Rb.velocity = (trigger.transform.forward * trigger.gameObject.GetComponentInParent<DashScript>().fKnockback);
    }
  }

  void TakeDamage()
  {
    if (iHealth > 1)
    {
        asNoiseMaker.PlayOneShot(acHitNoise);
        StartCoroutine(Flash(gameObject.GetComponentInChildren<tk2dSprite>()));
        --iHealth;
      print("player hp" + iHealth);
    }

    else if (iHealth == 1)
    {      
      --iHealth;
      print("Dead");
      Explode();
    }
  }
    private void Explode()
    {
        Instantiate(gDeathObject, gameObject.transform.position, gameObject.transform.rotation);
        Die(sOwner);
        Destroy(gameObject);
    }

    private IEnumerator Flash(tk2dSprite Skin_)
    {
        Vector4 startingColor = new Vector4();
        startingColor = Skin_.color;

        Skin_.color = Color.black;
        yield return new WaitForSeconds(.05f);
        Skin_.color = startingColor;
    }

    public void TagRobot(string sOwner_)
    {
        sOwner = sOwner_;
        if (sOwner == "PLAYER1")
        {
            playerIndex = PlayerIndex.One;
        }
        else
        {
            playerIndex = PlayerIndex.Two;
        }
    }
}
