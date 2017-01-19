/*******************************  Ducks in a Row  *********************************
Author: Linus 'Fills in the Blanks' Chan
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   1/18/2017
File:   ImprovedDashScript.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVer2 : MonoBehaviour {

  int DashDistance = 1;

  private Rigidbody Rb;
  private Transform Tr;

  [SerializeField]
  private float TurnSpeed = 5f;
  [SerializeField]
  private float maxSpeed = 25f;
  [SerializeField]
  private float Speed = 100f;

	// Use this for initialization
	void Start ()
  {
    Rb = gameObject.GetComponent<Rigidbody>();
    Tr = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
  {
    Vector3 ShipDirection = new Vector3(0f, 1f, 0f);

    if(Input.GetKey(KeyCode.LeftArrow))
    {
      Tr.Rotate(new Vector3(0f, 0f, 1f), TurnSpeed);
    }

    if(Input.GetKey(KeyCode.RightArrow))
    {
      Tr.Rotate(new Vector3(0f, 0f, 1f), -TurnSpeed);
    }

    if(Input.GetKeyDown(KeyCode.X))
    {
      Dash();

      print(gameObject.transform.position);
    }

    if (Input.GetKey(KeyCode.UpArrow))
    {
      Rb.AddRelativeForce(ShipDirection * Speed);
    }

    if (Rb.velocity.magnitude > maxSpeed)
    {
      Rb.velocity = Rb.velocity.normalized * maxSpeed;
    }
  }

  void Dash ()
  {
  }
}
