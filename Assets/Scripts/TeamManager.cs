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
        Spawn(pOwner.tag);
	}
	
    private void Spawn(string sOwner_)
    {
        //print("spawn called");

        if (sOwner_ == pOwner.tag)
        {
<<<<<<< HEAD
            bool bSpawned = false;
            int randNum = Random.Range(0, sSpawnPoints.Length);

            if (bPrioritySpawn)
=======
            if(iDeaths == gTeam.Length)
>>>>>>> origin/master
            {
                Victory(sOwner_);
            }
            else
            {
<<<<<<< HEAD
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
            
=======
                if (bPrioritySpawn)
                {
                    GameObject gRobot = Instantiate(gTeam[iDeaths], sPrioritySpawn.transform.position, gTeam[iDeaths].transform.rotation) as GameObject;
                    pOwner.TagRobot(gRobot);
                    ++iDeaths;
                }
                else
                {
                    //print("array of spawns being made");
                    sSafeSpawns = new Spawnpoint[sSpawnPoints.Length];
                    print(sSafeSpawns.Length);

                    for (int i = 0; i < sSpawnPoints.Length; i++)
                    {
                        if (sSpawnPoints[i].bIsSafe)
                        {
                            sSafeSpawns[i] = sSpawnPoints[i];
                            //print(sSafeSpawns[i] + " is safe");
                        }
                    }

                    int randNum = Random.Range(0, sSafeSpawns.Length);
                    //print("The randomy selected spawnpoint is " + randNum);
                   // print("spawning " + gTeam[iDeaths] + "at " + sSafeSpawns[randNum]);
                    GameObject gRobot = Instantiate(gTeam[iDeaths], sSafeSpawns[randNum].transform.position, gTeam[iDeaths].transform.rotation) as GameObject;
                    pOwner.TagRobot(gRobot);
                    ++iDeaths;
                }
            }           
>>>>>>> origin/master
        }
    }
}
