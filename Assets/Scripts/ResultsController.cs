/*******************************  Ducks in a Row  *********************************
Author: Matty Lanouette
Contributors: Josh Gutenberg
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   QuitLogic.cs

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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsController : MonoBehaviour
{
    private GamePadState State;
    private GamePadState PrevState;
    private bool bController;
    public PlayerIndex playerIndex;

    public PlayerIndex playerIndex2;
    GamePadState state2;
    GamePadState prevState2;

    public Scene MainLevel;
    public Scene RobotSelect;

    public GameObject WinningBot;
    public GameObject LosingBot;

    public PlayerHolder SelectedRobots;
    public GameResults GameResults;

    public Sprite[] Bots;

    public Text WinnerText;

	// Use this for initialization
	void Start ()
    {
        //Debug.Log("im actually running");
        SelectedRobots = FindObjectOfType<PlayerHolder>();
        GameResults = FindObjectOfType<GameResults>();

        if (GameResults.Results == 1)
        {
            WinnerText.GetComponent<Text>().text = "1";
            SetBots(SelectedRobots.Player1Robot, SelectedRobots.Player2Robot);
        }
        else
        {
            WinnerText.GetComponent<Text>().text = "2";
            SetBots(SelectedRobots.Player2Robot, SelectedRobots.Player1Robot);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        PrevState = State;
        State = GamePad.GetState(playerIndex);

        prevState2 = state2;
        state2 = GamePad.GetState(playerIndex2);

        //Debug.Log(State.Buttons.Start);
        if(State.Buttons.Start == ButtonState.Pressed && PrevState.Buttons.Start == ButtonState.Released ||
           state2.Buttons.Start == ButtonState.Pressed && prevState2.Buttons.Start == ButtonState.Released)
        {
            Destroy(FindObjectOfType<PlayerHolder>().gameObject);
            SceneManager.LoadScene(1);
            //Debug.Log("Start was pressed");
        }
        if (State.Buttons.A == ButtonState.Pressed && PrevState.Buttons.A == ButtonState.Released ||
            state2.Buttons.A == ButtonState.Pressed && prevState2.Buttons.A == ButtonState.Released)
        {
            SceneManager.LoadScene(2);
            //Debug.Log("A was pressed");
        }
        if (State.Buttons.B == ButtonState.Pressed && PrevState.Buttons.B == ButtonState.Released ||
            state2.Buttons.B == ButtonState.Pressed && prevState2.Buttons.B == ButtonState.Released)
        {
            Application.Quit();
        }
    }

    public void SetBots(int WinnerBot, int LoserBot)
    {
        WinningBot.GetComponent<Image>().sprite = Bots[WinnerBot];
        LosingBot.GetComponent<Image>().sprite = Bots[LoserBot];
    }
}
