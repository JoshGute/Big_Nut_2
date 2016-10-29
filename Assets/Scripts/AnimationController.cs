using UnityEngine;
using System.Collections;


/*Much of this code taken from a 2d toolkit website tutorial and expanded upon.*/
public class AnimationController : MonoBehaviour {

  //Reference to the animator components of each body part.
  [SerializeField]
  private tk2dSpriteAnimator HeadAnimator;

  [SerializeField]
  private tk2dSpriteAnimator BodyAnimator;

  [SerializeField]
  private tk2dSpriteAnimator GunAnimator;

  [SerializeField]
  private tk2dSpriteAnimator SwordAnimator;

  [SerializeField]
  private tk2dSpriteAnimator LeftLegAnimator;

  [SerializeField]
  private tk2dSpriteAnimator RightLegAnimator;

	// Use this for initialization
	void Start ()
  {

	}

  // Update is called once per frame
  void Update()
  {

  }
}
