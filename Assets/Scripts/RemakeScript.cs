/*******************************  SpaceTube  *********************************
Author: Glen Aro
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   RemakeScript.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class RemakeScript : MonoBehaviour
{
    public void RebuildLevel(string sLevelToLoad)
    {
        Application.LoadLevel(sLevelToLoad);
    }
}
