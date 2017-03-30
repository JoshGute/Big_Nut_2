using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYSifnoParent : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
		if(GetComponentInParent<BulletScript>() == null)
        {
            Destroy(gameObject);
        }
	}
}
