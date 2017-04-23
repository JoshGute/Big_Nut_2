/*******************************  Ducks in a Row  *********************************
Author: Glen Aro
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   BorderHider.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHider : MonoBehaviour {

    public MeshRenderer ObjectToReveal;
    private bool RevealObject = false;
    private Vector4 MaterialColor;

	// Use this for initialization
	void Start () 
    {
        MaterialColor = ObjectToReveal.material.color;	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (RevealObject == false)
        {
            //print("1 " + RevealObject);
            ObjectToReveal.material.color = new Vector4(MaterialColor.x, MaterialColor.y, MaterialColor.z, 0);
        }	

        if (RevealObject)
        {
            //print("2 " + RevealObject);
            ObjectToReveal.material.color = new Vector4(MaterialColor.x, MaterialColor.y, MaterialColor.z, ObjectToReveal.material.color.a + 0.05f);
        }

	}

    void OnTriggerStay(Collider col)
    {
        if (col.GetComponent<PlayerControllerVer2>())
        {
            RevealObject = true;
        }       
    }

    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<PlayerControllerVer2>())
        {
            RevealObject = false;
        }
    }
}
