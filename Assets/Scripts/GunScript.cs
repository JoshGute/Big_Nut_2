using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{
    public string sOwner;

    public GameObject PatternSpawn;

    public float fFireRate;
    private float fTimerForNext = 0;
    private bool bShot = true;

    public GunPattern gBulletPattern;

    void Update()
    {
        if (bShot == true && fTimerForNext < fFireRate)
        {
            fTimerForNext += Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (fTimerForNext >= fFireRate)
        {
            GameObject bulletPattern = Instantiate(gBulletPattern, PatternSpawn.transform.position, transform.rotation) as GameObject;
            //bulletPattern.GetComponent<GunPattern>().sOwner = sOwner;
            //bulletPattern.SetActive(false);
            bShot = true;
            fTimerForNext = 0;
        }
    }
}
