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

- Need to hook up to player controller
- Need to test bullet collision

Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

  int ShieldHealth = 3;
  bool ShieldState = false;

  [SerializeField]
  private GameObject Player;

	// Use this for initialization
	void Start ()
  {
		
	}
	
	// Update is called once per frame
	void Update ()
  {
    if(Input.GetKeyDown(KeyCode.D))
    {
      TurnOnShield();
    }

    if(Input.GetKeyDown(KeyCode.A))
    {
      TurnOffShield();
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
  void TurnOnShield()
  {
    ShieldState = true;

    //stopping collider first to avoid shield potentially registering player's hitbox.
    Player.GetComponent<Collider>().enabled = false;

    //turn on shield now that player's collider is out of the picture.
    UpdateShieldState();
  }

  void TurnOffShield()
  {
    ShieldState = false;

    //turn off shield first
    UpdateShieldState();

    //turn on player collider
    Player.GetComponent<Collider>().enabled = true;
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
    ShieldHealth -= damage;
  }
}
