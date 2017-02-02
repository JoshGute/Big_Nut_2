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
        cCamera.GetComponent<FollowCam>().Shake(1f);
        StartCoroutine(timedDestroy(2));
	}

    private IEnumerator timedDestroy(int iWaitTime)
    {
        yield return new WaitForSeconds(iWaitTime);
        Destroy(gameObject);
    }
}
