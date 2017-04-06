using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    private GameObject cCamera;

	// Use this for initialization
	void Start ()
    {
        cCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cCamera.GetComponent<FollowCam>().Shake(3f);
        StartCoroutine(timedDestroy(2));

        foreach (Transform child in transform)
        {
            if (child.GetComponent<Rigidbody>())
            {
                child.GetComponent<Rigidbody>().AddExplosionForce(4000, child.transform.position, 20.0f);
                child.SetParent(null);
            }
        }
	}

    private IEnumerator timedDestroy(int iWaitTime)
    {
        yield return new WaitForSeconds(iWaitTime);
        Destroy(gameObject);
    }
}
