using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BodyScript : MonoBehaviour
{
    public string sOwner;
    public GameObject gSkin;
    public GameObject gOilSpring;
    public Rigidbody rb;
    public float fLifetime;

    public bool bGrounded;
    public int iMaxJumps;
    public int iJumps;
    public float fMoveSpeed;
    public float fJumpSpeed;
    public float fDashTime; 

    public AudioClip acHitNoise;

    private AudioSource asNoiseMaker;
   

    public delegate void DeathAction(string sOwner_);
    public static event DeathAction Die;

    void Start ()
    {
        asNoiseMaker = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        InvokeRepeating("updateLifeTime", 0, 1);

    }
	
    public void updateLifeTime()
    {
      if (fLifetime > 0)
      {
          --fLifetime;         
      }
      else if (fLifetime <= 0)
      {
          
          Explode();
          CancelInvoke();
      }
    }

    public void Explode()
    {
        GameObject gOilSpring_ = Instantiate(gOilSpring.gameObject, transform.position + gOilSpring.transform.position, gOilSpring.transform.rotation) as GameObject;
        gOilSpring_.transform.parent = gSkin.transform; 

        if (gSkin)
        {
            print("skin detected");
            foreach (Transform child in gSkin.transform)
            {
                if (child.GetComponent<Rigidbody>())
                {
                    child.GetComponent<BoxCollider>().enabled = true;
                    child.GetComponent<Rigidbody>().useGravity = true;
                    child.GetComponent<Rigidbody>().isKinematic = false;
                    child.GetComponent<Rigidbody>().AddExplosionForce(10.0f, child.transform.position, 2.0f);
                    child.gameObject.layer = 11;
                }
                if (child.GetComponent<tk2dSprite>())
                {
                    child.GetComponent<tk2dSprite>().color = Color.white;
                }
            }
            gSkin.transform.DetachChildren();
            Die(sOwner);
            Destroy(gameObject);
        }

        else
        {
            print("no skin here");
            foreach (Transform child in transform)
            {
                if (child.GetComponent<Rigidbody>())
                {
                    child.GetComponent<Rigidbody>().useGravity = true;
                    child.GetComponent<Rigidbody>().isKinematic = false;
                    child.GetComponent<Rigidbody>().useGravity = true;
                    child.GetComponent<Rigidbody>().AddExplosionForce(10.0f, child.transform.position, 2.0f);
                    child.gameObject.layer = 11;
                }
            }
            transform.DetachChildren();
            rb.AddExplosionForce(5.0f, transform.position, 2.0f);
            Die(sOwner);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            iJumps = iMaxJumps;
            bGrounded = true;
        }

        if (collision.gameObject.tag == "Bullet" && collision.gameObject.GetComponent<BulletScript>().sOwner != sOwner)
        {
            TakeDamage(collision.gameObject.GetComponent<BulletScript>().Damage);

            updateLifeTime();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            bGrounded = false;   
        }
    }

    //HAHAHAHAHAHAHA THIS IS THE 3RD TIME I'VE WRITTEN THIS FUNCTION. AHAHAHAHAHAHAHAHAHA - Linus
    void TakeDamage(float damage)
    {
        asNoiseMaker.PlayOneShot(acHitNoise);
        fLifetime -= damage;

        foreach (Transform child in gSkin.transform)
        {
            if (child.GetComponent<tk2dSprite>())
            {
                StartCoroutine(Flash(child.GetComponent<tk2dSprite>()));

            }
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
      //Being hit by Bullet
        if (trigger.gameObject.tag == "Bullet" && trigger.gameObject.GetComponent<BulletScript>().sOwner != sOwner)
        {
            TakeDamage(trigger.gameObject.GetComponent<BulletScript>().Damage);
        }

      //Being hit by a Sword
      //(trigger is the hitbox attached to sword in this case. the info is in the sword arm parent so that's why do getcomponentinparent)
        else if(trigger.gameObject.tag == "Sword" && trigger.gameObject.GetComponentInParent<SwordScript>().sOwner != sOwner)
        {
            TakeDamage(trigger.gameObject.GetComponentInParent<SwordScript>().Damage);
            rb.velocity = (trigger.transform.forward * trigger.gameObject.GetComponentInParent<SwordScript>().Damage * 2);
        }

    }

    private IEnumerator Flash(tk2dSprite SkinPart_)
    {
        SkinPart_.color = Color.black;
        yield return new WaitForSeconds(.05f);
        SkinPart_.color = Color.white;
    }
}
