/*******************************  Ducks in a Row  *********************************
Author: Matty Lanouette
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   HTPLogic.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

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
