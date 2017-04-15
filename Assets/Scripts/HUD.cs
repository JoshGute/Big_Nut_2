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
using UnityEngine.SceneManagement;

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

    public GameObject ResultsTracker;

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
        fCam.Shake(20.0f);

        if (sOwner_ == "PLAYER1")
        {
            P1hp.GetComponent<Text>().text = PlayerOne.iHealth.ToString();
        }

        else if (sOwner_ == "PLAYER2")
        {
            P2hp.GetComponent<Text>().text = PlayerTwo.iHealth.ToString();
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
        

        if (inWinner == "Player1")
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "Player 1 Wins!";
            ResultsTracker.GetComponent<GameResults>().Results = 1;
            //SceneManager.LoadScene(2);
        }

        else if (inWinner == "Player2")
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "Player 2 Wins!";
            ResultsTracker.GetComponent<GameResults>().Results = 2;
            //SceneManager.LoadScene(2);
        }

        //RestartButton.gameObject.SetActive(true);
        //Cursor.visible = true;
        StartCoroutine("DelayLoad");
    }

    public void GetPlayer(GameObject gPlayer_, int iPlayer_)
    {
        if (iPlayer_ == 1)
        {
            PlayerOne = gPlayer_.GetComponent<PlayerControllerVer2>();
        }

        else
        {
            PlayerTwo = gPlayer_.GetComponent<PlayerControllerVer2>();
        }
    }

    IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
