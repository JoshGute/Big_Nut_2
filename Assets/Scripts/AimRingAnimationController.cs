using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRingAnimationController : MonoBehaviour {

  //The animator
  [SerializeField]
  private tk2dSpriteAnimator SpriteAnimator;

  [SerializeField]
  private GameObject Bolt;

  // Use this for initialization
  void Start ()
  {
    SpriteAnimator.AnimationEventTriggered = OnAnimComplete;
  }

  void OnAnimComplete(tk2dSpriteAnimator Animator, tk2dSpriteAnimationClip clip, int frameNo)
  {
    //CheckHealth();
  }

  public void PlayHealthDamageAnim(int curBoltHealth)
  {
    if (curBoltHealth == 3)
    {
      SpriteAnimator.Play("AimRing_3to2");
    }
    else if (curBoltHealth == 2)
    {
      SpriteAnimator.Play("AimRing_2to1");
    }
    else if (curBoltHealth == 1)
    {
      SpriteAnimator.Play("AimRing_1to0");
    }
  }

  void UpdateState(int health)
  {
    if(health == 2)
    {
      SpriteAnimator.Play("AimRing_2");
    }
    else if(health == 1)
    {
      SpriteAnimator.Play("AimRing_1");
    }
    else if (health == 0)
    {
      SpriteAnimator.Play("AimRing_0");
    }
  }

  // Update is called once per frame
  void Update ()
  {
		
	}
}
