/*******************************  SpaceTube  *********************************
Author: Josh 'Avoids Contact' Gutenberg
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   BitFade.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class BitFade : MonoBehaviour
{
    private tk2dSprite tSprite;
    private Renderer rRenderer;
    private float fScale = 0;


    void Start ()
    {
        if (GetComponent<tk2dSprite>())
        {
            tSprite = GetComponent<tk2dSprite>();
            rRenderer = null;
        }

        else if (GetComponentInChildren<tk2dSprite>())
        {
            tSprite = GetComponentInChildren<tk2dSprite>();
            rRenderer = null;
        }

        else
        {
            tSprite = null;
            rRenderer = GetComponent<Renderer>();
        }
	}
	
	void Update ()
    {
        if (tSprite != null)
        {
            tSprite.color = Color.Lerp(Color.white, Color.clear, fScale += 0.003f);
            if (tSprite.color == Color.clear)
            {
                Destroy(gameObject);
            }
        }

        else if (rRenderer != null)
        {
            rRenderer.material.color = Color.Lerp(Color.white, Color.clear, fScale += 0.003f);
            if (rRenderer.material.color == Color.clear)
            {
                Destroy(gameObject);
            }
        }
	}
}
