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
                GameObject newBullet;
                newBullet = Instantiate(aBullets[i].gameObject, transform.position, transform.rotation) as GameObject;
                //print(sOwner);
                newBullet.GetComponent<BulletScript>().sOwner = sOwner;
                //aBullets[i].sOwner = sOwner;
            }

            fCoolDown = 0;
        }

        if (fTimeAlive >= fLifeTime)
        {
            Destroy(gameObject);
        }
    }
}
