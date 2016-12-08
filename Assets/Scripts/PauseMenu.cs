/*******************************  SpaceTube  *********************************
Author: 
Contributors:
Course: GAM350
Game:   G_Proto
Date:   4/8/16
File:   PauseMenu

Description:
pauses the game when you tell it to

Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PauseMenu : MonoBehaviour
{

    public bool bPaused = false;

    public Canvas cPauseMenu;

    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }

        if (state.Buttons.Start == ButtonState.Pressed && prevState.Buttons.Start == ButtonState.Released)
        {
            Pause();
        }
    }

    private void Pause()
    {
        if (bPaused == true)
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            bPaused = false;
            AudioSource[] aSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource aSource in aSources)
            {
                aSource.UnPause();
            }
        }
        else if (bPaused == false)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            bPaused = true;
            AudioSource[] aSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource aSource in aSources)
            {
                aSource.Pause();
            }
        }
    }
}
