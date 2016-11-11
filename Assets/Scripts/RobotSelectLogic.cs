using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using XInputDotNetPure;

public class RobotSelectLogic : MonoBehaviour
{
    public Image Robot;
    public GameObject PlayerSelector;

    public int PlayerNumber;
    public Vector3 Position;

    private RectTransform SelectorTransform;

    private float KeyAxisH;
    private float KeyAxisV;

    private GamePadState State;

    private bool bController;

    public bool bDisabled;

    public string Horizontal = "Horizontal_P1";
    public string Vertical = "Vertical_P1";

    public PlayerIndex playerIndex;

    public float MoveTimer;
    private bool CanMove;

	// Use this for initialization
	void Start ()
    {
        SelectorTransform = GetComponent<RectTransform>();
        CanMove = true;
        MoveTimer = 10;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!bDisabled && CanMove == true)
        {
            State = GamePad.GetState(playerIndex);

            KeyAxisH = State.ThumbSticks.Left.X;
            KeyAxisV = State.ThumbSticks.Left.Y;

            if(KeyAxisH != 0)
            {
                CanMove = false;
                if (KeyAxisH > 0 && SelectorTransform.localPosition.x < 75)
                {
                    SelectorTransform.localPosition += new Vector3(125, 0, 0);
                }
                if (KeyAxisH < 0 && SelectorTransform.localPosition.x > -50)
                {
                    SelectorTransform.localPosition += new Vector3(-125, 0, 0);
                }

            }
            if(KeyAxisV != 0)
            {
                CanMove = false;
                if (KeyAxisV > 0 && SelectorTransform.localPosition.y < 170)
                {
                    SelectorTransform.localPosition += new Vector3(0, 115, 0);
                }
                if (KeyAxisV < 0 && SelectorTransform.localPosition.y > -170)
                {
                    SelectorTransform.localPosition += new Vector3(0, -115, 0);
                }
            }
            
         }
        if(CanMove == false)
        {
            --MoveTimer;
            if(MoveTimer <= 0)
            {
                MoveTimer = 10;
                CanMove = true;
            }
        }

        //keyboard controls left in for testing -- matty
        if (PlayerNumber == 1)
        {
            if(Input.GetKeyDown(KeyCode.W) && SelectorTransform.localPosition.y < 170)
            {
                SelectorTransform.localPosition += new Vector3(0, 115, 0);
            }
            if(Input.GetKeyDown(KeyCode.S) && SelectorTransform.localPosition.y > -170)
            {
                SelectorTransform.localPosition += new Vector3(0, -115, 0);
            }
            if (Input.GetKeyDown(KeyCode.D) && SelectorTransform.localPosition.x < 75)
            {
                SelectorTransform.localPosition += new Vector3(125, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.A) && SelectorTransform.localPosition.x > -50)
            {
                SelectorTransform.localPosition += new Vector3(-125, 0, 0);
            }

        }

        //keyboard controls left in for testing -- matty
        if (PlayerNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && SelectorTransform.localPosition.y < 170)
            {
                SelectorTransform.localPosition += new Vector3(0, 115, 0);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && SelectorTransform.localPosition.y > -170)
            {
                SelectorTransform.localPosition += new Vector3(0, -115, 0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && SelectorTransform.localPosition.x < 75)
            {
                SelectorTransform.localPosition += new Vector3(125, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && SelectorTransform.localPosition.x > -50)
            {
                SelectorTransform.localPosition += new Vector3(-125, 0, 0);
            }
        }

        //raycasting bois

        Vector3 backRay = transform.TransformDirection(Vector3.back);
        Debug.DrawRay(transform.position, backRay, Color.black);

        if(Physics.Raycast(transform.position, backRay,300))
        {
            Debug.Log("shits been hit yo");
        }
	}

    public void OnHover()
    {
        //raycasting shit o h  b o y




    }

    public void OnSelect()
    {

    }
}
