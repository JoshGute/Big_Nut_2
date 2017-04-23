/*******************************  Ducks in a Row  *********************************
Author: Josh 'AHHHHHHHHHHH' Gutenberg
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   ButtonSelector.cs

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

public class ButtonSelector : MonoBehaviour
{
    public void grabButton(Button button_)
    {
        button_.Select();
    }
}
