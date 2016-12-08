/*******************************  SpaceTube  *********************************
Author: Matty Lanouette
Contributors: Josh 'Avoids Contact' Gutenberg
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   StartLevelLogic.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using XInputDotNetPure;

public class StartLevelLogic : MonoBehaviour
{

    private GamePadState State;
    private GamePadState prevState;
    private bool bController;

    public bool bDisabled;

    public PlayerIndex playerIndex;

	// Update is called once per frame
	void Update ()
    {
        prevState = State;
        State = GamePad.GetState(playerIndex);

        if(!bDisabled)
        {
            if(prevState.Buttons.Start == ButtonState.Released && State.Buttons.Start == ButtonState.Pressed)
            {
                Debug.Log("start was pressed");
                SceneManager.LoadScene("IceCavesLevel");
            }
        }
	
	}
}
