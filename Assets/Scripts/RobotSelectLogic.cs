﻿/*******************************  SpaceTube  *********************************
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
using UnityEngine.SceneManagement;


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

    public GameObject Me;
    public GameObject RobotHolder;

    public GameObject StartText;

    private IEnumerator coroutine;
    private IEnumerator coroutineB;

    private IEnumerable vibrationCoroutine;

    private bool IsHovered;

    public AudioSource SFX;
    public AudioSource Select;
    public AudioSource Deselect;
    

    // Use this for initialization
    void Start ()
    {
        SelectorTransform = GetComponent<RectTransform>();
        CanMove = true;
        MoveTimer = 15;

        spriteRen = GetComponent<SpriteRenderer>();

        coroutine = StopVibration(1.0f);
        coroutineB = StopBVibration(1.0f);

        vibrationCoroutine = Vibration(1.0f);

        IsHovered = false;
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
                    SFX.Play();
                    SelectorTransform.localPosition += new Vector3(70, 0, 0);
                }
                if (KeyAxisH < 0 && SelectorTransform.localPosition.x > 0)
                {
                    SFX.Play();
                    SelectorTransform.localPosition += new Vector3(-70, 0, 0);
                }
            }
        }

        if(CanMove == false)
        {
            --MoveTimer;
            if(MoveTimer <= 0)
            {
                MoveTimer = 15;
                CanMove = true;
            }
        }

        Vector3 backRay = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, backRay, Color.black);
        RaycastHit hit;

        if(RobotHolder.GetComponent<PlayerHolder>().Player1Robot != 0 && RobotHolder.GetComponent<PlayerHolder>().Player2Robot != 0)
        {
            StartText.GetComponent<Text>().enabled = true;
            if(State.Buttons.Start == ButtonState.Pressed && PrevState.Buttons.Start == ButtonState.Released)
            {
                SceneManager.LoadScene(1);
            }
        }

        if (Physics.Raycast(transform.position, backRay, out hit))
        {
            if (hit.collider.gameObject.name == "DVaBot")
            {
                SelectedRobot.GetComponent<SpriteRenderer>().sprite = DVaBot;
                SelectedRobot.GetComponent<Transform>().localScale = new Vector3(100, 100, 0);
                
                

                if(State.Buttons.A == ButtonState.Pressed && PrevState.Buttons.A == ButtonState.Released)
                {
                    bDisabled = true;
                    if(PlayerNumber == 1)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player1Robot = 0;

                        Robot1.GetComponent<Animator>().enabled = true;

                        //  GamePad.SetVibration(playerIndex, 0.5f, 0.5f);
                        // StartCoroutine(coroutine);
                        //  StartCoroutine(vibrationCoroutine);
                    }
                    if (PlayerNumber == 2)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player2Robot = 0;

                        Robot1.GetComponent<MenuAnimations>().PlayAnimaion();

                        //  GamePad.SetVibration(playerIndex, 0.5f, 0.5f);
                        // StartCoroutine(coroutine);
                    }


                }
                else if (State.Buttons.B == ButtonState.Pressed && PrevState.Buttons.B == ButtonState.Released)
                {
                    bDisabled = false;
                    if (PlayerNumber == 1)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player1Robot = -1;

                        Robot1.GetComponent<MenuAnimations>().StopAnimation();
                        // GamePad.SetVibration(playerIndex, 0.1f, 0.1f);
                        //  StartCoroutine(coroutineB);


                    }
                    if (PlayerNumber == 2)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player2Robot = -1;

                        Robot1.GetComponent<MenuAnimations>().StopAnimation();
                        // GamePad.SetVibration(playerIndex, 0.2f, 0.2f);
                        //StartCoroutine(coroutineB);
                    }

                }
            }

            if (hit.collider.gameObject.name == "HunkBot")
            {
                SelectedRobot.GetComponent<SpriteRenderer>().sprite = HunkBot;
                SelectedRobot.GetComponent<Transform>().localScale = new Vector3(100, 100, 0);

                if (State.Buttons.A == ButtonState.Pressed && PrevState.Buttons.A == ButtonState.Released)
                {
                    bDisabled = true;
                    if (PlayerNumber == 1)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player1Robot = 1;

                        Robot2.GetComponent<MenuAnimations>().PlayAnimaion();
                        // Debug.Log(RobotHolder.GetComponent<PlayerHolder>().Player1Robot);
                    }
                    if (PlayerNumber == 2)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player2Robot = 1;

                        Robot2.GetComponent<MenuAnimations>().PlayAnimaion();
                        // Debug.Log(RobotHolder.GetComponent<PlayerHolder>().Player2Robot);
                    }


                }
                else if (State.Buttons.B == ButtonState.Pressed && PrevState.Buttons.B == ButtonState.Released)
                {
                    bDisabled = false;
                    if (PlayerNumber == 1)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player1Robot = -1;

                        Robot2.GetComponent<MenuAnimations>().StopAnimation();
                        //  Debug.Log(RobotHolder.GetComponent<PlayerHolder>().Player1Robot);
                    }
                    if (PlayerNumber == 2)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player2Robot = -1;

                        Robot2.GetComponent<MenuAnimations>().StopAnimation();
                        //  Debug.Log(RobotHolder.GetComponent<PlayerHolder>().Player2Robot);
                    }

                }
            }
            if (hit.collider.gameObject.name == "S76Bot")
            {
                SelectedRobot.GetComponent<SpriteRenderer>().sprite = S76Bot;
                SelectedRobot.GetComponent<Transform>().localScale = new Vector3(100, 100, 0);
                

                if (State.Buttons.A == ButtonState.Pressed && PrevState.Buttons.A == ButtonState.Released)
                {
                    bDisabled = true;
                    if (PlayerNumber == 1)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player1Robot = 2;

                        Robot3.GetComponent<MenuAnimations>().PlayAnimaion();
                        // Debug.Log(RobotHolder.GetComponent<PlayerHolder>().Player1Robot);
                    }
                    if (PlayerNumber == 2)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player2Robot = 2;

                        Robot3.GetComponent<MenuAnimations>().PlayAnimaion();
                        // Debug.Log(RobotHolder.GetComponent<PlayerHolder>().Player2Robot);
                    }


                }
                else if (State.Buttons.B == ButtonState.Pressed && PrevState.Buttons.B == ButtonState.Released)
                {
                    bDisabled = false;
                    if (PlayerNumber == 1)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player1Robot = -1;

                        Robot3.GetComponent<MenuAnimations>().StopAnimation();
                        //  Debug.Log(RobotHolder.GetComponent<PlayerHolder>().Player1Robot);
                    }
                    if (PlayerNumber == 2)
                    {
                        RobotHolder.GetComponent<PlayerHolder>().Player2Robot = -1;

                        Robot3.GetComponent<MenuAnimations>().StopAnimation();
                        //   Debug.Log(RobotHolder.GetComponent<PlayerHolder>().Player2Robot);
                    }

                }
            }
            
        }
    }

    private IEnumerator StopVibration(float waitTime)
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            yield return new WaitForSeconds(0.2f);
            GamePad.SetVibration(playerIndex, 0f, 0f);
        }
        
    }

    private IEnumerator StopBVibration(float time)
    {
        
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            yield return new WaitForSeconds(0.3f);
            GamePad.SetVibration(playerIndex, 0f, 0f);
        }
    }

    private IEnumerable Vibration(float stopTime)
    {
        //enumerable.GetEnumerator()
        yield return new WaitForSeconds(0.2f);
        GamePad.SetVibration(playerIndex, 0f, 0f);
    }
}