using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using XInputDotNetPure;

public class RobotSelectLogic : MonoBehaviour
{
    public Image Robot;
    public GameObject PlayerSelector;

    public int PlayerNumber;
    public Vector3 Position;

    private RectTransform SelectorTransform;

    private float KeyAxisH;
    private float KeyAxisV;

    private GamePadState State;

    private bool bController;

    public bool bDisabled;

    public string Horizontal = "Horizontal_P1";
    public string Vertical = "Vertical_P1";

    public PlayerIndex playerIndex;

	// Use this for initialization
	void Start ()
    {
        SelectorTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!bDisabled)
        {
            State = GamePad.GetState(playerIndex);

            KeyAxisH = State.ThumbSticks.Left.X;
            KeyAxisV = State.ThumbSticks.Left.Y;

            { 
            if(KeyAxisH != 0)
            {
                if (KeyAxisH > 0 && SelectorTransform.localPosition.x < 75)
                {
                    SelectorTransform.localPosition += new Vector3(125, 0, 0);
                }
                if (KeyAxisH < 0 && SelectorTransform.localPosition.x > -50)
                {
                    SelectorTransform.localPosition += new Vector3(-125, 0, 0);
                }

            }
            if(KeyAxisV != 0)
            {
                if (KeyAxisV > 0 && SelectorTransform.localPosition.y < 170)
                {
                    SelectorTransform.localPosition += new Vector3(0, 115, 0);
                }
                if (KeyAxisV < 0 && SelectorTransform.localPosition.y > -170)
                {
                    SelectorTransform.localPosition += new Vector3(0, -115, 0);
                }
            }
            
         }


        if (PlayerNumber == 1)
        {
            if(Input.GetKeyDown(KeyCode.W) && SelectorTransform.localPosition.y < 170)
            {
                SelectorTransform.localPosition += new Vector3(0, 115, 0);
            }
            if(Input.GetKeyDown(KeyCode.S) && SelectorTransform.localPosition.y > -170)
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

    public void OnHover()
    {
        // check what player is doing the thing


    }
}
