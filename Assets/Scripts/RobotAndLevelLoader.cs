/*******************************  SpaceTube  *********************************
Author: Matty Lanouette
Contributors: --
Course: GAM400
Game:   Bolt Blitz
Date:   1/13/2016
File:   RobotSelectLogic.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;

public class RobotAndLevelLoader : MonoBehaviour {

    public GameObject PlayerSelector;
    public GameObject SelectedRobot;

    public int PlayerNumber;
    public Vector3 Position;

    private RectTransform SelectorTransform;

    private float KeyAxisH;
    private float KeyAxisV;

    private GamePadState State;
    private GamePadState PrevState;

    private bool bController;
    public bool bDisabled;

    public string Horizontal = "Horizontal_P1";
    public string Vertical = "Vertical_P1";

    public PlayerIndex playerIndex;

    public float MoveTimer;
    private bool CanMove;

    public GameObject PlayerRobot;

	// Use this for initialization
	void Start ()
    {
        SelectorTransform = GetComponent<RectTransform>();
        CanMove = true;
        MoveTimer = 10;
	}

    // Update is called once per frame
    void Update()
    {
        PrevState = State;
        State = GamePad.GetState(playerIndex);

        if (!bDisabled && CanMove == true)
        {
            KeyAxisH = State.ThumbSticks.Left.X;
            KeyAxisV = State.ThumbSticks.Left.Y;

            if (KeyAxisH != 0)
            {
                CanMove = false;
                if (KeyAxisH > 0 && SelectorTransform.localPosition.x < 75)
                {
                    SelectorTransform.localPosition += new Vector3(125, 0, 0);
                    Debug.Log("MOVE RIGHT");
                }
                if (KeyAxisH < 0 && SelectorTransform.localPosition.x > -50)
                {
                    SelectorTransform.localPosition += new Vector3(-125, 0, 0);
                    Debug.Log("MOVE LEFT");
                }
            }

            if (KeyAxisV != 0)
            {
                CanMove = false;
                if (KeyAxisV > 0 && SelectorTransform.localPosition.y < -170)
                {
                    SelectorTransform.localPosition += new Vector3(0, 115, 0);
                    Debug.Log("MOVE UP");
                }
                if (KeyAxisV < 0 && SelectorTransform.localPosition.y > 170)
                {
                    SelectorTransform.localPosition += new Vector3(0, -115, 0);
                    Debug.Log("MOVE DOWN");
                }
            }
        }

        if (CanMove == false)
        {
            --MoveTimer;
            if (MoveTimer <= 0)
            {
                MoveTimer = 10;
                CanMove = true;
            }
        }

        if (PlayerNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.W) && SelectorTransform.localPosition.y < 170)
            {
                SelectorTransform.localPosition += new Vector3(0, 115, 0);
            }
            if (Input.GetKeyDown(KeyCode.S) && SelectorTransform.localPosition.y > -170)
            {
                SelectorTransform.localPosition += new Vector3(0, -115, 0);
            }
            if (Input.GetKeyDown(KeyCode.D) && SelectorTransform.localPosition.x < 75)
            {
                SelectorTransform.localPosition += new Vector3(125, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.A) && SelectorTransform.localPosition.x > -50)
            {
                SelectorTransform.localPosition += new Vector3(-125, 0, 0);
            }

        }
        if (PlayerNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && SelectorTransform.localPosition.y < 170)
            {
                SelectorTransform.localPosition += new Vector3(0, 115, 0);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && SelectorTransform.localPosition.y > -170)
            {
                SelectorTransform.localPosition += new Vector3(0, -115, 0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && SelectorTransform.localPosition.x < 75)
            {
                SelectorTransform.localPosition += new Vector3(125, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && SelectorTransform.localPosition.x > -50)
            {
                SelectorTransform.localPosition += new Vector3(-125, 0, 0);
            }
        }
    }    
} 
