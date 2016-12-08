﻿/*******************************  SpaceTube  *********************************
Author: Matty Lanouette
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   HealthSliderLogic.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthSliderLogic : MonoBehaviour
{

    public BodyScript Parent;

    public float YellowLife;
    public float RedLife;

    public Image Fill;

    public Slider HealthBar;
    public Color FullHealth;
    public Color MediumHealth;
    public Color LowHealth;

	// Use this for initialization
    /*
	void Start ()
    {
        Parent = GetComponentInParent<BodyScript>();
        HealthBar = gameObject.GetComponent<Slider>();

        HealthBar.maxValue = Parent.fLifetime;

        Fill.color = FullHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        HealthBar.value = Parent.fLifetime;
	    if(Parent.fLifetime <= YellowLife)
        {
            Fill.color = MediumHealth;
            Debug.Log("yellow");
        }
        if(Parent.fLifetime <= RedLife)
        {
            Fill.color = LowHealth;
            Debug.Log("red");
        }
	} */
}
