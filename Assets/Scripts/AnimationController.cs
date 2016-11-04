using UnityEngine;
using System.Collections;

//*State Machine Enums*//
//Called 'custom' animation state because unity already has an animation state class. 
public class CustomAnimationStates
{
  public enum AnimState { Idle, Run, Shoot, Stab, Jump };
}

/*Much of this code taken from a 2d toolkit website tutorial and expanded upon.*/
public class AnimationController : MonoBehaviour {

  //*References to the animator components of each body part.*//
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

  private bool isMoving;

	// Use this for initialization
	void Start ()
  {
    //CustomAnimationStates.AnimState currAnimState;
    //currAnimState = CustomAnimationStates.AnimState.Idle;
	}

  // Update is called once per frame
  public void changeAnimation(int iInput_)
  {
        switch (iInput_)
        {
            case 1:
                {
                    UpdateAnimState(CustomAnimationStates.AnimState.Run);
                    break;
                }
            case 2:
                {
                    UpdateAnimState(CustomAnimationStates.AnimState.Idle);
                    break;
                }
            case 3:
                {
                    UpdateAnimState(CustomAnimationStates.AnimState.Shoot);
                    break;
                }
        }
  }

  void PreviousAnimDelegate(tk2dSpriteAnimator sprite, tk2dSpriteAnimationClip clip)
  {
    if(isMoving)
    {
      GunAnimator.Play("Gun_Move");
    }
    else
    {
      GunAnimator.Play("Gun_Idle");
    }

  }

  void UpdateAnimState(CustomAnimationStates.AnimState newAnimState)
  {
    switch (newAnimState)
    {
      case CustomAnimationStates.AnimState.Idle:
        LeftLegAnimator.Play("LeftLeg_Idle");
        RightLegAnimator.Play("RightLeg_Idle");
        BodyAnimator.Play("Body_Idle");
        HeadAnimator.Play("Head_Idle");
        GunAnimator.Play("Gun_Idle");
        break;

      case CustomAnimationStates.AnimState.Jump:

        break;

      case CustomAnimationStates.AnimState.Run:
        LeftLegAnimator.Play("LeftLeg_Run");
        RightLegAnimator.Play("RightLeg_Run");
        BodyAnimator.Play("Body_Move");
        HeadAnimator.Play("Head_Move");
        GunAnimator.Play("Gun_Move");
        break;

      case CustomAnimationStates.AnimState.Shoot:
        GunAnimator.Play("Gun_Shoot");

        GunAnimator.AnimationCompleted = PreviousAnimDelegate;

        break;

      case CustomAnimationStates.AnimState.Stab:

        break;

      default:
        break;
    }
  }
}
