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

    public Scene MainLevel;
    public Scene RobotSelect;

    public GameObject WinningBot;
    public GameObject LosingBot;

    public GameObject SelectedRobots;
    public GameObject GameResults;

    public Sprite DVaBot;
    public Sprite S76Bot;
    public Sprite FlackBot;

    public Text WinnerText;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("im actually running");
        SelectedRobots = GameObject.Find("RobotHolder");
        GameResults = GameObject.Find("Results");
	}
	
	// Update is called once per frame
	void Update ()
    {
        PrevState = State;
        State = GamePad.GetState(playerIndex);
        Debug.Log(State.Buttons.Start);
        if(State.Buttons.Start == ButtonState.Pressed && PrevState.Buttons.Start == ButtonState.Released)
        {
            SceneManager.LoadScene(0);
            Debug.Log("Start was pressed");
        }
        if (State.Buttons.A == ButtonState.Pressed && PrevState.Buttons.A == ButtonState.Released)
        {
            SceneManager.LoadScene(1);
            Debug.Log("A was pressed");
        }
        if (State.Buttons.B == ButtonState.Pressed && PrevState.Buttons.B == ButtonState.Released)
        {
            Application.Quit();
        }

        if(GameResults.GetComponent<GameResults>().Results == 1)
        {
            P1Wins();
        }
        if (GameResults.GetComponent<GameResults>().Results == 2)
        {
            P2Wins();
        }
    }

    public void P1Wins()
    {
        WinnerText.GetComponent<Text>().text = "1";
        if(SelectedRobots.GetComponent<PlayerHolder>().Player1Robot == 0)
        {
            WinningBot.GetComponent<Image>().sprite = DVaBot;
        }
        if (SelectedRobots.GetComponent<PlayerHolder>().Player1Robot == 1)
        {
            WinningBot.GetComponent<Image>().sprite = FlackBot;
        }
        if (SelectedRobots.GetComponent<PlayerHolder>().Player1Robot == 2)
        {
            WinningBot.GetComponent<Image>().sprite = S76Bot;
        }
    }

    public void P2Wins()
    {
        WinnerText.GetComponent<Text>().text = "2";
        if (SelectedRobots.GetComponent<PlayerHolder>().Player2Robot == 0)
        {
            WinningBot.GetComponent<Image>().sprite = DVaBot;
        }
        if (SelectedRobots.GetComponent<PlayerHolder>().Player2Robot == 1)
        {
            WinningBot.GetComponent<Image>().sprite = FlackBot;
        }
        if (SelectedRobots.GetComponent<PlayerHolder>().Player2Robot == 2)
        {
            WinningBot.GetComponent<Image>().sprite = S76Bot;
        }
    }
}
