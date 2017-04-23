/*******************************  Ducks in a Row  *********************************
Author: Linus 'gives no fucks' Chan
Contributors: --
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   AimRingAnimationController.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRingAnimationController : MonoBehaviour {

  //The animator
  [SerializeField]
  private tk2dSpriteAnimator SpriteAnimator;

  [SerializeField]
  private GameObject Bolt;

  // Use this for initialization
  void Start ()
  {
    SpriteAnimator.AnimationEventTriggered = OnAnimComplete;
  }

  void OnAnimComplete(tk2dSpriteAnimator Animator, tk2dSpriteAnimationClip clip, int frameNo)
  {
    //CheckHealth();
  }

  public void PlayHealthDamageAnim(int curBoltHealth)
  {
    if (curBoltHealth == 3)
    {
      SpriteAnimator.Play("AimRing_3to2");
    }
    else if (curBoltHealth == 2)
    {
      SpriteAnimator.Play("AimRing_2to1");
    }
    else if (curBoltHealth == 1)
    {
      SpriteAnimator.Play("AimRing_1to0");
    }
  }

  void UpdateState(int health)
  {
    if(health == 2)
    {
      SpriteAnimator.Play("AimRing_2");
    }
    else if(health == 1)
    {
      SpriteAnimator.Play("AimRing_1");
    }
    else if (health == 0)
    {
      SpriteAnimator.Play("AimRing_0");
    }
  }

  // Update is called once per frame
  void Update ()
  {
		
	}
}
