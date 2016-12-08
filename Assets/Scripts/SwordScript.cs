/*******************************  SpaceTube  *********************************
Author: Linus Chan
Contributors: --
Course: GAM400
Game:   Big Nut
Date:   12/7/2016
File:   SwordScript.cs

Description:


Current Problems:


Copyright (C) 2016 DigiPen Institute of Technology.
Reproduction or disclosure of this file or its contents without the prior
written consent of DigiPen Institute of Technology is prohibited.
******************************************************************************/
using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour
{
  //DEPRECATED
  /*
  //How fast we want the hitbox to move to the final position. (IT WILL BE LOWER THAN 1 MOST LIKELY. 0.1-0.5 seems like a good range from slow to fast)
  [SerializeField]
  private float AttackSpeed;
  [SerializeField]
  //How fast we want the attack to return to rest position. Same as AttackSpeed. 
  private float ReturnSpeed;
  //Shrug???? See Vector3.Lerp in Unity Doc. Maybe there's an alternative to this.
  private float startTime;
  //Distance between resting and final position of attack hitbox
  private float journeyLength;
  */
  /*
  //Final position of hitbox when attacking. Made serializable so we can easily change it in-editor. 
  [SerializeField]
  private Vector3 FinalPosition;
  //Beginning position of hitbox
  private Vector3 RestingPosition;
  */

  //Damage dealt by weapon.
  [SerializeField]
  private float fDamage;

  public float Damage
  {
    get
    {
      return fDamage;
    }
  }

  //The time in seconds for Cooldown after attacking.
  [SerializeField]
  private float CooldownTime;

  //The time left on Cooldown;
  private float timeleft;
  //Flag for when cooldown is on/off
  private bool CooldownOff;

  //WeaponHitBoxes might change in size so made the object changeable in-editor.
  [SerializeField]
  private GameObject WeaponHitBox;

  //Movement of WeaponHitBox during the attack. 
  [SerializeField]
  public AnimationCurve attackCurve;

  //Sword is attacking
  private bool isStabbing = false;

  //Sword is done attacking, returning to rest position
  private bool isReturning = false;

  //Owner of this weapon
  public string sOwner;

  void Start()
  {
    timeleft = CooldownTime;
    CooldownOff = true;

    WeaponHitBox.GetComponent<Collider>().enabled = false;

    //DEPRECATED
    /*
    RestingPosition = WeaponHitBox.transform.localPosition;
    startTime = Time.time;
    journeyLength = Vector3.Distance(RestingPosition, FinalPosition);
    */
  }

  void Update()
  {
    //Input testing code!!!!!!!!!!!!//
    if (Input.GetKeyDown(KeyCode.Z) && CooldownOff == true)
    {
      StartCoroutine(Stab());

      CooldownOff = false;
    }

    if (CooldownOff == false)
    {
      StartCoroutine(CoolDownTimer());
    }

    //DEPRECATED
    /*
    if(isStabbing == true)
    {
      StartCoroutine(DoStab());
    }

    else if(isReturning == true)
    {
      StartCoroutine(Return());
    }
    */
  }

  public IEnumerator CoolDownTimer()
  {
    timeleft -= Time.deltaTime;

    if (timeleft <= 0)
    {
      timeleft = CooldownTime;
      CooldownOff = true;
    }

    yield return null;
  }

  public IEnumerator Stab()
  {
    float timer = 0.0f;

    WeaponHitBox.GetComponent<Collider>().enabled = true;

    while (timer < attackCurve.keys[attackCurve.keys.Length - 1].time)
    {
      timer += Time.deltaTime;

      WeaponHitBox.transform.localPosition = new Vector3(WeaponHitBox.transform.localPosition.x, WeaponHitBox.transform.localPosition.y, attackCurve.Evaluate(timer));

      if (timer >= attackCurve.keys[attackCurve.keys.Length - 1].time)
      {
        WeaponHitBox.GetComponent<Collider>().enabled = false;
      }

      yield return null;
    }
  }

  //SUPER DEPRECATED
  /*
  public IEnumerator DoStab()
  {
    isStabbing = true;
    isReturning = false;

    float distCovered = 0;
    float fracJourney = 0;

    distCovered = (Time.time - startTime) * AttackSpeed;
    fracJourney = distCovered / journeyLength;

    WeaponHitBox.transform.localPosition = Vector3.Lerp(WeaponHitBox.transform.localPosition, FinalPosition, fracJourney);
    
    //Checking to see if the weapon has reached the destination.
    if (Mathf.Round(fracJourney) == 1)
    {
      WeaponHitBox.transform.localPosition = FinalPosition;

      print(distCovered + " distCovered");
      print(fracJourney + " fracJourney");
      print(journeyLength + " journeyLength");

      distCovered = 0;
      fracJourney = 0;

      startTime = Time.time;
            
      isStabbing = false;
      isReturning = true;
    }

    yield return null;
  }

  public IEnumerator Return()
  {
    float distCovered = 0;
    float fracJourney = 0;

    distCovered = (Time.time - startTime) * ReturnSpeed * 100;
    fracJourney = distCovered / journeyLength;

    WeaponHitBox.transform.localPosition = Vector3.Lerp(WeaponHitBox.transform.localPosition, RestingPosition, fracJourney);

    //Checking to see if the weapon has reached the destination.
    if (Mathf.RoundToInt(fracJourney) >= 1)
    {
      print("yo");
      WeaponHitBox.transform.localPosition = RestingPosition;

      distCovered = 0;
      fracJourney = 0;

      isReturning = false;
    }

    yield return null;
  }

  public void Stab()
  {
    //If already stabbing, disregard.
    if(isStabbing == true)
    {
      return;
    }

    else if(isStabbing == false)
    {
      isStabbing = true;
    }
  }
  */

}
