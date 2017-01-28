/******************************* Ducks in a Row *********************************
Author: Matty Lanouette
Contributors: --
Course: GAM400
Game:   Bolt Blitz
Date:   1/25/2017
File:   RobotMenu.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class RobotMenu : MonoBehaviour
{
    private float KeyAxisH;
    private float KeyAxisV;

    private GamePadState state;
    private GamePadState prevState;

    public GameObject PlayerSelector;
    public GameObject SelectedRobot;

    public int PlayerNumber;
    public Vector3 Position;

    public float MoveTimer;
    private bool Timer;
    private bool CanMove;

    public GameObject[] RobotArray = new GameObject[3];

    public PlayerIndex playerIndex;
    public bool bController;
    public bool bDisabled;

    public int BotSlot;

    private RectTransform SelectorTransform;

	// Use this for initialization
	void Start ()
    {
        CanMove = true;
        MoveTimer = 10;
        SelectorTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        if(!bDisabled && CanMove == true)
        {
            KeyAxisH = state.ThumbSticks.Left.X;
            KeyAxisV = state.ThumbSticks.Left.Y;
        }

        if(CanMove == false)
        {
            --MoveTimer;
            if(MoveTimer <= 0)
            {
                MoveTimer = 10;
                CanMove = true;
            }
        }
	}
}
