using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentModifier : MonoBehaviour
{
    public float fSpeedModifier = 0.5f;

    void OnTriggerStay(Collider trigger)
    {
        if (trigger.tag == "Player1" || trigger.tag == "Player2")
        {
            trigger.GetComponent<Rigidbody>().velocity = trigger.GetComponent<Rigidbody>().velocity * fSpeedModifier;
        }
    }
}
