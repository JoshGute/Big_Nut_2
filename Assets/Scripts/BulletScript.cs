using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public float MaxDistance;
    //Change the y value only. 1.0 = 90 degress facing top of screen.
    public Vector3 Direction = new Vector3(0,0,0);
    private Vector3 StartPos;

    public string sOwner;
    public float fSpeed = 10.0f;
    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        print(transform.forward);
        rb = GetComponent<Rigidbody>();
        if(Direction.y == 0)
        {
            Direction = transform.forward;
        }
        StartPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.AddForce(Direction * fSpeed);

        if (Vector3.Distance(transform.position, StartPos) >= MaxDistance)
        {
            Destroy(gameObject);
        }
    }
}
