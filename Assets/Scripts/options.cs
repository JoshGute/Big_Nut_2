/******************************* Ducks in a Row *********************************
Author: Josh 'Big G' Gutenberg
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/9/2016
File:   options.cs

Description: This script exists in case we have to resubmit and add more options.
             :gun:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class options : MonoBehaviour
{
    public AudioSource aBGM;

    void Start()
    {
        aBGM = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    public void ToggleMute()
    {
        if (aBGM.volume != 0)
        {
            aBGM.volume = 0;
        }

        else
        {
            aBGM.volume = 1;
        }
    }

}
