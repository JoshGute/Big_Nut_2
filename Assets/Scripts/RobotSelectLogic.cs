/*******************************  SpaceTube  *********************************
Author: Matty Lanouette
Contributors: --
Course: GAM400
Game:   Bolt Blitz
Date:   12/7/2016
File:   RobotSelectLogic.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
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
    //public string Vertical = "Vertical_P1";

    public PlayerIndex playerIndex;

    public float MoveTimer;
    private bool CanMove;

    public GameObject Robot1;
    public GameObject Robot2;
    public GameObject Robot3;

    private SpriteRenderer spriteRen;

    public Sprite DVaBot;
    public Sprite HunkBot;
    public Sprite S76Bot;


    

    // Use this for initialization
    void Start ()
    {
        SelectorTransform = GetComponent<RectTransform>();
        CanMove = true;
        MoveTimer = 20;

        spriteRen = GetComponent<SpriteRenderer>();
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

            if (KeyAxisH != 0)
            {
                CanMove = false;
                if (KeyAxisH > 0 && SelectorTransform.localPosition.x < 140)
                {
                    SelectorTransform.localPosition += new Vector3(70, 0, 0);
                }
                if (KeyAxisH < 0 && SelectorTransform.localPosition.x > 0)
                {
                    SelectorTransform.localPosition += new Vector3(-70, 0, 0);
                }
            }
        }

        if(CanMove == false)
        {
            --MoveTimer;
            if(MoveTimer <= 0)
            {
                MoveTimer = 20;
                CanMove = true;
            }
        }

        Vector3 backRay = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, backRay, Color.black);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, backRay, out hit))
        {
            if (hit.collider.gameObject.name == "DVaBot")
            {
                //Debug.Log("DVa logging on");
                //SelectedRobot.GetComponent<SpriteRenderer>().color = Color.red;
                SelectedRobot.GetComponent<SpriteRenderer>().sprite = DVaBot;
                SelectedRobot.GetComponent<Transform>().localScale = new Vector3(100, 100, 0);
            }
            if (hit.collider.gameObject.name == "S76Bot")
            {
                //Debug.Log("We're all soldiers now");
                //SelectedRobot.GetComponent<SpriteRenderer>().color = Color.blue;
                SelectedRobot.GetComponent<SpriteRenderer>().sprite = S76Bot;
                SelectedRobot.GetComponent<Transform>().localScale = new Vector3(100, 100, 0);
            }
            if (hit.collider.gameObject.name == "HunkBot")
            {
                //Debug.Log("sup");
                //SelectedRobot.GetComponent<SpriteRenderer>().color = Color.yellow;
                SelectedRobot.GetComponent<SpriteRenderer>().sprite = HunkBot;
                SelectedRobot.GetComponent<Transform>().localScale = new Vector3(100, 100, 0);
            }
        }
    }
}