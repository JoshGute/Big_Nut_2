using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HTPLogic : MonoBehaviour
{
    private bool HTPOpen;

    public Image HTPImage;
    
	// Use this for initialization
	void Start ()
    {
        HTPOpen = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void HTPMenu()
    {
        if(HTPOpen == false)
        {
            HTPImage.GetComponent<Image>().enabled = true;
            HTPOpen = true;
        }
        else if(HTPOpen == true)
        {
            HTPImage.GetComponent<Image>().enabled = false;
            HTPOpen = false;
        }
    }
}
