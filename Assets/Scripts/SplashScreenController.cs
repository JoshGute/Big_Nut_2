using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplashScreenController : MonoBehaviour {

	[SerializeField]
	private Animator DigipenSplashScreenAnimator;
	[SerializeField]
	private Animator TeamSplashScreenAnimator;
	[SerializeField]
	private Animator GameSplashScreenAnimator;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (ActivateAnimation ());
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator ActivateAnimation()
	{
		DigipenSplashScreenAnimator.SetBool ("Activate", true);

		yield return new WaitForSeconds (5f);

		DigipenSplashScreenAnimator.SetBool ("Activate", false);

		yield return new WaitForSeconds (1f);

		TeamSplashScreenAnimator.SetBool ("Activate", true);

		yield return new WaitForSeconds (5f);

		TeamSplashScreenAnimator.SetBool ("Activate", false);

		yield return new WaitForSeconds (1f);

		GameSplashScreenAnimator.SetBool ("Activate", true);

		yield return new WaitForSeconds (5f);

		GameSplashScreenAnimator.SetBool ("Activate", false);

		yield return new WaitForSeconds (1f);
	}
}
