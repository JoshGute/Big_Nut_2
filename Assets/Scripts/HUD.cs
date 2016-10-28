using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public TeamManager PlayerOne;
    public TeamManager PlayerTwo;

    public GameObject P1robs;
    public GameObject P2robs;

    public GameObject P1hp;
    public GameObject P2hp;

    public Text WinText;

    public Button RestartButton;

    void OnEnable()
    {
        BodyScript.Die += UpdateBotsLeft;
        TeamManager.Victory += UpdateWinner;
    }

    void OnDisable()
    {
        BodyScript.Die -= UpdateBotsLeft;
        TeamManager.Victory -= UpdateWinner;
    }
    // Use this for initialization
    void Start ()
    {
        WinText.text = "";
        P1robs.GetComponent<Text>().text = PlayerOne.gTeam.Length.ToString();
        P2robs.GetComponent<Text>().text = PlayerTwo.gTeam.Length.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        P1hp.GetComponent<Text>().text = PlayerOne.pOwner.bBody.fLifetime.ToString();
        P2hp.GetComponent<Text>().text = PlayerTwo.pOwner.bBody.fLifetime.ToString();
    }

    void UpdateBotsLeft(string inOwner)
    {
        if(inOwner == "Player1")
        {
            int newdeaths = PlayerOne.gTeam.Length - PlayerOne.iDeaths;
            P1robs.GetComponent<Text>().text = newdeaths.ToString();
        }

        else if (inOwner == "Player2")
        {
            int newdeaths2 = PlayerTwo.gTeam.Length - PlayerTwo.iDeaths;
            P2robs.GetComponent<Text>().text = newdeaths2.ToString();
        }
    }

    void UpdateWinner(string inWinner)
    {
        if (inWinner == "Player1")
        {
            WinText.text = "Player 1 Wins!";
        }

        else if (inWinner == "Player2")
        {
            WinText.text = "Player 2 Wins!";
        }

        RestartButton.gameObject.SetActive(true);
    }
}
