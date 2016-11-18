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
        asNoiseMaker = GetComponent<AudioSource>();
        Spawn(pOwner.tag);
	}
	
    private void Spawn(string sOwner_)
    {
        print("spawn called");

        if (sOwner_ == pOwner.tag)
        {
            if(iDeaths > 0)
            {
                asNoiseMaker.PlayOneShot(acSpawnNoise);
                cCamera.GetComponent<FollowCam>().Shake(0.5f);
            }
            

            
            if (iDeaths == gTeam.Length)

            {
                Victory(sOwner_);
            }

            else
            {
                bool bSpawned = false;
                int randNum = Random.Range(0, sSpawnPoints.Length);

                if (sPrioritySpawn.bIsSafe)
                {
                    GameObject gRobot = Instantiate(gTeam[iDeaths], sPrioritySpawn.transform.position, gTeam[iDeaths].transform.rotation) as GameObject;
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

                else if(sPrioritySpawn.bIsSafe == false)
                {
                    while (!bSpawned)
                    {
                        if (sSpawnPoints[randNum].bIsSafe)
                        {
                            GameObject gRobot = Instantiate(gTeam[iDeaths], sSpawnPoints[randNum].transform.position, gTeam[iDeaths].transform.rotation) as GameObject;
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
            }
        }                     
    }
}
