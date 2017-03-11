using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;

    public GameObject Me;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayAnimaion()
    {
        Me.GetComponent<Animator>().enabled = true;
    }

    public void StopAnimation()
    {
        Me.GetComponent<Animator>().enabled = false;
    }

}
