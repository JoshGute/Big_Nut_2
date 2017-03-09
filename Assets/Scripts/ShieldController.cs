/******************************* Ducks in a Row *********************************
Author: Linus 'what am i even doing' Chan
Contributors: --
Course: GAM450
Game:   Bolt Blitz
Date:   02/17/2017
File:   ShieldController.cs

Description:

This shield animator script updates the look of the shield. 

Current Problems:

Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

  private ShieldScript shield;

  private Vector3 curShieldSize;

  //Main robot body animations
  [SerializeField]
  private tk2dSpriteAnimator ShieldAnimator;

  //These do not change based on shield health
  private tk2dSpriteAnimationClip TurnOnPt1;

  private Dictionary<string, tk2dSpriteAnimationClip> ShieldAnimClips = new Dictionary<string, tk2dSpriteAnimationClip>();

  //These do change based on shield health
  /*
  private tk2dSpriteAnimationClip TakeDamagePt1;
  private tk2dSpriteAnimationClip TakeDamagePt2;
  private tk2dSpriteAnimationClip TurnOnPt2;
  private tk2dSpriteAnimationClip StayOn; 
  */

  // Use this for initialization
  void Start ()
  {
    //Get Hit Animations Part 1
    tk2dSpriteAnimationClip gethit_pt1_10hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_10");
    tk2dSpriteAnimationClip gethit_pt1_9hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_9");
    tk2dSpriteAnimationClip gethit_pt1_8hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_8");
    tk2dSpriteAnimationClip gethit_pt1_7hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_7");
    tk2dSpriteAnimationClip gethit_pt1_6hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_6");
    tk2dSpriteAnimationClip gethit_pt1_5hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_5");
    tk2dSpriteAnimationClip gethit_pt1_4hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_4");
    tk2dSpriteAnimationClip gethit_pt1_3hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_3");
    tk2dSpriteAnimationClip gethit_pt1_2hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_2");
    tk2dSpriteAnimationClip gethit_pt1_1hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_1");

    //Adding to dictionary
    ShieldAnimClips.Add("GetHit_Pt1_10HP", gethit_pt1_10hp);
    ShieldAnimClips.Add("GetHit_Pt1_9HP", gethit_pt1_9hp);
    ShieldAnimClips.Add("GetHit_Pt1_8HP", gethit_pt1_8hp);
    ShieldAnimClips.Add("GetHit_Pt1_7HP", gethit_pt1_7hp);
    ShieldAnimClips.Add("GetHit_Pt1_6HP", gethit_pt1_6hp);
    ShieldAnimClips.Add("GetHit_Pt1_5HP", gethit_pt1_5hp);
    ShieldAnimClips.Add("GetHit_Pt1_4HP", gethit_pt1_4hp);
    ShieldAnimClips.Add("GetHit_Pt1_3HP", gethit_pt1_3hp);
    ShieldAnimClips.Add("GetHit_Pt1_2HP", gethit_pt1_2hp);
    ShieldAnimClips.Add("GetHit_Pt1_1HP", gethit_pt1_1hp);

    //Get Hit Animations Part 2
    tk2dSpriteAnimationClip gethit_pt2_10hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_10");
    tk2dSpriteAnimationClip gethit_pt2_9hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_9");
    tk2dSpriteAnimationClip gethit_pt2_8hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_8");
    tk2dSpriteAnimationClip gethit_pt2_7hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_7");
    tk2dSpriteAnimationClip gethit_pt2_6hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_6");
    tk2dSpriteAnimationClip gethit_pt2_5hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_5");
    tk2dSpriteAnimationClip gethit_pt2_4hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_4");
    tk2dSpriteAnimationClip gethit_pt2_3hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_3");
    tk2dSpriteAnimationClip gethit_pt2_2hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_2");
    tk2dSpriteAnimationClip gethit_pt2_1hp = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_1");

    //Adding to dictionary
    ShieldAnimClips.Add("GetHit_Pt2_10HP", gethit_pt2_10hp);
    ShieldAnimClips.Add("GetHit_Pt2_9HP", gethit_pt2_9hp);
    ShieldAnimClips.Add("GetHit_Pt2_8HP", gethit_pt2_8hp);
    ShieldAnimClips.Add("GetHit_Pt2_7HP", gethit_pt2_7hp);
    ShieldAnimClips.Add("GetHit_Pt2_6HP", gethit_pt2_6hp);
    ShieldAnimClips.Add("GetHit_Pt2_5HP", gethit_pt2_5hp);
    ShieldAnimClips.Add("GetHit_Pt2_4HP", gethit_pt2_4hp);
    ShieldAnimClips.Add("GetHit_Pt2_3HP", gethit_pt2_3hp);
    ShieldAnimClips.Add("GetHit_Pt2_2HP", gethit_pt2_2hp);
    ShieldAnimClips.Add("GetHit_Pt2_1HP", gethit_pt2_1hp);

    //Turn On Animations Part 1
    tk2dSpriteAnimationClip turnon_pt1 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt1");

    //Adding to dictionary
    ShieldAnimClips.Add("TurnOn_Pt1", turnon_pt1);

    //Turn On Animations Part 2
    tk2dSpriteAnimationClip turnon_pt2_10hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_10");
    tk2dSpriteAnimationClip turnon_pt2_9hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_9");
    tk2dSpriteAnimationClip turnon_pt2_8hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_8");
    tk2dSpriteAnimationClip turnon_pt2_7hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_7");
    tk2dSpriteAnimationClip turnon_pt2_6hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_6");
    tk2dSpriteAnimationClip turnon_pt2_5hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_5");
    tk2dSpriteAnimationClip turnon_pt2_4hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_4");
    tk2dSpriteAnimationClip turnon_pt2_3hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_3");
    tk2dSpriteAnimationClip turnon_pt2_2hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_2");
    tk2dSpriteAnimationClip turnon_pt2_1hp = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_1");

    curShieldSize = transform.localScale;
    shield = gameObject.GetComponent<ShieldScript>();
	}
	
  void AnimCompleteDelegate(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animclip)
  {
  }

  //Effects for taking damage 
  void TakeDamageAnim()
  {
    //ShieldAnimator.Play(TakeDamagePt1);

    ShieldAnimator.AnimationCompleted = AnimCompleteDelegate;
  }

  //Effects for regenerating shield
  void RegenShieldAnim()
  {

  }

  public void UpdateShieldVisuals(string Action, float prevShieldHealth, float curShieldHealth)
  {

  }

  //Deprecated
  /*
  public void UpdateShieldVisualState(float curShieldHealth)
  {
    float shieldhealthpercentage = curShieldHealth / shield.MaxShieldHealth;

    //transform.localScale = new Vector3(shieldhealthpercentage * 10, shieldhealthpercentage * 10, 5);

    //Full Shield
    //Might be unnecessary or at least merge with the 90% and higher...
    if(shieldhealthpercentage >= 1)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_10");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_9");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_10");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_10HP");
    }
    //90% and higher
    else if(shieldhealthpercentage <= 0.99 && shieldhealthpercentage >= 0.9)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_10");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_9");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_10");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_10HP");
    }
    //80% and higher
    else if(shieldhealthpercentage <= 0.89 && shieldhealthpercentage >= 0.8)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_9");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_8");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_9");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_9HP");
    }
    //70% and higher
    else if (shieldhealthpercentage <= 0.79 && shieldhealthpercentage >= 0.7)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_8");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_7");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_8");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_8HP");
    }
    //60% and higher
    else if (shieldhealthpercentage <= 0.69 && shieldhealthpercentage >= 0.6)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_7");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_6");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_7");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_7HP");
    }
    //50% and higher
    else if (shieldhealthpercentage <= 0.59 && shieldhealthpercentage >= 0.5)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_6");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_5");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_6");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_6HP");
    }
    //40% and higher
    else if (shieldhealthpercentage <= 0.49 && shieldhealthpercentage >= 0.4)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_5");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_4");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_5");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_5HP");
    }
    //30% and higher
    else if (shieldhealthpercentage <= 0.39 && shieldhealthpercentage >= 0.3)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_4");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_3");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_4");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_4HP");
    }
    //20% and higher
    else if (shieldhealthpercentage <= 0.29 && shieldhealthpercentage >= 0.2)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_3");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_2");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_3");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_3HP");
    }
    //10% and higher
    else if (shieldhealthpercentage <= 0.19 && shieldhealthpercentage >= 0.1)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_2");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_1");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_2");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_2HP");
    }
    //0% and higher
    else if (shieldhealthpercentage <= 0.09 && shieldhealthpercentage >= 0.01)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_1");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_1");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_1");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_1HP");
    }
    else if (shieldhealthpercentage <= 0)
    {
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_1");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("ShieldBreak");

      TurnOnPt2 = null;
      StayOn = null;
    }
  }
  */

	// Update is called once per frame
	void Update ()
  {
	}
}
