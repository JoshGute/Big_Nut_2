/*******************************  Ducks in a Row  ******************************
Author: Josh 'God I hate video games' Gutenberg
Contributors:
Course: GAM350
Game:   Bolt Blitz
Date:   12/8/16
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
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool bPaused = false;

    public GameObject gPauseMenu;

    public Button startingButton;
    public EventSystem eEventSystem;

    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public PlayerIndex playerIndex2;
    GamePadState state2;
    GamePadState prevState2;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        prevState2 = state2;
        state2 = GamePad.GetState(playerIndex2);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }

        if (state.Buttons.Start == ButtonState.Pressed && prevState.Buttons.Start == ButtonState.Released || 
            state2.Buttons.Start == ButtonState.Pressed && prevState2.Buttons.Start == ButtonState.Released)
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

            PlayerControllerVer2[] pControllers = FindObjectsOfType<PlayerControllerVer2>();
            foreach (PlayerControllerVer2 pController in pControllers)
            {
                pController.bDisabled = false;
            }

            //GameObject[] gActiveCanvases = gameObject.GetComponentsInChildren<GameObject>();
            foreach (Transform tChild in transform)
            {
                if (tChild.gameObject.activeSelf)
                {
                    tChild.gameObject.SetActive(false);
                }
            }
            
            gPauseMenu.SetActive(false);
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

            PlayerControllerVer2[] pControllers = FindObjectsOfType<PlayerControllerVer2>();
            foreach (PlayerControllerVer2 pController in pControllers)
            {
                pController.bDisabled = true;
            }
            startingButton.Select();
            gPauseMenu.SetActive(true);
        }

    }

    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        bPaused = false;
        AudioSource[] aSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource aSource in aSources)
        {
            aSource.UnPause();
        }

        PlayerControllerVer2[] pControllers = FindObjectsOfType<PlayerControllerVer2>();
        foreach (PlayerControllerVer2 pController in pControllers)
        {
            pController.bDisabled = false;
        }
        gPauseMenu.SetActive(false);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        gPauseMenu.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();
    }


    public void ChangeButton(GameObject gTarget_)
    {
        eEventSystem.SetSelectedGameObject(gTarget_);
    }

}