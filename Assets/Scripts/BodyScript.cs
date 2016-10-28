using UnityEngine;
using System.Collections;

public class BodyScript : MonoBehaviour
{
    public string sOwner;

    public Rigidbody rb;
    public float fLifetime;
	public float YellowLife;
	public float RedLife;

	public GameObject BatteryPack;

    public bool bGrounded;
    public int iMaxJumps;
    public int iJumps;
    public float fMoveSpeed;
    public float fJumpSpeed;
    public float fDashTime;

    public delegate void DeathAction(string sOwner_);
    public static event DeathAction Die;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        InvokeRepeating("updateLifeTime", 0, 1);

        Renderer batteryRender = BatteryPack.GetComponent<Renderer>();
        batteryRender.sharedMaterial.SetColor ("_Color", Color.green);
       // BatteryPack.GetComponent<Light>().color = Color.green;
    }
	
    public void updateLifeTime()
    {
		Renderer batteryRender = BatteryPack.GetComponent<Renderer>();

        if (fLifetime > 0)
        {
            --fLifetime;
        }
		if (fLifetime <= YellowLife) 
		{
            Debug.Log("YellowLife");
            batteryRender.sharedMaterial.SetColor ("_Color", Color.yellow);
            //BatteryPack.GetComponent<Light>().color = Color.yellow;
		}
		if (fLifetime <= RedLife)
		{
            batteryRender.sharedMaterial.SetColor ("_Color", Color.red);
            //BatteryPack.GetComponent<Light>().color = Color.red;
		}
        else if (fLifetime <= 0)
        {
            Explode();
            CancelInvoke();
        }
		Debug.Log (fLifetime);
    }

    public void Explode()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Rigidbody>().useGravity = true;
            child.GetComponent<Rigidbody>().isKinematic = false;
            child.GetComponent<Rigidbody>().AddExplosionForce(50.0f, child.transform.position, 30.0f);
            child.transform.rotation = Random.rotation;
        }
        rb.freezeRotation = false;
        transform.rotation = Random.rotation;
        transform.DetachChildren();
        rb.AddExplosionForce(300.0f, transform.position, 30.0f);
        Die(sOwner);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Ground")
        {
            iJumps = iMaxJumps;
            bGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            bGrounded = false;   
        }
    }
    //Deprecated. Use the new damage function linus wrote.
    /*void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Bullet" && trigger.gameObject.GetComponent<BulletScript>().sOwner != sOwner)
        {
            updateLifeTime();
        }
    }*/
}
