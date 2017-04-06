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


	// Use this for initialization
	void Start ()
    {
        Debug.Log("im actually running");
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
	}
}
