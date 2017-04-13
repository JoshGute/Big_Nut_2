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
