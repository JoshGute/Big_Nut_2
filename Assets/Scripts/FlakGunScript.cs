using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakGunScript : MonoBehaviour {

    public float MaxDistance;
    //Change the y value only. 1.0 = 90 degress facing top of screen.
    public Vector3 Direction = new Vector3(0, 0, 0);
    private Vector3 StartPos;

    public string sOwner;
    public float fSpeed = 10.0f;
    private Rigidbody rb;

    public GameObject[] BulletsToSpawn;
    public float AnglePerBullet;

    [SerializeField]
    private float fDamage;

    public float Damage
    {
        get
        {
            return fDamage;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (Direction.y == 0)
        {
            Direction = transform.forward;
        }
        StartPos = transform.position;
    }

    void Update()
    {
        rb.velocity = Direction * fSpeed;

        if (Vector3.Distance(transform.position, StartPos) >= MaxDistance)
        {
            for (int j = 0; j < BulletsToSpawn.Length; j++)
            {
                GameObject newBullet;

                newBullet = Instantiate(BulletsToSpawn[j].gameObject, transform.position, transform.rotation) as GameObject;

                newBullet.GetComponent<BulletScript>().sOwner = sOwner;
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name != sOwner && trigger.gameObject.layer != 5)
        {
            Destroy(gameObject);
        }
    }
}

