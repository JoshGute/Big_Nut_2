/*******************************  Ducks in a Row  *********************************
Author: Linus Chan
Contributors: 
Course: GAM450
Game:   Bolt Blitz
Date:   4/22/2017
File:   PlayAnimOnce.cs

Description:


Current Problems:


Copyright (C) 2017 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnce : MonoBehaviour {

  //The animator
  [SerializeField]
  private tk2dSpriteAnimator SpriteAnimator;

  //The name of the animation we are playing
  [SerializeField]
  private string AnimationName;

  //Whether or not to destroy after playing the animation
  [SerializeField]
  private bool DestroyAfterAnimation;

  // Use this for initialization
  void Start ()
  {
    SpriteAnimator.AnimationEventTriggered = OnAnimComplete;
  }

  public void PlayAnim()
  {
    SpriteAnimator.Play(AnimationName);
  }

  void OnAnimComplete (tk2dSpriteAnimator Animator, tk2dSpriteAnimationClip clip, int frameNo)
  {
    if(DestroyAfterAnimation == true)
    {
      Destroy();
    }
  }

  void Destroy()
  {
    Destroy(gameObject);
  }

	// Update is called once per frame
	void Update ()
  {

  }
}
