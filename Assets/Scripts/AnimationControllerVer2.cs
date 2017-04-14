/*******************************  Bolt Blitz  *********************************
Author: Linus 'ayyyyylmao' Chan
Contributors: --
Course: GAM400
Game:   Bolt Blitz
Date:   1/28/2017
File:   AnimationControllerVer2.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*State Machine Enums*//
//Body animation states
public class BodySpriteAnimationStates
{
  public enum AnimState { IdleUpRight, IdleReverse, RolltoUpRight, RolltoReverse };
}

//Thruster animation states
public class ThrusterSpriteAnimationStates
{
  public enum AnimState { Inactive, Boost, StopBoost };
}

public class AnimationControllerVer2 : MonoBehaviour {

  //Main robot body animations
  [SerializeField]
  private tk2dSpriteAnimator RobotAnimator;

  //Main thruster animations
  [SerializeField]
  private tk2dSpriteAnimator ThrusterAnimator;

  [SerializeField]
  private GameObject ShockwaveObject;

  [SerializeField]
  private GameObject DashObject;

  [SerializeField]
  private GameObject ShootObject;

  // Use this for initialization
  void Start ()
  {

	}
	
	// Update is called once per frame
	void Update ()
  {
		
	}

  void PreviousAnimDelegate(tk2dSpriteAnimator sprite, tk2dSpriteAnimationClip clip)
  {

  }

  public void PlayShootAnimation()
  {
    ShootObject.GetComponent<PlayAnimOnce>().PlayAnim();
  }

  public void PlayShockwaveAnimation()
  {
    ShockwaveObject.GetComponent<PlayAnimOnce>().PlayAnim();
  }

  public void PlayDashAnimation(Vector3 DashPos)
  {
    DashObject.transform.LookAt(DashObject.transform.position + DashPos, Vector3.forward);
    DashObject.GetComponentInChildren<PlayAnimOnce>().PlayAnim();
  }

  public void ChangeThrusterAnimation(int iInput_)
  {
    switch (iInput_)
    {
      case 1:
        {
          UpdateThrusterAnimState(ThrusterSpriteAnimationStates.AnimState.Boost);
          break;
        }
      case 2:
        {
          UpdateThrusterAnimState(ThrusterSpriteAnimationStates.AnimState.StopBoost);
          break;
        }
    }
  }

  public void ChangeBodyAnimation(int iInput_)
  {
    switch (iInput_)
    {
      case 1:
        {
          UpdateBodyAnimState(BodySpriteAnimationStates.AnimState.RolltoReverse);
          break;
        }
      case 2:
        {
          UpdateBodyAnimState(BodySpriteAnimationStates.AnimState.RolltoUpRight);
          break;
        }
      case 3:
        {
          UpdateBodyAnimState(BodySpriteAnimationStates.AnimState.IdleReverse);
          break;
        }
      case 4:
        {
          UpdateBodyAnimState(BodySpriteAnimationStates.AnimState.IdleUpRight);
          break;
        }
    }
  }

  void PreviousSpriteAnimDelegate(tk2dSpriteAnimator sprite, tk2dSpriteAnimationClip clip)
  {
    /*
    if (isMoving)
    {
      GunAnimator.Play("Gun_Move");
    }
    else
    {
      GunAnimator.Play("Gun_Idle");
    }
    */
  }

  void UpdateThrusterAnimState(ThrusterSpriteAnimationStates.AnimState newAnimState)
  {
    switch(newAnimState)
    {
      //Boost
      case ThrusterSpriteAnimationStates.AnimState.Boost:
      ThrusterAnimator.Play("Thruster_Boost");
      break;

      //StopBoost
      case ThrusterSpriteAnimationStates.AnimState.StopBoost:
      ThrusterAnimator.Play("Thruster_StopBoost");
      break;

      default:
      break;
    }
  }

  void UpdateBodyAnimState(BodySpriteAnimationStates.AnimState newAnimState)
  {
    switch (newAnimState)
    {
      case BodySpriteAnimationStates.AnimState.RolltoReverse:
          RobotAnimator.Play("Rotate_toReverse");
          RobotAnimator.AnimationCompleted = PreviousSpriteAnimDelegate;
        break;

      case BodySpriteAnimationStates.AnimState.RolltoUpRight:
          RobotAnimator.Play("Rotate_toUpRight");
          RobotAnimator.AnimationCompleted = PreviousSpriteAnimDelegate;
        break;

      case BodySpriteAnimationStates.AnimState.IdleUpRight:
        RobotAnimator.Play("Idle_UpRight");
        RobotAnimator.AnimationCompleted = PreviousSpriteAnimDelegate;
        break;

      case BodySpriteAnimationStates.AnimState.IdleReverse:
        RobotAnimator.Play("Idle_Reverse");
        RobotAnimator.AnimationCompleted = PreviousSpriteAnimDelegate;
        break;

      /*
      case CustomAnimationStates.AnimState.Shoot:
        GunAnimator.Play("Gun_Shoot");

        GunAnimator.AnimationCompleted = PreviousAnimDelegate;

        break;
      */

      default:
        break;
    }
  }
}
