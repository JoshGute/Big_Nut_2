using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndicator : MonoBehaviour {

  public Color Player1Color;
  public Color Player2Color;

  //Which player to display?
  private string PlayertoDisplay;

  //Which player are we following?
  private GameObject Player;

  public Vector3 OffsetPosFromPlayer;

	// Use this for initialization
	void Start ()
  {
		
	}
	
  //Update which sprite to display based on what player this is for.
  void UpdateSprite ()
  {
    if(PlayertoDisplay == "Player1")
    {
      gameObject.GetComponent<tk2dSprite>().SetSprite("PlayerNumber_1");
      gameObject.GetComponent<tk2dSprite>().color = Player1Color;
    }
    else if(PlayertoDisplay == "Player2")
    {
      gameObject.GetComponent<tk2dSprite>().SetSprite("PlayerNumber_2");
      gameObject.GetComponent<tk2dSprite>().color = Player2Color;
    }
  }

	// Update is called once per frame
	void Update ()
  {
    gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 30, Player.transform.position.z);
	}
}
