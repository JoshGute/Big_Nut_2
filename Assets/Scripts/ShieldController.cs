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
  private tk2dSpriteAnimator ShieldAnimator;

  private Dictionary<string, tk2dSpriteAnimationClip> ShieldAnimClips = new Dictionary<string, tk2dSpriteAnimationClip>();

  //These do not change based on shield health
  private tk2dSpriteAnimationClip TurnOnPt1;

  //These do change based on shield health
  private tk2dSpriteAnimationClip TakeDamagePt1;
  private tk2dSpriteAnimationClip TakeDamagePt2;
  private tk2dSpriteAnimationClip TurnOnPt2;
  private tk2dSpriteAnimationClip StayOn;

  private bool AmTakingDamagePt1 = false;
  private bool AmTakingDamagePt2 = false;
  private bool HaveTurnedOnPt1 = false;
  private bool HaveTurnedOnPt2 = false;
  private bool AmStayingOn = false;

  // Use this for initialization
  void Start ()
  {
    curShieldSize = transform.localScale;
    shield = gameObject.GetComponent<ShieldScript>();

    ShieldAnimator = gameObject.GetComponent<tk2dSpriteAnimator>();
	}

  //Deprecated to Hell
  //Action is what is happening to the shield, State is whether we want pt1 or pt2 of animation, shieldHPstate is the health
  /*
  tk2dSpriteAnimationClip FindAnimClip(string Action, string State, float shieldHPstate)
  {
    //percentage of health
    float shieldhealthpercentage = shieldHPstate / shield.MaxShieldHealth;

    //anim clip passed back
    tk2dSpriteAnimationClip animclip = new tk2dSpriteAnimationClip();

    if(Action == "TakeDamage")
    {
      //Full health
      if (shieldhealthpercentage >= 1 || shieldhealthpercentage > 0.9)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_10");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_10");
      }
      //9
      else if (shieldhealthpercentage <= 0.89 && shieldhealthpercentage > 0.8)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_9");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_9");
      }
      //8
      else if (shieldhealthpercentage <= 0.79 && shieldhealthpercentage > 0.7)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_8");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_8");
      }
      //7
      else if (shieldhealthpercentage <= 0.69 && shieldhealthpercentage > 0.6)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_7");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_7");
      }
      //6
      else if (shieldhealthpercentage <= 0.59 && shieldhealthpercentage > 0.5)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_6");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_6");
      }
      //5
      else if (shieldhealthpercentage <= 0.49 && shieldhealthpercentage > 0.4)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_5");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_5");
      }
      //4
      else if (shieldhealthpercentage <= 0.39 && shieldhealthpercentage > 0.3)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_4");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_4");
      }
      //3
      else if (shieldhealthpercentage <= 0.29 && shieldhealthpercentage > 0.2)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_3");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_3");
      }
      //2
      else if (shieldhealthpercentage <= 0.19 && shieldhealthpercentage > 0.1)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_2");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_2");
      }
      //1
      else if (shieldhealthpercentage <= 0.09 && shieldhealthpercentage > 0.0)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_1");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_1");
      }
      //Shield Break
      else if(shieldhealthpercentage <= 0)
      {
        TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_1");
        TakeDamagePt2 = ShieldAnimator.GetClipByName("ShieldBreak");
      }

      if (State == "Pt1")
      {
        animclip = TakeDamagePt1;
      }
      else if (State == "Pt2")
      {
        animclip = TakeDamagePt2;
      }
    }

    else if(Action == "TurnOn")
    {
      //The turning on pt 1 is the same regardless, so I don't check. 
      TurnOnPt1 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt1");

      //Full health
      if (shieldhealthpercentage >= 1 || shieldhealthpercentage > 0.9)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_10");
      }
      //9
      else if (shieldhealthpercentage <= 0.89 && shieldhealthpercentage > 0.8)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_9");
      }
      //8
      else if (shieldhealthpercentage <= 0.79 && shieldhealthpercentage > 0.7)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_8");
      }
      //7
      else if (shieldhealthpercentage <= 0.69 && shieldhealthpercentage > 0.6)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_7");
      }
      //6
      else if (shieldhealthpercentage <= 0.59 && shieldhealthpercentage > 0.5)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_6");
      }
      //5
      else if (shieldhealthpercentage <= 0.49 && shieldhealthpercentage > 0.4)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_5");
      }
      //4
      else if (shieldhealthpercentage <= 0.39 && shieldhealthpercentage > 0.3)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_4");
      }
      //3
      else if (shieldhealthpercentage <= 0.29 && shieldhealthpercentage > 0.2)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_3");
      }
      //2
      else if (shieldhealthpercentage <= 0.19 && shieldhealthpercentage > 0.1)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_2");
      }
      //1
      else if (shieldhealthpercentage <= 0.09 && shieldhealthpercentage > 0.0)
      {
        TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_1");
      }
      //Shield is broken, cannot turn on until it's above 0.
      else if (shieldhealthpercentage <= 0)
      {
        return null;
      }

      if (State == "Pt1")
      {
        animclip = TurnOnPt1;
      }
      else if (State == "Pt2")
      {
        animclip = TurnOnPt2;
      }
      else
      {
        return null;
      }
    }

    else if(Action == "StayOn")
    {
      //Full health
      if (shieldhealthpercentage >= 1 || shieldhealthpercentage > 0.9)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_10");
      }
      //9
      else if (shieldhealthpercentage <= 0.89 && shieldhealthpercentage > 0.8)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_9");
      }
      //8
      else if (shieldhealthpercentage <= 0.79 && shieldhealthpercentage > 0.7)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_8");
      }
      //7
      else if (shieldhealthpercentage <= 0.69 && shieldhealthpercentage > 0.6)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_7");
      }
      //6
      else if (shieldhealthpercentage <= 0.59 && shieldhealthpercentage > 0.5)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_6");
      }
      //5
      else if (shieldhealthpercentage <= 0.49 && shieldhealthpercentage > 0.4)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_5");
      }
      //4
      else if (shieldhealthpercentage <= 0.39 && shieldhealthpercentage > 0.3)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_4");
      }
      //3
      else if (shieldhealthpercentage <= 0.29 && shieldhealthpercentage > 0.2)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_3");
      }
      //2
      else if (shieldhealthpercentage <= 0.19 && shieldhealthpercentage > 0.1)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_2");
      }
      //1
      else if (shieldhealthpercentage <= 0.09 && shieldhealthpercentage > 0.0)
      {
        StayOn = ShieldAnimator.GetClipByName("Shield_Idle_1");
      }
      //Shield is broken, cannot turn on until it's above 0.
      else if (shieldhealthpercentage <= 0)
      {
        return null;
      }

      if (State == "Pt1")
      {
        animclip = StayOn;
      }
      else if (State == "Pt2")
      {
        animclip = StayOn;
      }
      else
      {
        return null;
      }
    }

    return animclip;
  }
  */

  // Update is called once per frame
  void Update()
  {
  }

  void AnimCompleteDelegate(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip animclip)
  {
  }

  //Effects for taking damage 
  void TakeDamageAnim()
  {
    //ShieldAnimator.Play(TakeDamagePt1);
  }

  //Effects for regenerating shield
  void RegenShieldAnim()
  {
  }


  //prevshieldhealth is for pt1, curShieldHealth is for pt2
  /*
  public void UpdateShieldVisuals(string Action, float prevShieldHealth, float curShieldHealth)
  {
    if(Action == "TakeDamage")
    {
      AmTakingDamagePt1 = true;

      ShieldAnimator.Play(FindAnimClip("TakeDamage", "Pt1", prevShieldHealth));
    }

    else if(Action == "TurnOn")
    {
      HaveTurnedOnPt1 = true;

      ShieldAnimator.Play(FindAnimClip("TurnOn", "Pt1", prevShieldHealth));
      ShieldAnimator.Play(FindAnimClip("TurnOn", "Pt2", curShieldHealth));

      
      //AnimCompleteDelegate(ShieldAnimator, FindAnimClip("TurnOn", "Pt2", curShieldHealth));

      //ShieldAnimator.AnimationCompleted = AnimCompleteDelegate;
    }

    else if(Action == "StayOn")
    {
      ShieldAnimator.Play(FindAnimClip("StayOn", "Pt1", prevShieldHealth));

      //AnimCompleteDelegate(ShieldAnimator, FindAnimClip("StayOn", "Pt2", curShieldHealth));

      //ShieldAnimator.AnimationCompleted = AnimCompleteDelegate;
    }
  }
  */

  //lol nvm
  public void UpdateShieldVisualState(float curShieldHealth)
  {
    float shieldhealthpercentage = curShieldHealth / shield.MaxShieldHealth;

    transform.localScale = new Vector3(shieldhealthpercentage * 16, shieldhealthpercentage * 16, 5);

    //Full Shield
    //Might be unnecessary or at least merge with the 90% and higher...
    if(shieldhealthpercentage >= 1)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_10");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_9");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_10");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_10HP");
      */
    }
    //90% and higher
    else if(shieldhealthpercentage <= 0.99 && shieldhealthpercentage >= 0.9)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_10");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_9");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_10");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_10HP");
      */
    }
    //80% and higher
    else if(shieldhealthpercentage <= 0.89 && shieldhealthpercentage >= 0.8)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_9");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_8");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_9");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_9HP");
      */
    }
    //70% and higher
    else if (shieldhealthpercentage <= 0.79 && shieldhealthpercentage >= 0.7)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_8");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_7");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_8");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_8HP");
      */
    }
    //60% and higher
    else if (shieldhealthpercentage <= 0.69 && shieldhealthpercentage >= 0.6)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_7");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_6");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_7");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_7HP");
      */
    }
    //50% and higher
    else if (shieldhealthpercentage <= 0.59 && shieldhealthpercentage >= 0.5)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_6");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_5");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_6");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_6HP");
      */
    }
    //40% and higher
    else if (shieldhealthpercentage <= 0.49 && shieldhealthpercentage >= 0.4)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_5");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_4");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_5");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_5HP");
      */
    }
    //30% and higher
    else if (shieldhealthpercentage <= 0.39 && shieldhealthpercentage >= 0.3)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_4");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_3");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_4");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_4HP");
      */
    }
    //20% and higher
    else if (shieldhealthpercentage <= 0.29 && shieldhealthpercentage >= 0.2)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_3");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_2");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_3");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_3HP");
      */
    }
    //10% and higher
    else if (shieldhealthpercentage <= 0.19 && shieldhealthpercentage >= 0.1)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_2");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_1");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_2");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_2HP");
      */
    }
    //0% and higher
    else if (shieldhealthpercentage <= 0.09 && shieldhealthpercentage >= 0.01)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_1");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt2_1");

      TurnOnPt2 = ShieldAnimator.GetClipByName("Shield_TurnOn_Pt2_1");
      StayOn = ShieldAnimator.GetClipByName("Shield_Idle_1HP");
      */
    }
    else if (shieldhealthpercentage <= 0)
    {
      /*
      TakeDamagePt1 = ShieldAnimator.GetClipByName("Shield_GetHit_Pt1_1");
      TakeDamagePt2 = ShieldAnimator.GetClipByName("ShieldBreak");

      TurnOnPt2 = null;
      StayOn = null;
      */
    }
  }
}
