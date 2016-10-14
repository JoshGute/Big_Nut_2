using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour
{
    public bool bIsSafe = true;

    void OnTriggerEnter(Collider Coll)
    {
        if(Coll.gameObject.layer == 10)
        {
            //print("sawn unsafe");
            bIsSafe = false;
        }
    }

    void OnTriggerExit(Collider Coll)
    {
        if (Coll.gameObject.layer == 10)
        {
            //print("sawn safe");
            bIsSafe = true;
        }
    }

}
