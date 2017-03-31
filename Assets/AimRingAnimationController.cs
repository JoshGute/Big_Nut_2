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
    CheckHealth();
  }

  void CheckHealth()
  {
    if(Bolt.GetComponent<PlayerControllerVer2>().iHealth == 2)
    {
      UpdateState(2);
    }
    else if(Bolt.GetComponent<PlayerControllerVer2>().iHealth == 1)
    {
      UpdateState(1);
    }
  }

  public void PlayHealthDamageAnim()
  {
    if (Bolt.GetComponent<PlayerControllerVer2>().iHealth == 3)
    {
      SpriteAnimator.Play("AimRing_3to2");
    }
    else if (Bolt.GetComponent<PlayerControllerVer2>().iHealth == 2)
    {
      SpriteAnimator.Play("AimRing_2to1");
    }
    else if (Bolt.GetComponent<PlayerControllerVer2>().iHealth == 1)
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
      SpriteAnimator.Play("AimRing_0");
    }
  }

  // Update is called once per frame
  void Update ()
  {
		
	}
}
