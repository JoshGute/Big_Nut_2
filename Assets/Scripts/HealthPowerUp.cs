using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public GameObject gExplosion;

    public delegate void PowerUpAction(string sOwner_);
    public static event PowerUpAction PowerUpCollected;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<PlayerControllerVer2>())
        {
            if (coll.gameObject.GetComponent<PlayerControllerVer2>().iHealth < 3)
            {
                coll.gameObject.GetComponent<PlayerControllerVer2>().iHealth += 1;
                PowerUpCollected(coll.gameObject.GetComponent<PlayerControllerVer2>().sOwner);

                Instantiate(gExplosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
