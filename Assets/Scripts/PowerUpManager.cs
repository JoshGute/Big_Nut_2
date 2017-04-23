/*******************************  Ducks in a Row  *********************************
Author: Josh 'Thought Power Ups Were A Good Idea And It Was But It Didn't Work Out' Gutenberg
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   PowerUpManager.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] PowerSpawns;
    public GameObject[] PowerUps;
    private GameObject gPowerUp;

    public delegate void PowerUpAction(GameObject gPowerUp_);
    public static event PowerUpAction PowerUpSpawned;

    void OnEnable()
    {
        HealthPowerUp.PowerUpCollected += StartPowerUps;
    }

    void OnDisable()
    {
        HealthPowerUp.PowerUpCollected -= StartPowerUps;
    }

    void Start()
    {
        print("Starting invoke");
        InvokeRepeating("SpawnPowerUp", 5, 5);
    }

    private void SpawnPowerUp()
    {
        //print("Hell");
        Destroy(gPowerUp);
        GameObject newPowerUp;

        int randSpawn = Random.Range(0, PowerSpawns.Length);
        int randPower = Random.Range(0, PowerUps.Length);

        newPowerUp = Instantiate(PowerUps[randPower].gameObject, PowerSpawns[randSpawn].transform.position, PowerUps[randPower].transform.rotation) as GameObject;
        gPowerUp = newPowerUp;

        //PowerUpSpawned(newPowerUp);
        CancelInvoke("SpawnPowerUp");
    }

    public void StartPowerUps(string sOwner_)
    {
        InvokeRepeating("SpawnPowerUp", 5, 5);
    }
}
