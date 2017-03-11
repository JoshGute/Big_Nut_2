/******************************* Ducks in a Row *********************************
Author: Linus 'does things sometimes' Chan
Contributors: --
Course: GAM450
Game:   Bolt Blitz
Date:   01/18/2017
File:   ShieldScript.cs

Description:

This shield script will allows players to create a shield around themselves.

Current Problems:

Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

  //Health of shield
  [SerializeField]
  public float MaxShieldHealth = 25;

  [SerializeField]
  private float RegenValue = 1;

  [SerializeField]
  private float ShieldRegenPerXSec = 1;
  float shieldregentimer;

  [SerializeField]
  private float DegradeValue = 1;

  [SerializeField]
  private float ShieldDegradePerXSec = 1;
  float shielddegradetimer;

  private float prevShieldHealth;
  private float curShieldHealth;

  bool ShieldState = false;
  bool ShieldBroken = false;

  bool ShieldDegrading = false;

  bool ShieldHeld = false;

  //How long shield stays broken for before recharging
  [SerializeField]
  private float ShieldBrokenTime = 5;

  private float curShieldBrokenTime = 0;

  //How long you can hold shield before it starts to take damage on its own
  [SerializeField]
  private float ShieldHeldTime = 2.5f;

  private float curShieldHeldTime = 0;

  [SerializeField]
  private GameObject Player;

  private ShieldController shieldController;

	// Use this for initialization
	void Start ()
  {
    shieldController = gameObject.GetComponent<ShieldController>();
    shielddegradetimer = 0;
    shieldregentimer = 0;
    curShieldHealth = MaxShieldHealth;
    prevShieldHealth = curShieldHealth;
  }
	
	// Update is called once per frame
	void Update ()
  {
    if(ShieldState == true)
    {
      curShieldHeldTime += Time.deltaTime;

      if(curShieldHeldTime >= ShieldHeldTime)
      {
        ShieldDegrading = true;
      }
    }

    //Handling shield degrading
    if(ShieldDegrading == true)
    {
      shielddegradetimer += Time.deltaTime;

      if(shielddegradetimer >= ShieldDegradePerXSec)
      {
        shielddegradetimer = 0;
        DegradeShield();
      }
    }

    //Tracking time that shield stays broken
    if(ShieldBroken == true)
    {
      curShieldBrokenTime += Time.deltaTime;

      if (curShieldBrokenTime >= ShieldBrokenTime)
      {
        curShieldBrokenTime = 0;
        ShieldBroken = false;
      }
    }

    //If player is not using shield and the period for punishment when shield is broken has passed...
    if (ShieldState == false)
    {
      curShieldHeldTime = 0;
      ShieldDegrading = false;

      if (ShieldBroken == false)
      {
        RegenShield();
      }
    }
  }

  //Checks state of shield
  void UpdateShieldState()
  {
    if (ShieldState == true)
    {
      //print(curShieldHealth);

      gameObject.GetComponent<SphereCollider>().enabled = true;
      gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    else if (ShieldState == false)
    {
      //print(curShieldHealth);

      gameObject.GetComponent<SphereCollider>().enabled = false;
      gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
  }

  /*Separate functions for turning on and off shield for further development.*/
  public void TurnOnShield()
  {
    if(ShieldBroken == false)
    {
      ShieldState = true;

      //stopping collider first to avoid shield potentially registering player's hitbox.
      //Player.GetComponent<Collider>().enabled = false;

      //turn on shield now that player's collider is out of the picture.
      UpdateShieldState();

      //Shield graphics code
      if (ShieldHeld == false)
      {
        shieldController.UpdateShieldVisuals("TurnOn", prevShieldHealth, curShieldHealth);
        ShieldHeld = true;
      }
    }
  }

  public void TurnOffShield()
  {
    ShieldState = false;

    ShieldHeld = false;

    //turn off shield first
    UpdateShieldState();

    //turn on player collider
    //Player.GetComponent<Collider>().enabled = true;
  }

  //Called when shield is not on. Slowly regens shield. 
  void RegenShield()
  {
    if(curShieldHealth < MaxShieldHealth)
    {
      shieldregentimer += Time.deltaTime;

      //Reset timer to 0 and add health
      if(shieldregentimer >= ShieldRegenPerXSec)
      {
        shieldController.UpdateShieldVisuals("StayOn", prevShieldHealth, curShieldHealth);

        shieldregentimer = 0;
        curShieldHealth += 1;
      }

      if(curShieldHealth > MaxShieldHealth)
      {
        curShieldHealth = MaxShieldHealth;
      }
    }
  }

  //Called if shield is held for too long, causes shield to take damage. 
  void DegradeShield()
  {
    TakeDamage(1);
  }

  void OnTriggerEnter(Collider trigger)
  {
    if(trigger.tag == "Bullet")
    {
      Destroy(trigger.gameObject);
      TakeDamage(1);
    }
        if (trigger.tag == "Dash")
        {
            BreakShield();
        }
  }

  //Damage the shield
  void TakeDamage(int damage)
  {
    //Updating info for animation purposes.
    prevShieldHealth = curShieldHealth;

    curShieldHealth -= damage;

    shieldController.UpdateShieldVisuals("TakeDamage",prevShieldHealth, curShieldHealth);

    if (curShieldHealth <= 0)
    {
      BreakShield();
      curShieldHealth = 0;
    }
  }

  void BreakShield()
  {
    ShieldBroken = true;
        TurnOffShield();
  }
}
