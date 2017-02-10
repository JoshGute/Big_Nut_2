﻿/*******************************  Bolt Blitz  *********************************
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
//Called 'custom' animation state because unity already has an animation state class. 
public class CustomSpriteAnimationStates
{
  public enum AnimState { IdleUpRight, IdleReverse, RolltoUpRight, RolltoReverse };
}

public class AnimationControllerVer2 : MonoBehaviour {

  [SerializeField]
  private tk2dSpriteAnimator RobotAnimator;

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

  public void ChangeAnimation(int iInput_)
  {
    switch (iInput_)
    {
      case 1:
        {
          UpdateAnimState(CustomSpriteAnimationStates.AnimState.RolltoReverse);
          break;
        }
      case 2:
        {
          UpdateAnimState(CustomSpriteAnimationStates.AnimState.RolltoUpRight);
          break;
        }
      case 3:
        {
          UpdateAnimState(CustomSpriteAnimationStates.AnimState.IdleReverse);
          break;
        }
      case 4:
        {
          UpdateAnimState(CustomSpriteAnimationStates.AnimState.IdleUpRight);
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

  void UpdateAnimState(CustomSpriteAnimationStates.AnimState newAnimState)
  {
    switch (newAnimState)
    {
      case CustomSpriteAnimationStates.AnimState.RolltoReverse:
          RobotAnimator.Play("Rotate_toReverse");
          RobotAnimator.AnimationCompleted = PreviousSpriteAnimDelegate;
        break;

      case CustomSpriteAnimationStates.AnimState.RolltoUpRight:
          RobotAnimator.Play("Rotate_toUpRight");
          RobotAnimator.AnimationCompleted = PreviousSpriteAnimDelegate;
        break;

      case CustomSpriteAnimationStates.AnimState.IdleUpRight:
        RobotAnimator.Play("Idle_UpRight");
        RobotAnimator.AnimationCompleted = PreviousSpriteAnimDelegate;
        break;

      case CustomSpriteAnimationStates.AnimState.IdleReverse:
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