using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class StartLevelLogic : MonoBehaviour {

    private GamePadState State;
    private GamePadState prevState;
    private bool bController;

    public bool bDisabled;

    public PlayerIndex playerIndex;


	// Use this for initialization
	void Start ()
    {
	
	}
	
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
            }
        }
	
	}
}
