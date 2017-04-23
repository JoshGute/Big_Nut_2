/*******************************  Ducks in a Row  *********************************
Author: Matty Lanouette
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   QuitLogic.cs

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

public class QuitLogic : MonoBehaviour
{
    public Canvas QuitCanvas;

    private bool QuitOpen;

	// Use this for initialization
	void Start ()
    {
        QuitOpen = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void QuitMenu()
    {
        if(QuitOpen == false)
        {
            QuitCanvas.enabled = true;
            QuitOpen = true;
        }
    }

    public void Deny()
    {
        QuitCanvas.enabled = false;
        QuitOpen = false;
    }

    public void Confirm()
    {
        Application.Quit();
    }
}
