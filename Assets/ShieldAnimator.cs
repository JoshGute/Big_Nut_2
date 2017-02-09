using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimator : MonoBehaviour {

  private ShieldScript shield;

  private Vector3 curShieldSize;

	// Use this for initialization
	void Start ()
  {
    curShieldSize = transform.localScale;
    shield = gameObject.GetComponent<ShieldScript>();
	}
	
  //Effects/change size for taking damage 
  void TakeDamageAnim()
  {
  }

  //Effects/change size for degrading shield
  void DegradeShieldAnim()
  {

  }

  //Effects/change size for regenerating shield
  void RegenShieldAnim()
  {

  }

  //
  public void UpdateShieldVisualState(float curShieldHealth)
  {
    float shieldhealthpercentage = curShieldHealth / shield.MaxShieldHealth;

    transform.localScale = new Vector3(shieldhealthpercentage * 10, shieldhealthpercentage * 10, 5);

    /*may or may not be used
    if(shieldhealthpercentage >= 0.66)
    {

    }

    else if(shieldhealthpercentage >= 0.33 && shieldhealthpercentage < 0.66)
    {

    }

    else if(shieldhealthpercentage >= 0 && shieldhealthpercentage < 0.33)
    {

    }
    */
  }

	// Update is called once per frame
	void Update ()
  {
	}
}
