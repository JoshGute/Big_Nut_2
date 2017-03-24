/*******************************  Ducks in a Row  *********************************
Author: Linus 'why' Chan
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   3/24/2017
File:   ParticleSpawner.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour {

  //The prefab we want to spawn
  [SerializeField]
  GameObject Particle;

  private float Spawntimer;

  [SerializeField]
  private float SpawnEveryXSeconds;

  [SerializeField]
  private bool SpawnParticleAutomatically = false;

  bool SpawnParticle = false;

	// Use this for initialization
	void Start ()
  {
		if(SpawnParticleAutomatically == true)
    {
      SpawnParticle = true;
    }
    else
    {
      SpawnParticle = false;
    }
	}
	
  public void SpawnParticles()
  {
    SpawnParticle = true;
  }

  public void StopSpawningParticles()
  {
    SpawnParticle = false;
  }

	// Update is called once per frame
	void Update ()
  {
    if (SpawnParticle == true)
    {
      Spawntimer += Time.deltaTime;

      //Spawn the particle
      if (Spawntimer > SpawnEveryXSeconds)
      {
        Instantiate(Particle, gameObject.transform.position, gameObject.transform.rotation);

        Spawntimer = 0;
      }
    }
	}
}
