using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{
    public string sOwner;

    public GameObject PatternSpawn;

    public float fFireRate;
    public float fTimerForNext = 0;
    //private bool bShot = true;

    public GunPattern gBulletPattern;

    public AudioClip ShootingNoise;
    public AudioClip ReloadNoise;
    public AudioClip MissNoise;

    public AudioSource RobotAudioSource;

    void Update()
    {
        if (fTimerForNext < fFireRate)
        {
            fTimerForNext += Time.deltaTime;
        }
    }

    public virtual void Shoot()
    {
        RobotAudioSource.PlayOneShot(ShootingNoise);

        if (fTimerForNext >= fFireRate)
        {
            GameObject bulletPattern = Instantiate(gBulletPattern, PatternSpawn.transform.position, transform.rotation) as GameObject;
            fTimerForNext = 0;
        }
    }
}
