/*******************************  Ducks in a Row  *********************************
Author: Josh 'save me' Gutenberg
Contributors: Glen Aro
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   TeamManager.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;


public class TeamManager : MonoBehaviour
{

    public Camera cCamera;
    public HUD hHUD;
    public GameObject[] gTeam;
    public Spawnpoint[] sSpawnPoints;
    public Spawnpoint sPrioritySpawn1;
    public Spawnpoint sPrioritySpawn2;
    public bool bPrioritySpawn = false;

    public PlayerHolder pHolder;

    public GameObject SpawnBurst;

    public delegate void TeamWin(string sOwner);
    public static event TeamWin Victory;

    void OnEnable()
    {
        PlayerControllerVer2.Die += Spawn;
    }

    void OnDisable()
    {
        PlayerControllerVer2.Die -= Spawn;
    }
	void Start ()
    {
        pHolder = FindObjectOfType<PlayerHolder>();
        Application.targetFrameRate = 200;
        Spawn("PLAYER1");
        Spawn("PLAYER2");
	}
	
    private void Spawn(string sOwner_)
    {
        //hoo boy
        print("spawn called");

        bool bSpawned = false;
        int randNum = Random.Range(0, sSpawnPoints.Length);
        //int botRandNum = Random.Range(0, gTeam.Length);
        if (hHUD.CheckForWinner() != 0)
        {

        }
        else
        {
            if (bPrioritySpawn)
            {
                if (sOwner_ == "PLAYER1")
                {
                    print("priority spawn");
                    GameObject gRobot = Instantiate(gTeam[pHolder.Player1Robot], sPrioritySpawn1.transform.position, gTeam[pHolder.Player1Robot].transform.rotation) as GameObject;
                    gRobot.GetComponent<PlayerControllerVer2>().TagRobot(sOwner_);

                    bSpawned = true;

                    cCamera.GetComponent<FollowCam>().GetTarget(gRobot, 1);
                    hHUD.GetPlayer(gRobot, 1);
                    Instantiate(SpawnBurst, sPrioritySpawn1.transform.position, sPrioritySpawn1.transform.rotation);
                }

                else
                {
                    print("priority spawn");
                    GameObject gRobot = Instantiate(gTeam[pHolder.Player2Robot], sPrioritySpawn2.transform.position, gTeam[pHolder.Player2Robot].transform.rotation) as GameObject;
                    gRobot.GetComponent<PlayerControllerVer2>().TagRobot(sOwner_);

                    bSpawned = true;

                    cCamera.GetComponent<FollowCam>().GetTarget(gRobot, 2);
                    hHUD.GetPlayer(gRobot, 2);
                    Instantiate(SpawnBurst, sPrioritySpawn2.transform.position, sPrioritySpawn2.transform.rotation);
                }
            }

            else
            {
                print("random spawn");
                while (!bSpawned)
                {
                    if (sSpawnPoints[randNum].bIsSafe)
                    {
                        print("trying");
                        bSpawned = true;
                        Instantiate(SpawnBurst, sSpawnPoints[randNum].transform.position, sSpawnPoints[randNum].transform.rotation);

                        if (sOwner_ == "PLAYER1")
                        {
                            GameObject gRobot = Instantiate(gTeam[pHolder.Player1Robot], sSpawnPoints[randNum].transform.position, gTeam[pHolder.Player1Robot].transform.rotation) as GameObject;
                            gRobot.GetComponent<PlayerControllerVer2>().TagRobot(sOwner_);
                            cCamera.GetComponent<FollowCam>().GetTarget(gRobot, 1);
                            hHUD.GetPlayer(gRobot, 1);
                        }

                        else
                        {
                            GameObject gRobot = Instantiate(gTeam[pHolder.Player2Robot], sSpawnPoints[randNum].transform.position, gTeam[pHolder.Player2Robot].transform.rotation) as GameObject;
                            gRobot.GetComponent<PlayerControllerVer2>().TagRobot(sOwner_);
                            cCamera.GetComponent<FollowCam>().GetTarget(gRobot, 2);
                            hHUD.GetPlayer(gRobot, 2);
                        }
                    }

                    else
                    {
                        randNum = Random.Range(0, sSpawnPoints.Length);
                    }
                }
            }
        }     
    }
}
