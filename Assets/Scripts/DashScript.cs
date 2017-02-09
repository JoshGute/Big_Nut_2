/******************************* Ducks in a Row *********************************
Author: Josh 'The Package' Gutenberg
Contributors: -- Linus Chan
Course: GAM450
Game:   Big Nut
Date:   12/20/2016
File:   DashScript

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class DashScript : MonoBehaviour
{
    private bool DashState = false;
    public string sOwner = "PLAYER1";
    public float fKnockback = 0;

    public void UpdateDashState()
    {
        if (DashState == true)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

        else if(DashState == false)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void TurnOnDash()
    {
        DashState = true;
        UpdateDashState();
    }

    public void TurnOffDash()
    {
        DashState = false;
        UpdateDashState();
    }
}
