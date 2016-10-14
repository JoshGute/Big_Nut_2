using UnityEngine;
using System.Collections;

public class GunPattern : MonoBehaviour {

    public string sOwner;

    public BulletScript[] aBullets;

    public float fFireRate;

    public int iBulletsPerTick;
    private float fCoolDown;
    public float fLifeTime;
    private float fTimeAlive;

    void Start()
    {

    }

    void Update()
    {
        fCoolDown += Time.deltaTime;
        fTimeAlive += Time.deltaTime;

        if(fCoolDown >= fFireRate)
        {
            for(int i = 0; i < iBulletsPerTick; i++)
            {
                Instantiate(aBullets[i], transform.position, transform.rotation);
                aBullets[i].sOwner = sOwner;
            }

            fCoolDown = 0;
        }

        if (fTimeAlive >= fLifeTime)
        {
            Destroy(gameObject);
        }
    }
}
