/*******************************  DuckInARow  *********************************
Author: Glen Aro
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   ScaleOverTime.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class ScaleOverTime : MonoBehaviour {

    private Vector3 StartingScale;
    public Vector3 MaxScale;
    public Vector3 ScalePerTick;
    public float fScaleRate;

    private float FTimertoNextScale;
    private bool ScaleMet = false;
    private Transform TargetToScale;

    public bool bReturnToOriginalSize;
    public bool bLooping;

	// Use this for initialization
	void Start ()
    {
        TargetToScale = GetComponent<Transform>();
        StartingScale = TargetToScale.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(ScaleMet == false)
        {
            FTimertoNextScale += Time.deltaTime;

            if (FTimertoNextScale >= fScaleRate)
            {
                FTimertoNextScale = 0;
                //print("scale time");

                TargetToScale.localScale += ScalePerTick;

                if(TargetToScale.localScale.x >= MaxScale.x)
                {
                    ScaleMet = true;
                }
            }
        }

        if(ScaleMet == true && bReturnToOriginalSize == true)
        {
            FTimertoNextScale += Time.deltaTime;

            if (FTimertoNextScale >= fScaleRate)
            {
                FTimertoNextScale = 0;
                //print("scale time");

                TargetToScale.localScale -= ScalePerTick;

                if (TargetToScale.localScale.x <= StartingScale.x)
                {

                    TargetToScale.localScale = StartingScale;

                    if(bLooping)
                    {
                        ScaleMet = false;
                    }
                }
            }
        }
	}
}
