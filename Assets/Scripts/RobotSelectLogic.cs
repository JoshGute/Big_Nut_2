﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using XInputDotNetPure;

public class RobotSelectLogic : MonoBehaviour
{
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

    public GameObject Robot1;
    public GameObject Robot2;
    public GameObject Robot3;

    private List<GameObject> Team = new List<GameObject>();

    

    // Use this for initialization
    void Start ()
    {
        SelectorTransform = GetComponent<RectTransform>();
        CanMove = true;
        MoveTimer = 10;
        
	}

	// Update is called once per frame
	void Update ()
    {
        PrevState = State;
        State = GamePad.GetState(playerIndex);

        if (!bDisabled && CanMove == true)
        {

            KeyAxisH = State.ThumbSticks.Left.X;
            KeyAxisV = State.ThumbSticks.Left.Y;

            if(KeyAxisH != 0)
            {
                CanMove = false;
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
                CanMove = false;
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
        if(CanMove == false)
        {
            --MoveTimer;
            if(MoveTimer <= 0)
            {
                MoveTimer = 10;
                CanMove = true;
            }
        }

        //keyboard controls left in for testing -- matty
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

        //keyboard controls left in for testing -- matty
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

        Vector3 backRay = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, backRay, Color.black);
        RaycastHit hit;
        

        if(Physics.Raycast(transform.position, backRay, out hit))
        {

            //Debug.Log(hit.collider.gameObject);
            if(hit.collider.gameObject.name == "TopLeft")
            {
                SelectedRobot.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite;
                

                if (PrevState.Buttons.A == ButtonState.Released && State.Buttons.A == ButtonState.Pressed)
                {
                    Team.Add(hit.collider.gameObject);
                    if (Team[0] == hit.collider.gameObject)
                    {
                        Robot1.GetComponent<Image>().sprite = Team[0].GetComponent<Image>().sprite;
                    }
                    else if(Team[1] == hit.collider.gameObject)
                    {
                        Robot2.GetComponent<Image>().sprite = Team[1].GetComponent<Image>().sprite;
                    }
                    else if (Team[2] == hit.collider.gameObject)
                    {
                        Robot3.GetComponent<Image>().sprite = Team[2].GetComponent<Image>().sprite;
                    }
                    hit.collider.gameObject.GetComponent<RobotHoverInfo>().isSelectable = false;
                }
  
            }
            else if (hit.collider.gameObject.name == "TopRight")
            {
                SelectedRobot.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite;

                if (PrevState.Buttons.A == ButtonState.Released && State.Buttons.A == ButtonState.Pressed)
                {
                    Team.Add(hit.collider.gameObject);
                    if (Team[0] == hit.collider.gameObject)
                    {
                        Robot1.GetComponent<Image>().sprite = Team[0].GetComponent<Image>().sprite;
                    }
                    else if (Team[1] == hit.collider.gameObject)
                    {
                        Robot2.GetComponent<Image>().sprite = Team[1].GetComponent<Image>().sprite;
                    }
                    else if (Team[2] == hit.collider.gameObject)
                    {
                        Robot3.GetComponent<Image>().sprite = Team[2].GetComponent<Image>().sprite;
                    }
                    hit.collider.gameObject.GetComponent<RobotHoverInfo>().isSelectable = false;
                }

            }
            else if (hit.collider.gameObject.name == "3Left")
            {
                SelectedRobot.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite;

                if (PrevState.Buttons.A == ButtonState.Released && State.Buttons.A == ButtonState.Pressed)
                {
                    Team.Add(hit.collider.gameObject);
                    if (Team[0] == hit.collider.gameObject)
                    {
                        Robot1.GetComponent<Image>().sprite = Team[0].GetComponent<Image>().sprite;
                    }
                    else if (Team[1] == hit.collider.gameObject)
                    {
                        Robot2.GetComponent<Image>().sprite = Team[1].GetComponent<Image>().sprite;
                    }
                    else if (Team[2] == hit.collider.gameObject)
                    {
                        Robot3.GetComponent<Image>().sprite = Team[2].GetComponent<Image>().sprite;
                    }
                    hit.collider.gameObject.GetComponent<RobotHoverInfo>().isSelectable = false;
                }
            }
            else if (hit.collider.gameObject.name == "3Right")
            {
                SelectedRobot.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite;

                if (PrevState.Buttons.A == ButtonState.Released && State.Buttons.A == ButtonState.Pressed)
                {
                    Team.Add(hit.collider.gameObject);
                    if (Team[0] == hit.collider.gameObject)
                    {
                        Robot1.GetComponent<Image>().sprite = Team[0].GetComponent<Image>().sprite;
                    }
                    else if (Team[1] == hit.collider.gameObject)
                    {
                        Robot2.GetComponent<Image>().sprite = Team[1].GetComponent<Image>().sprite;
                    }
                    else if (Team[2] == hit.collider.gameObject)
                    {
                        Robot3.GetComponent<Image>().sprite = Team[2].GetComponent<Image>().sprite;
                    }
                    hit.collider.gameObject.GetComponent<RobotHoverInfo>().isSelectable = false;
                }
            }
            else if (hit.collider.gameObject.name == "2Left")
            {
                SelectedRobot.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite;

                if (PrevState.Buttons.A == ButtonState.Released && State.Buttons.A == ButtonState.Pressed)
                {
                    Team.Add(hit.collider.gameObject);
                    if (Team[0] == hit.collider.gameObject)
                    {
                        Robot1.GetComponent<Image>().sprite = Team[0].GetComponent<Image>().sprite;
                    }
                    else if (Team[1] == hit.collider.gameObject)
                    {
                        Robot2.GetComponent<Image>().sprite = Team[1].GetComponent<Image>().sprite;
                    }
                    else if (Team[2] == hit.collider.gameObject)
                    {
                        Robot3.GetComponent<Image>().sprite = Team[2].GetComponent<Image>().sprite;
                    }
                    hit.collider.gameObject.GetComponent<RobotHoverInfo>().isSelectable = false;
                }
            }
            else if (hit.collider.gameObject.name == "2Right")
            {
                SelectedRobot.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite;

                if (PrevState.Buttons.A == ButtonState.Released && State.Buttons.A == ButtonState.Pressed)
                {
                    Team.Add(hit.collider.gameObject);
                    if (Team[0] == hit.collider.gameObject)
                    {
                        Robot1.GetComponent<Image>().sprite = Team[0].GetComponent<Image>().sprite;
                    }
                    else if (Team[1] == hit.collider.gameObject)
                    {
                        Robot2.GetComponent<Image>().sprite = Team[1].GetComponent<Image>().sprite;
                    }
                    else if (Team[2] == hit.collider.gameObject)
                    {
                        Robot3.GetComponent<Image>().sprite = Team[2].GetComponent<Image>().sprite;
                    }
                    hit.collider.gameObject.GetComponent<RobotHoverInfo>().isSelectable = false;
                }
            }
            else if (hit.collider.gameObject.name == "BottomLeft")
            {
                SelectedRobot.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite;

                if (PrevState.Buttons.A == ButtonState.Released && State.Buttons.A == ButtonState.Pressed)
                {
                    Team.Add(hit.collider.gameObject);
                    if (Team[0] == hit.collider.gameObject)
                    {
                        Robot1.GetComponent<Image>().sprite = Team[0].GetComponent<Image>().sprite;
                    }
                    else if (Team[1] == hit.collider.gameObject)
                    {
                        Robot2.GetComponent<Image>().sprite = Team[1].GetComponent<Image>().sprite;
                    }
                    else if (Team[2] == hit.collider.gameObject)
                    {
                        Robot3.GetComponent<Image>().sprite = Team[2].GetComponent<Image>().sprite;
                    }
                    hit.collider.gameObject.GetComponent<RobotHoverInfo>().isSelectable = false;
                }
            }
            else if (hit.collider.gameObject.name == "BottomRight")
            {
                SelectedRobot.GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite;

                if (PrevState.Buttons.A == ButtonState.Released && State.Buttons.A == ButtonState.Pressed)
                {
                    Team.Add(hit.collider.gameObject);
                    if (Team[0] == hit.collider.gameObject)
                    {
                        Robot1.GetComponent<Image>().sprite = Team[0].GetComponent<Image>().sprite;
                    }
                    else if (Team[1] == hit.collider.gameObject)
                    {
                        Robot2.GetComponent<Image>().sprite = Team[1].GetComponent<Image>().sprite;
                    }
                    else if (Team[2] == hit.collider.gameObject)
                    {
                        Robot3.GetComponent<Image>().sprite = Team[2].GetComponent<Image>().sprite;
                    }
                    hit.collider.gameObject.GetComponent<RobotHoverInfo>().isSelectable = false;
                }
            }
        }
	}

    public void AddToTeam()
    {
        
        
    }
}