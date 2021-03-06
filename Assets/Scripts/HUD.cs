﻿/*******************************  Ducks in a Row   *********************************
Author: Glen Aro
Contributors: Matty Lanouette, Josh Gutenberg
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   HUD.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class HUD : MonoBehaviour
{

    public PlayerControllerVer2 PlayerOne;
    public PlayerControllerVer2 PlayerTwo;

    public GameObject P1robs;
    public GameObject P2robs;

    public GameObject P1hp;
    public GameObject P2hp;

    public Text WinText;

    public Button RestartButton;

    public GameObject P1Corner;
    public GameObject P2Corner;

    private int P1Kills;
    private int P2Kills;
    public int MaxKills = 3;

    public FollowCam fCam;

    public GameResults ResultsTracker;

    public GameObject pIndicator1;
    public GameObject pIndicator2;

    void OnEnable()
    {
       PlayerControllerVer2.Die += UpdateBotsLeft;
       PlayerControllerVer2.Hit += UpdateHealth;
       HealthPowerUp.PowerUpCollected += UpdateHealth;
    }

    void OnDisable()
    {
        PlayerControllerVer2.Die -= UpdateBotsLeft;
        PlayerControllerVer2.Hit -= UpdateHealth;
    }
    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
        WinText.gameObject.SetActive(true);
        WinText.text = "";
        WinText.gameObject.SetActive(false);
        P1Kills = 0;
        P2Kills = 0;
        P1robs.GetComponent<Text>().text = P1Kills.ToString();
        P2robs.GetComponent<Text>().text = P2Kills.ToString();
        P1hp.GetComponent<Text>().text = PlayerOne.iHealth.ToString();
        P1hp.GetComponent<Text>().text = PlayerOne.iHealth.ToString();
    }

    // Update is called once per frame

    void UpdateHealth(string sOwner_)
    {
        if (sOwner_ == "PLAYER1")
        {
            P1hp.GetComponent<Text>().text = PlayerOne.iHealth.ToString();
            fCam.Shake(10.0f);
        }

        else if (sOwner_ == "PLAYER2")
        {
            P2hp.GetComponent<Text>().text = PlayerTwo.iHealth.ToString();
            fCam.Shake(10.0f);
        }
    }

    void UpdateBotsLeft(string sOwner_)
    {
        if (P1Kills < MaxKills && P2Kills < MaxKills)
        {
            if (sOwner_ == "PLAYER1")
            {
                ++P2Kills;
                P2robs.GetComponent<Text>().text = P2Kills.ToString();
                if (P2Kills >= MaxKills)
                {
                    UpdateWinner(sOwner_);
                }
            }

            else if (sOwner_ == "PLAYER2")
            {
                ++P1Kills;
                P1robs.GetComponent<Text>().text = P1Kills.ToString();
                if (P1Kills >= MaxKills)
                {
                    UpdateWinner(sOwner_);
                }
            }

        }
    }

    void UpdateWinner(string inWinner)
    {
        

        if (inWinner == "PLAYER2")
        {
            ResultsTracker.Results = 1;
        }

        else if (inWinner == "PLAYER1")
        {
            ResultsTracker.Results = 2;
        }

        StartCoroutine("DelayLoad");
    }

    public void GetPlayer(GameObject gPlayer_, int iPlayer_)
    {
        if (iPlayer_ == 1)
        {
            PlayerOne = gPlayer_.GetComponent<PlayerControllerVer2>();
            GameObject Indicator;
            Indicator = Instantiate(pIndicator1, pIndicator1.transform.position, pIndicator1.transform.rotation) as GameObject;
            Indicator.GetComponent<PlayerIndicator>().PlayertoDisplay = gPlayer_.GetComponent<PlayerControllerVer2>().sOwner;
            Indicator.GetComponent<PlayerIndicator>().Player = gPlayer_;
            Indicator.GetComponent<PlayerIndicator>().UpdateSprite();
        }

        else
        {
            PlayerTwo = gPlayer_.GetComponent<PlayerControllerVer2>();
            GameObject Indicator;
            Indicator = Instantiate(pIndicator2, pIndicator2.transform.position, pIndicator2.transform.rotation) as GameObject;
            Indicator.GetComponent<PlayerIndicator>().PlayertoDisplay = gPlayer_.GetComponent<PlayerControllerVer2>().sOwner;
            Indicator.GetComponent<PlayerIndicator>().Player = gPlayer_;
            Indicator.GetComponent<PlayerIndicator>().UpdateSprite();
        }
    }

    IEnumerator DelayLoad()
    {     
        yield return new WaitForSeconds(1.1f);
        GamePad.SetVibration(PlayerOne.playerIndex, 0, 0);
        GamePad.SetVibration(PlayerTwo.playerIndex, 0, 0);
        SceneManager.LoadScene("Results");
    }

    public int CheckForWinner()
    {
        if (P1Kills >= MaxKills)
        {
            return 1;
        }
        else if (P2Kills >= MaxKills)
        {
            return 2;
        }
        else
        {
            return 0;
        } 
    }
}
