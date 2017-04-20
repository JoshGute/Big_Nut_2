using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYSifnoParent : MonoBehaviour
{
	// Update is called once per frame
    public bool TimedDeath = false;
    public float Timer = 2;
	void Update ()
    {
		if(GetComponentInParent<BulletScript>() == null)
        {
            if (TimedDeath)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    TimedDeath = false;
                }
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
	}
}
