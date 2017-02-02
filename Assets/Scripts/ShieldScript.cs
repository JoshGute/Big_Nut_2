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

- Regen of shield after broken needed
- Degrade shield after holding for too long needed
- Break shield if HP lower than 0 

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
  private float MaxShieldHealth = 25;

  private float curShieldHealth;

  bool ShieldState = false;
  bool ShieldBroken = false;

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

	// Use this for initialization
	void Start ()
  {
    curShieldHealth = MaxShieldHealth;
	}
	
	// Update is called once per frame
	void Update ()
  {
    if(ShieldState == true)
    {
      curShieldHeldTime += Time.deltaTime;

      if(curShieldHeldTime >= ShieldHeldTime)
      {
        DegradeShield();
      }
    }

    //Tracking time that shield stays broken
    if(ShieldBroken == true)
    {
      curShieldBrokenTime += Time.deltaTime;

      if (curShieldBrokenTime >= ShieldBrokenTime)
      {
        ShieldBroken = false;
      }
    }

    //If player is not using shield and the period for punishment when shield is broken has passed...
    if (ShieldState == false && ShieldBroken == false)
    {
      RegenShield();
    }
  }

  //Checks state of shield
  void UpdateShieldState()
  {
    if (ShieldState == true)
    {
      gameObject.GetComponent<SphereCollider>().enabled = true;
      gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    else if (ShieldState == false)
    {
      gameObject.GetComponent<SphereCollider>().enabled = false;
      gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
  }

  /*Separate functions for turning on and off shield for further development.*/
  public void TurnOnShield()
  {
    ShieldState = true;

    //stopping collider first to avoid shield potentially registering player's hitbox.
    //Player.GetComponent<Collider>().enabled = false;

    //turn on shield now that player's collider is out of the picture.
    UpdateShieldState();
  }

  public void TurnOffShield()
  {
    ShieldState = false;

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
      print("Regen" + curShieldHealth);

      curShieldHealth += 1;

      if(curShieldHealth > MaxShieldHealth)
      {
        curShieldHealth = MaxShieldHealth;
      }
    }

  }

  //Called if shield is held for too long, causes shield to take damage. 
  void DegradeShield()
  {
    print("Degrading" + curShieldHealth);

    curShieldHealth -= 1;
  }

  void OnTriggerEnter(Collider trigger)
  {
    if(trigger.tag == "Bullet")
    {
      Destroy(trigger.gameObject);
      TakeDamage(1);
    }
  }

  //Damage the shield
  void TakeDamage(int damage)
  {
    curShieldHealth -= damage;

    if(curShieldHealth <= 0)
    {
      BreakShield();
      curShieldHealth = 0;
    }
  }

  void BreakShield()
  {
    print("B0rked");
    ShieldBroken = true;
  }
}
