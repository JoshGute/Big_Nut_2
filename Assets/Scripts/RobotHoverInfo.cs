using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RobotHoverInfo : MonoBehaviour
{

    public GameObject[] Player1Team;
    public GameObject[] Player2Team;

    public GameObject leftRobotImage;
    public GameObject rightRobotImage;

    public Sprite TestRobot;

    public Image[] images;

    // Use this for initialization
    void Start ()
    {
        leftRobotImage = GameObject.Find("Player1SelectedRobot");
        rightRobotImage = GameObject.Find("Player2SelectedRobot");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(EventSystem.current.currentSelectedGameObject.name == "TopLeft")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.red;
           //GameObject.Find("Player1SelectedRobot").GetComponent<Image>().sprite = TestRobot;
           //leftRobotImage.GetComponent<Image>().sprite = TestRobot;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "TopRight")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.green;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "2Left")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.blue;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "2Right")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.yellow;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "3Left")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.cyan;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "3Right")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.magenta;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "BottomLeft")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.white;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "BottomRight")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.grey;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Team1-1")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.black;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Team1-2")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.black;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Team1-3")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.black;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Team2-1")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.black;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Team2-2")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.black;
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Team2-3")
        {
            GameObject.Find("Player1SelectedRobot").GetComponent<Image>().color = Color.black;
        }
    }

    public void OnHover()
    {
        
    }
}
