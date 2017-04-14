using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUIAnimManager : MonoBehaviour {

  [SerializeField]
  private GameObject Bot;

  //The number of dashes this bot has
  [SerializeField]
  private int DashAmount;

  //DashObjects
  [SerializeField]
  private GameObject Dash1;
  [SerializeField]
  private GameObject Dash2;
  [SerializeField]
  private GameObject Dash3;
  [SerializeField]
  private GameObject Dash4;

	// Use this for initialization
	void Start ()
  {
    DashAmount = Bot.GetComponent<PlayerControllerVer2>().maxDashes;
    ShowAppropriateDashAmount();

    Dash1.GetComponent<tk2dSpriteAnimator>().AnimationEventTriggered = UpdateAnimWaitState;
    Dash2.GetComponent<tk2dSpriteAnimator>().AnimationEventTriggered = UpdateAnimWaitState;
    Dash3.GetComponent<tk2dSpriteAnimator>().AnimationEventTriggered = UpdateAnimWaitState;
    Dash4.GetComponent<tk2dSpriteAnimator>().AnimationEventTriggered = UpdateAnimWaitState;
  }

  /*The maximum number of Dash objects are active by default. 
  We deactivate at the start to show only the appropriate number of dashes.*/
  void ShowAppropriateDashAmount()
  {
    if(DashAmount == 1)
    {
      Dash2.SetActive(false);
      Dash2.GetComponent<MeshRenderer>().enabled = false;
      Dash3.SetActive(false);
      Dash3.GetComponent<MeshRenderer>().enabled = false;
      Dash4.SetActive(false);
      Dash4.GetComponent<MeshRenderer>().enabled = false;
    }
    else if(DashAmount == 2)
    {
      Dash3.SetActive(false);
      Dash3.GetComponent<MeshRenderer>().enabled = false;
      Dash4.SetActive(false);
      Dash4.GetComponent<MeshRenderer>().enabled = false;
    }
    else if(DashAmount == 3)
    {
      Dash4.SetActive(false);
      Dash4.GetComponent<MeshRenderer>().enabled = false;
    }
  }

  private void UpdateAnimWaitState(tk2dSpriteAnimator Animator, tk2dSpriteAnimationClip clip, int frameNo)
  {
    if(clip.name == "DashArrow_EmptytoFull")
    {
      Animator.Play("DashArrow_Full");
    }
    else if(clip.name == "DashArrow_FulltoEmpty")
    {
      Animator.Play("DashArrow_Empty");
    }
  }

  //Using up a Dash
  public void PlayEmptyAnim(int curDashes)
  {
    //If the number of dashes is at x and we're about to dash...
    if(curDashes == 4)
    {
      Dash4.GetComponent<tk2dSpriteAnimator>().Play("DashArrow_FulltoEmpty");
    }
    else if(curDashes == 3)
    {
      Dash3.GetComponent<tk2dSpriteAnimator>().Play("DashArrow_FulltoEmpty");
    }
    else if(curDashes == 2)
    {
      Dash2.GetComponent<tk2dSpriteAnimator>().Play("DashArrow_FulltoEmpty");
    }
    else if(curDashes == 1)
    {
      Dash1.GetComponent<tk2dSpriteAnimator>().Play("DashArrow_FulltoEmpty");
    }
    else if(curDashes == 0)
    {
      return;
    }
  }

  //Regaining a Dash
  public void PlayFullAnim(int curDashes)
  {
    if(curDashes == 0)
    {
      Dash1.GetComponent<tk2dSpriteAnimator>().Play("DashArrow_EmptytoFull");
    }
    else if (curDashes == 1)
    {
      Dash2.GetComponent<tk2dSpriteAnimator>().Play("DashArrow_EmptytoFull");
    }
    else if (curDashes == 2)
    {
      Dash3.GetComponent<tk2dSpriteAnimator>().Play("DashArrow_EmptytoFull");
    }
    //This shouldn't ever be called
    else if (curDashes == 3)
    {
      Dash4.GetComponent<tk2dSpriteAnimator>().Play("DashArrow_EmptytoFull");
    }

    //This shouldn't ever be called
    else if (curDashes == 4)
    {
      print("If this is called something is wrong.");
      return;
    }
  }

	// Update is called once per frame
	void Update ()
  {
	}
}
