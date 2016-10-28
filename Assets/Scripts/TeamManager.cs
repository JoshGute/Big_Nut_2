using UnityEngine;
using System.Collections;

public class TeamManager : MonoBehaviour
{
    public PlayerController pOwner;
    public GameObject[] gTeam;
    public Spawnpoint[] sSpawnPoints;
    public Spawnpoint sPrioritySpawn;
    public int iDeaths;
    private bool bPrioritySpawn = true;
	// Use this for initialization

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
        Spawn(pOwner.tag);
	}
	
    private void Spawn(string sOwner_)
    {
        print("spawn called");

        if (sOwner_ == pOwner.tag)
        {
            bool bSpawned = false;
            int randNum = Random.Range(0, sSpawnPoints.Length);

            if (bPrioritySpawn)
            {
                GameObject gRobot = Instantiate(gTeam[iDeaths], sPrioritySpawn.transform.position, gTeam[iDeaths].transform.rotation) as GameObject;
                pOwner.TagRobot(gRobot);
                ++iDeaths;
            }
            else
            {
                while(!bSpawned)
                {
                    if (sSpawnPoints[randNum].bIsSafe)
                    {
                        GameObject gRobot = Instantiate(gTeam[iDeaths], sSpawnPoints[randNum].transform.position, gTeam[iDeaths].transform.rotation) as GameObject;
                        pOwner.TagRobot(gRobot);
                        ++iDeaths;
                        bSpawned = true;
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
