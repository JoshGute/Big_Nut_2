/*******************************  Ducks in a Row  *********************************
Author: Josh Gutenberg
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
    public PlayerController pOwner;
    public GameObject[] gTeam;
    public Spawnpoint[] sSpawnPoints;
    public Spawnpoint sPrioritySpawn;
    public int iDeaths;
    private bool bPrioritySpawn = true;
    // Use this for initialization

    public AudioClip acSpawnNoise;
    private AudioSource asNoiseMaker;

    public delegate void TeamWin(string sOwner);
    public static event TeamWin Victory;

    void OnEnable()
    {
        BodyScript.Die += Spawn;
    }

    void OnDisable()
    {
        BodyScript.Die -= Spawn;
    }
	void Start ()
    {
        Application.targetFrameRate = 200;
        Cursor.visible = false;
        asNoiseMaker = GetComponent<AudioSource>();
        Spawn(pOwner.tag);
	}
	
    private void Spawn(string sOwner_)
    {
        print("spawn called");

        if (sOwner_ == pOwner.tag)
        {
            //this code is relevant for our old wincon, now we have a new one so we'll have to reowrk it to fit.
            /*if(iDeaths > 0)
            {
                cCamera.GetComponent<FollowCam>().Shake(0.5f);
                if(iDeaths > 1)
                {
                    asNoiseMaker.PlayOneShot(acSpawnNoise);
                }
            }

            if (iDeaths == gTeam.Length)
            {
                Victory(sOwner_);
                Cursor.visible = true;
            }*/

            bool bSpawned = false;
            int randNum = Random.Range(0, sSpawnPoints.Length);

            if (sPrioritySpawn.bIsSafe == false)
            {
                print("random spawn");
                while (!bSpawned)
                {
                    if (sSpawnPoints[randNum].bIsSafe)
                    {
                        GameObject gRobot = Instantiate(gTeam[0], sSpawnPoints[randNum].transform.position, gTeam[0].transform.rotation) as GameObject;
                        pOwner.TagRobot(gRobot);
                        ++iDeaths;
                        bSpawned = true;
                        if (pOwner.tag == "Player1")
                        {
                            cCamera.GetComponent<FollowCam>().GetTarget(gRobot, 1);
                        }

                        else
                        {
                            cCamera.GetComponent<FollowCam>().GetTarget(gRobot, 2);
                        }
                    }

                    else
                    {
                        randNum = Random.Range(0, sSpawnPoints.Length);
                    }
                }
            }

            else
            {
                if (sPrioritySpawn.bIsSafe)
                {
                    print("priority spawn");
                    GameObject gRobot = Instantiate(gTeam[0], sPrioritySpawn.transform.position, gTeam[0].transform.rotation) as GameObject;
                    pOwner.TagRobot(gRobot);

                    ++iDeaths;
                    print(gTeam[0]);
                    bSpawned = true;

                    if (pOwner.tag == "Player1")
                    {
                        cCamera.GetComponent<FollowCam>().GetTarget(gRobot, 1);
                    }

                    else
                    {
                        cCamera.GetComponent<FollowCam>().GetTarget(gRobot, 2);
                    }
                }
            }
        }                     
    }
}
