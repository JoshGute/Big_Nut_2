using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplashScreenController : MonoBehaviour
{
    public Button startingButton;

	[SerializeField]
	private Animator DigipenSplashScreenAnimator;
	[SerializeField]
	private Animator TeamSplashScreenAnimator;
	[SerializeField]
	private Animator GameSplashScreenAnimator;
	[SerializeField]
	private Animator ControllerSplashScreenAnimator;

	[SerializeField]
	private Transform TeamSplashScreen;
	[SerializeField]
	private Transform ControllerSplashScreen;
	[SerializeField]
	private Transform DigipenSplashScreen;
	[SerializeField]
	private Transform GameSplashScreen;

	[SerializeField]
	private Animator StartButtonAnimator;
    [SerializeField]
    private Animator HTPButtonAnimator;
    [SerializeField]
    private Animator CreditsButtonAnimator;
    [SerializeField]
    private Animator QuitButtonAnimator;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("ActivateAnimation");
	}
	
	// Update is called once per frame
	void Update () 
	{
        //Interrupting the splash screens
        if (Input.anyKeyDown || Input.GetButtonDown("Submit"))
		{
            startingButton.Select();
			//Hiding unnecessary screens
			DigipenSplashScreenAnimator.enabled = false;
			TeamSplashScreenAnimator.enabled = false;
			ControllerSplashScreenAnimator.enabled = false;

			TeamSplashScreen.GetComponent<Image> ().enabled = false;
			ControllerSplashScreen.GetComponent<Image> ().enabled = false;
			DigipenSplashScreen.GetComponent<Image> ().enabled = false;

			//Stopping the coroutine from continuing
			StopCoroutine ("ActivateAnimation");

			//Skipping to the start screen
			ShowStartScreen();
		}
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

		ControllerSplashScreenAnimator.SetBool ("Activate", true);

		yield return new WaitForSeconds (5f);

		ControllerSplashScreenAnimator.SetBool ("Activate", false);

		yield return new WaitForSeconds (1f);

        ShowStartScreen();
	}

	public void ShowStartScreen()
	{
        startingButton.Select();
        GameSplashScreenAnimator.SetBool("Activate", true);
		StartButtonAnimator.SetBool ("Activate", true);
        HTPButtonAnimator.SetBool("Activate", true);
        CreditsButtonAnimator.SetBool("Activate", true);
        QuitButtonAnimator.SetBool("Activate", true);
	}
}
