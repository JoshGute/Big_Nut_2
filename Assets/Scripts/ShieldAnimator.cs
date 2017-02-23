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

    //transform.localScale = new Vector3(shieldhealthpercentage * 10, shieldhealthpercentage * 10, 5);

    //Full Shield
    if(shieldhealthpercentage >= 1)
    {

    }
    //90% and higher
    else if(shieldhealthpercentage <= 0.99 && shieldhealthpercentage >= 0.9)
    {

    }
    //80% and higher
    else if(shieldhealthpercentage <= 0.89 && shieldhealthpercentage >= 0.8)
    {

    }
    //70% and higher
    else if (shieldhealthpercentage <= 0.79 && shieldhealthpercentage >= 0.7)
    {

    }
    //60% and higher
    else if (shieldhealthpercentage <= 0.69 && shieldhealthpercentage >= 0.6)
    {

    }
    //50% and higher
    else if (shieldhealthpercentage <= 0.59 && shieldhealthpercentage >= 0.5)
    {

    }
    //40% and higher
    else if (shieldhealthpercentage <= 0.49 && shieldhealthpercentage >= 0.4)
    {

    }
    //30% and higher
    else if (shieldhealthpercentage <= 0.39 && shieldhealthpercentage >= 0.3)
    {

    }
    //20% and higher
    else if (shieldhealthpercentage <= 0.29 && shieldhealthpercentage >= 0.2)
    {

    }
    //10% and higher
    else if (shieldhealthpercentage <= 0.19 && shieldhealthpercentage >= 0.1)
    {

    }
    //0% and higher
    else if (shieldhealthpercentage <= 0.09 && shieldhealthpercentage >= 0.01)
    {

    }
  }

	// Update is called once per frame
	void Update ()
  {
	}
}
