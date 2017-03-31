/*******************************  Ducks in a Row  *********************************
Author: Linus 'Fills in the Blanks' Chan
Contributors: Glen Aro, Josh Gutenberg
Course: GAM450
Game:   Bolt Blitz
Date:   1/18/2017
File:   PlayerControllerVer2.cs

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

  //Stores The distance between us and the target
  public float DashDistance = 200;

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

  public GameObject onHit;

  public GameObject AimRing;

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
    public ParticleSpawner particleSpawner;

    public tk2dSprite robotSkin;

  private bool Boosting;

  private bool Shielding;
    ////Deprecated////
    //[SerializeField]
    //private float DashDistance = 5f;
    ////Deprecated////

    public delegate void DeathAction(string sOwner_);
    public static event DeathAction Die;
    public delegate void HitAction (string sOwner_);
    public static event HitAction Hit;

    // Use this for initialization
    void Start()
  {
    curDashes = maxDashes;

    Rb = GetComponent<Rigidbody>();
    Tr = GetComponent<Transform>();
    ShootScript = GetComponent<GunScript>();

    aController = GetComponent<AnimationControllerVer2>();
        Hit(sOwner);
    //DashDistance = Vector3.Distance(Tr.position, dashTargetPos.position);
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

          //Dash();

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
        //Thruster Animation
        aController.ChangeThrusterAnimation(1);

        //Animation
        if (curRotateState == RotateState.UpRight && prevRotateState != RotateState.UpRight)
        {
          //Rolling to Reverse
          aController.ChangeBodyAnimation(1);
          prevRotateState = RotateState.UpRight;
        }

        else if (curRotateState == RotateState.Reverse && prevRotateState != RotateState.Reverse)
        {
          //Rolling back to UpRight
          aController.ChangeBodyAnimation(2);
          prevRotateState = RotateState.Reverse;
        }

        Rb.AddRelativeForce(ShipDirection * Speed);
      }

      else if (Input.GetKeyUp(KeyCode.UpArrow))
      {
        aController.ChangeThrusterAnimation(2);
      }

      if (Rb.velocity.magnitude > maxSpeed)
      {
        Rb.velocity = Rb.velocity.normalized * maxSpeed;
      }
    }

    else if (bController && !bDisabled)
    {
      prevState = state;
      state = GamePad.GetState(playerIndex);
      KeyAxisH = state.ThumbSticks.Left.X;
      KeyAxisV = state.ThumbSticks.Left.Y;
      rotateAxisH = state.ThumbSticks.Right.X;
      rotateAxisV = state.ThumbSticks.Right.Y;

      Vector3 ShipDirection = new Vector3(0f, 1f, 0f);

      //Dashing
      /*if (prevState.Triggers.Left > 0.1f && state.Triggers.Left == 0)
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
      }*/

      //NewDash
      if (prevState.ThumbSticks.Right.X == 0 && prevState.ThumbSticks.Right.Y == 0 && !Shielding)
      {
          if (rotateAxisH != 0 || rotateAxisV != 0)
          {
              if (curDashes > 0)
              {
                  curDashes -= 1;
                  Dash(rotateAxisH, rotateAxisV);
              }

              if (curDashes < maxDashes)
              {
                  RegenDash = true;
              }
              
          }
      }

      //Shooting
      if (prevState.Triggers.Right > 0.1f && state.Triggers.Right == 0)
      {
        FireTheLasers();
      }

      //Shockwave Animation purposes
      if (prevState.Triggers.Left > 0.1f)
      {
        if(Boosting == false)
        {
          Boosting = true;
          aController.PlayShockwaveAnimation();
        }
      }

      else if (prevState.Triggers.Left == 0)
      {
        Boosting = false;
      }

      //Shielding
      if (prevState.Buttons.RightShoulder == ButtonState.Pressed)
      {
                //lockBoost = true;
                Shielding = true;
        lockShoot = true;

        Shield.GetComponent<ShieldScript>().TurnOnShield();
      }

      else if(prevState.Buttons.RightShoulder == ButtonState.Released)
      {
                //lockBoost = false;
                Shielding = false;
        lockShoot = false;

        Shield.GetComponent<ShieldScript>().TurnOffShield();
      }

      if (KeyAxisH != 0 || KeyAxisV != 0)
      {
        float LookDirection = Mathf.Atan2(KeyAxisH, KeyAxisV);
                Tr.rotation = Quaternion.Euler(0f, 0f, -LookDirection * Mathf.Rad2Deg);
                /*Tr.rotation = Quaternion.LookRotation(Tr.right, Tr.up);
                Tr.LookAt(new Vector3(0f, 0f, LookDirection * Mathf.Rad2Deg));*/
      }

      //Boosting
     // if (state.Buttons.A == ButtonState.Pressed && lockBoost == false)
      if (state.Triggers.Left > 0.1f && lockBoost == false)
      {
                GamePad.SetVibration(playerIndex, 0.1f, 0.1f);
          //Thruster Animation
          aController.ChangeThrusterAnimation(1);

          //Body Animation
          if (curRotateState == RotateState.UpRight && prevRotateState != RotateState.UpRight)
          {
              //Rolling to Reverse
              aController.ChangeBodyAnimation(1);
              prevRotateState = RotateState.UpRight;
          }

          else if (curRotateState == RotateState.Reverse && prevRotateState != RotateState.Reverse)
          {
              //Rolling back to UpRight
              aController.ChangeBodyAnimation(2);
              prevRotateState = RotateState.Reverse;
          }

                //Function
          Rb.AddRelativeForce(ShipDirection * Speed * state.Triggers.Left);
      }



      //else if (prevState.Buttons.A == ButtonState.Pressed && state.Buttons.A == ButtonState.Released)
      else if (prevState.Triggers.Left > 0.1 && state.Triggers.Left < 0.1)
      {
        aController.ChangeThrusterAnimation(2);
                GamePad.SetVibration(playerIndex, 0 , 0);
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

  //void Dash()
  void Dash(float INfAxisH, float INfAxisV)
  {
        //Instant Dash
        /*
        Tr.position = dashTargetPos.position;
        */

        //Updating the position to dash towards;

        //////////////////////////////////////////////
        //OLD LINUS DASH LOGIC
        //KEPT FOR POSTERITY
        /*curDashTargetPos = dashTargetPos.position;

        isDashing = true;*/
        ///////////////////////////////////////////////////

        ////Deprecated////
        //Imperfect, but ultimately not needed because I realized I could just parent a target object the desired
        // dashdistance away and use that as the target pos to dash to.
        /*
        Vector3 DashPos = new Vector3(Mathf.Pow(((Tr.position.x + DashDistance) - Tr.position.x),2), Mathf.Pow(((Tr.position.y + DashDistance) - Tr.position.y),2), 
          Tr.position.z);

        Tr.position = DashPos;
        */
        ////Deprecated////

        //NEW DASH LOGIC
        Rb.velocity = Vector3.zero;

      Vector3 NormalizedAngle = Vector3.Normalize(new Vector3(rotateAxisH, rotateAxisV, 0));
      Vector3 InverseNorm = -NormalizedAngle;

      RaycastHit SmackIt;
      //print("H " + INfAxisH + " V " + INfAxisV);
      StartCoroutine(Vibrate(0.2f, 0.3f));
        StartCoroutine(Flash(robotSkin, Color.red));

        aController.PlayDashAnimation(NormalizedAngle);

      if (Physics.Raycast(transform.position, NormalizedAngle, out SmackIt, DashDistance))
      {
          curDashTargetPos = SmackIt.point + (InverseNorm * 2);
          isDashing = true;
      }
      else
      {
          //Physics.Raycast(transform.position, new Vector3(INfAxisH, INfAxisV, 0), 45);
          Vector3 FinalDestination = new Vector3(Tr.position.x + (NormalizedAngle.x * (DashDistance)),
                                             Tr.position.y + (NormalizedAngle.y * (DashDistance)), 0);
          //print(FinalDestination);
          curDashTargetPos = FinalDestination;
          isDashing = true;
      }
      ////
  }

  public void FireTheLasers()
  {
    if(lockShoot == false)
    {
      ShootScript.Shoot();
            StartCoroutine(Vibrate(0.2f, 0.3f));
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
        AimRing.GetComponent<AimRingAnimationController>().PlayHealthDamageAnim();

        Instantiate(onHit, transform.position, transform.rotation);
        asNoiseMaker.PlayOneShot(acHitNoise);
        //StartCoroutine(Flash(robotSkin, Color.gray));
        StartCoroutine(Vibrate(0.5f, 0.5f));
        --iHealth;
        Hit(sOwner);
            if (iHealth == 1)
            {
                particleSpawner.SpawnParticles();
            }
      //print("player hp" + iHealth);
    }

    else if (iHealth == 1)
    {      
      --iHealth;
      Hit(sOwner);
      //print("Dead");
      Explode();
    }
  }
    private void Explode()
    {
        Instantiate(gDeathObject, gameObject.transform.position, gameObject.transform.rotation);
        StartCoroutine(Vibrate(1, 1));
        StartCoroutine(Death());
    }

    private IEnumerator Flash(tk2dSprite Skin_, Vector4 Color_)
    {
        Vector4 startingColor = new Vector4();
        startingColor = Skin_.color;

        Skin_.color = Color_;
        yield return new WaitForSeconds(0.1f);
        Skin_.color = startingColor;
    }

    private IEnumerator Vibrate(float Intensity_, float Time_)
    {
        GamePad.SetVibration(playerIndex, Intensity_, Intensity_);
        yield return new WaitForSeconds(Time_);
        GamePad.SetVibration(playerIndex, 0, 0);
    }

    private IEnumerator Death()
    {
        robotSkin.color = Color.clear;
        bDisabled = true;
        Die(sOwner);
        Destroy(gameObject);
        return(null);
    }

    public void TagRobot(string sOwner_)
    {
        sOwner = sOwner_;
        if (sOwner == "PLAYER1")
        {
            playerIndex = PlayerIndex.One;
            GetComponent<GunScript>().sOwner = "PLAYER1";
            GetComponentInChildren<DashScript>().sOwner = "PLAYER1";
        }
        else
        {
            playerIndex = PlayerIndex.Two;
            GetComponent<GunScript>().sOwner = "PLAYER2";
            GetComponentInChildren<DashScript>().sOwner = "PLAYER2";
        }
    }
}
