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
        print("Hell");
        //Destroy(gPowerUp);

        int randSpawn = Random.Range(0, PowerSpawns.Length);
        int randPower = Random.Range(0, PowerUps.Length);

        gPowerUp = Instantiate(PowerUps[randPower].gameObject, PowerSpawns[randSpawn].transform.position, PowerUps[randPower].transform.rotation) as GameObject;
        PowerUpSpawned(gPowerUp);
        CancelInvoke("SpawnPowerUp");
    }

    public void StopPowerUps()
    {
        CancelInvoke("SpawnPowerUp");
    }

    public void StartPowerUps()
    {
        InvokeRepeating("SpawnPowerUp", 5, 5);
    }
}
