/*******************************  SpaceTube  *********************************
Author: Matty Lanouette
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   RobotHoverInfo.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*this script will handle all the info each robot contains
 * the RobotSelectionLogic talks to this, then this talks to the actual changing UI */
public class RobotHoverInfo : MonoBehaviour
{
    public bool isSelectable;

    public RobotInfo Info;

    // Use this for initialization
    void Start ()
    {
        isSelectable = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
	    
    }

    public void OnHover()
    {
        
    }
}
