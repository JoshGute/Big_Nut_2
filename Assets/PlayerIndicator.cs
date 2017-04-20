using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndicator : MonoBehaviour {

  public bool bTracking = false;
  public Color Player1Color;
  public Color Player2Color;

  //Which player to display?
  public string PlayertoDisplay;

  //Which player are we following?
  public GameObject Player;

  public Vector3 OffsetPosFromPlayer;

	// Use this for initialization
	void Start ()
  {
	}
	
  //Update which sprite to display based on what player this is for.
  public void UpdateSprite ()
  {
    if(PlayertoDisplay == "PLAYER1")
    {
      //gameObject.GetComponent<tk2dSprite>().SetSprite("Player_1");
      gameObject.GetComponent<tk2dSprite>().color = Player1Color;
            bTracking = true;
    }
    else if(PlayertoDisplay == "PLAYER2")
    {
      //gameObject.GetComponent<tk2dSprite>().SetSprite("Player_2");
      gameObject.GetComponent<tk2dSprite>().color = Player2Color;
            bTracking = true;
        }
  }

	// Update is called once per frame
	void Update ()
  {
        if(bTracking && Player != null)
        {
            gameObject.transform.position = new Vector3(Player.transform.position.x + OffsetPosFromPlayer.x,
                                                        Player.transform.position.y + OffsetPosFromPlayer.y, 
                                                        Player.transform.position.z + OffsetPosFromPlayer.z);
        }
        else if (bTracking && Player == null)
        {
            KillMe();
        }

	}

    public void KillMe()
    {
        Destroy(gameObject);
    }
}
