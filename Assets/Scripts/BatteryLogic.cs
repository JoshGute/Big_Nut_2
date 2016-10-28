using UnityEngine;
using System.Collections;

public class BatteryLogic : MonoBehaviour
{

    public float BatteryLife;

	// Use this for initialization
	void Start ()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.green);
	}
	
	// Update is called once per frame
	void Update ()
    {
        BatteryLife -= Time.deltaTime;
        Renderer rend = GetComponent<Renderer>();

        if (BatteryLife <= 40)
        {
            rend.material.SetColor("_Color", Color.yellow);
        }

        if (BatteryLife <= 20)
        {
            rend.material.SetColor("_Color", Color.red);
        } 

    }
}
