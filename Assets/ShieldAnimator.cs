/******************************* Ducks in a Row *********************************
Author: Linus 'what am i even doing' Chan
Contributors: --
Course: GAM450
Game:   Bolt Blitz
Date:   02/17/2017
File:   ShieldAnimator.cs

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

public class ShieldAnimator : MonoBehaviour {

  private ShieldScript shield;

  private Vector3 curShieldSize;

	// Use this for initialization
	void Start ()
  {
    curShieldSize = transform.localScale;
    shield = gameObject.GetComponent<ShieldScript>();
	}
	
  //Effects for taking damage 
  void TakeDamageAnim()
  {
  }

  //Effects for degrading shield
  void DegradeShieldAnim()
  {

  }

  //Effects for regenerating shield
  void RegenShieldAnim()
  {

  }

  public void UpdateShieldVisualState(float curShieldHealth)
  {
    float shieldhealthpercentage = curShieldHealth / shield.MaxShieldHealth;

    transform.localScale = new Vector3(shieldhealthpercentage * 10, shieldhealthpercentage * 10, 5);

    /*may or may not be used
    if(shieldhealthpercentage >= 0.66)
    {

    }

    else if(shieldhealthpercentage >= 0.33 && shieldhealthpercentage < 0.66)
    {

    }

    else if(shieldhealthpercentage >= 0 && shieldhealthpercentage < 0.33)
    {

    }
    */
  }

	// Update is called once per frame
	void Update ()
  {
	}
}
