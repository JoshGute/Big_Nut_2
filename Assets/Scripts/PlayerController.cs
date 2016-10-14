using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour
{
    public PlayerIndex playerIndex;

    private float KeyAxisH;
    private float KeyAxisV;

    public string Horizontal = "Horizontal_P1";
    public string Vertical = "Vertical_P1";
    public string Shoot = "Shoot_P1";
    public string Stab = "Stab_P1";
    public string Jump = "Jump_P1";

    public bool bDisabled = false;

    public BodyScript bBody;
    public GunScript gGun;
    public SwordScript sSword;

    private GamePadState state;
    private GamePadState prevState;

    private bool bController;


    void Start()
    {
        
    }
    void Update ()
    {
        if (!bDisabled)
        {
            GamePadState testState = GamePad.GetState(playerIndex);
            if (testState.IsConnected)
            {
                bController = true;
            }
            else if (!testState.IsConnected)
            {
                bController = false;
            }

            if(!bController)
            {
                KeyAxisH = Input.GetAxis(Horizontal);
                KeyAxisV = Input.GetAxis(Vertical);

                if (Input.GetButtonDown(Jump))
                {
                    inputManager(1);
                }
                if (Input.GetButtonDown(Shoot))
                {
                    inputManager(2);
                }
                if (Input.GetButtonDown(Stab))
                {
                    inputManager(3);
                }
            }

            else if(bController)
            {
                prevState = state;
                state = GamePad.GetState(playerIndex);
                KeyAxisH = state.ThumbSticks.Left.X;
                KeyAxisV = state.ThumbSticks.Left.Y;

                if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
                {
                    inputManager(1);
                }
                if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed)
                {
                    inputManager(2);
                }
                if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed)
                {
                    print("I wish God loved me enough to let me die");
                    inputManager(3);
                }
                if (prevState.Buttons.Back == ButtonState.Released && state.Buttons.Back == ButtonState.Pressed)
                {
                    inputManager(4);
                }
            }

            if (KeyAxisH != 0)
            { 
                if (KeyAxisH > 0)
                {
                    bBody.rb.velocity = new Vector3((KeyAxisH * bBody.fMoveSpeed * Time.deltaTime), bBody.rb.velocity.y, bBody.rb.velocity.z);
                    bBody.transform.localEulerAngles = new Vector3(bBody.transform.rotation.x, 90, bBody.transform.rotation.z);
                }
                else if (KeyAxisH < 0)
                {
                    bBody.rb.velocity = new Vector3((KeyAxisH * bBody.fMoveSpeed * Time.deltaTime), bBody.rb.velocity.y, bBody.rb.velocity.z);
                    bBody.transform.localEulerAngles = new Vector3(bBody.transform.rotation.x, -90, bBody.transform.rotation.z);
                }
            }


        }
    }

    private void inputManager(int iInput)
    {
        switch (iInput)
        {
            case 1:
                {
                    if(bBody.bGrounded)
                    {
                        //bBody.rb.AddForce(transform.up * bBody.fJumpSpeed);
                        bBody.rb.velocity = new Vector3(0, bBody.fJumpSpeed, 0);
                    }
                    else if(!bBody.bGrounded && bBody.iJumps > 0)
                    {
                        StartCoroutine(Dash(bBody.fDashTime));
                        //bBody.rb.AddForce(new Vector3(KeyAxisH, KeyAxisV, 0) * bBody.fJumpSpeed);
                        bBody.rb.velocity = new Vector3(KeyAxisH, KeyAxisV, 0) * bBody.fJumpSpeed;
                        --bBody.iJumps;
                    }
                    break;
                }
            case 2:
                {
                    gGun.Shoot();
                    break;
                }
            case 3:
                {
                    sSword.StartCoroutine("Stab");
                    break;
                }
            case 4:
                {
                    bBody.Explode();
                    //bDisabled = true;
                    break;
                }  
        }
    }

    public void TagRobot(GameObject gRobot_)
    {
        bDisabled = false;
        bBody = gRobot_.GetComponent<BodyScript>();
        gGun = gRobot_.GetComponentInChildren<GunScript>();
        sSword = gRobot_.GetComponentInChildren<SwordScript>();

        //this is super superfulous(fuck spelling lmao) and and probably be made into tags. 
        bBody.sOwner = tag;
        gGun.sOwner = tag;
        sSword.sOwner = tag;
        //like so
        bBody.tag = tag;
        gGun.tag = tag;
        sSword.tag = tag;
    }

    IEnumerator Dash(float dashTime)
    {
        bBody.rb.velocity = new Vector3(0, 0, 0);
        bBody.rb.useGravity = false;
        yield return new WaitForSeconds(dashTime);
        bBody.rb.useGravity = true;
    }
}
