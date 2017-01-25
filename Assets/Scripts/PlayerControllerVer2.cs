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

  private Rigidbody Rb;
  private Transform Tr;

  //Dashing
  [SerializeField]
  private Transform dashTargetPos;
  [SerializeField]
  private int maxDashes = 1;
  [SerializeField]
  private int curDashes = 0;
  [SerializeField]
  private float DashDistance = 5f;
  [SerializeField]
  private float secDashRegenTime = 1f;

  private bool RegenDash = false;

  //Turning
  [SerializeField]
  private float TurnSpeed = 5f;

  //Moving
  [SerializeField]
  private float maxSpeed = 25f;
  [SerializeField]
  private float Speed = 100f;

  private float regentime = 0f;

	// Use this for initialization
	void Start ()
  {
    curDashes = maxDashes;

    Rb = gameObject.GetComponent<Rigidbody>();
    Tr = gameObject.GetComponent<Transform>();
	}
	
  void Update ()
  {
    if(RegenDash == true)
    {
      regentime += Time.deltaTime;

      if (regentime >= secDashRegenTime)
      {
        curDashes += 1;
        //turn off regen
        RegenDash = false;
        //reset to 0
        regentime = 0f;
      }
    }
  }

	// Update is called once per frame
	void FixedUpdate ()
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
      if(curDashes > 0)
      {
        curDashes -= 1;

        Dash();

        if (curDashes == 0)
        {
          RegenDash = true;
        }
      }

      else
      {
        return;
      }

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

  /* Dash Function
   * Change the 'y' pos of the dash target if you want to change the pos. 
  */
  void Dash ()
  {
    Tr.position = dashTargetPos.position;

    //Imperfect, but ultimately not needed because I realized I could just parent a target object the desired
    // dashdistance away and use that as the target pos to dash to.
    /*
    Vector3 DashPos = new Vector3(Mathf.Pow(((Tr.position.x + DashDistance) - Tr.position.x),2), Mathf.Pow(((Tr.position.y + DashDistance) - Tr.position.y),2), 
      Tr.position.z);

    Tr.position = DashPos;
    */
  }
}
