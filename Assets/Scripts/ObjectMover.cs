using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour {

    public GameObject OldPoint;
    public GameObject NewPoint;
    public float Speed;
    public bool Loop;

    private float TotalDistance;
    private float StartTime;
    private bool Completed = false;

	// Use this for initialization
	void Start () 
    {
        StartTime = Time.time;
        TotalDistance = Vector3.Distance(OldPoint.transform.position, NewPoint.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Completed)
        {
            float DistanceCovered = (Time.time - StartTime) * Speed;

            float FractionJourney = DistanceCovered / TotalDistance;

            transform.position = Vector3.Lerp(OldPoint.transform.position,
                                               NewPoint.transform.position,
                                               FractionJourney);

            if (transform.position == NewPoint.transform.position && Loop)
            {
                Completed = false;
                StartTime = Time.time;
            }
        }

        else
        {
            float DistanceCovered = (Time.time - StartTime) * Speed;

            float FractionJourney = DistanceCovered / TotalDistance;

            transform.position = Vector3.Lerp(NewPoint.transform.position,
                                               OldPoint.transform.position,
                                               FractionJourney);

            if (transform.position == OldPoint.transform.position && Loop)
            {
                Completed = true;
                StartTime = Time.time;
            }
        }
	}
}
