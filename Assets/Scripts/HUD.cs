/*******************************  SpaceTube  *********************************
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

public class HUD : MonoBehaviour
{

    public TeamManager PlayerOne;
    public TeamManager PlayerTwo;

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

    void OnEnable()
    {
        BodyScript.Die += UpdateBotsLeft;
    }

    void OnDisable()
    {
        BodyScript.Die -= UpdateBotsLeft;
    }
    // Use this for initialization
    void Start ()
    {
        WinText.gameObject.SetActive(true);
        WinText.text = "";
        WinText.gameObject.SetActive(false);
        P1Kills = 0;
        P2Kills = 0;
        P1robs.GetComponent<Text>().text = P1Kills.ToString();
        P2robs.GetComponent<Text>().text = P2Kills.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        P1hp.GetComponent<Text>().text = PlayerOne.pOwner.bBody.iHealth.ToString();
        P2hp.GetComponent<Text>().text = PlayerTwo.pOwner.bBody.iHealth.ToString();
    }

    void UpdateBotsLeft(string inOwner)
    {
        if(inOwner == "Player1")
        {
            ++P2Kills;
            P2robs.GetComponent<Text>().text = P2Kills.ToString();
            if (P2Kills >= MaxKills)
            {
                UpdateWinner(inOwner);
            }
        }

        else if (inOwner == "Player2")
        {
            ++P1Kills;
            P1robs.GetComponent<Text>().text = P1Kills.ToString();
            if (P1Kills >= MaxKills)
            {
                UpdateWinner(inOwner);
            }
        }
    }

    void UpdateWinner(string inWinner)
    {
        if (inWinner == "Player1")
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "Player 1 Wins!";
        }

        else if (inWinner == "Player2")
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "Player 2 Wins!";
        }

        RestartButton.gameObject.SetActive(true);
        Cursor.visible = true;
    }
}
