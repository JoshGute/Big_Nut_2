using UnityEngine;
using System.Collections;

public class ScaleOverTime : MonoBehaviour {

    private Vector3 StartingScale;
    public Vector3 MaxScale;
    public Vector3 ScalePerTick;
    public float fScaleRate;

    private float FTimertoNextScale;
    private bool ScaleMet = false;
    private Transform TargetToScale;

	// Use this for initialization
	void Start ()
    {
        TargetToScale = GetComponent<Transform>();
        StartingScale = TargetToScale.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(ScaleMet == false)
        {
            FTimertoNextScale += Time.deltaTime;

            if (FTimertoNextScale >= fScaleRate)
            {
                FTimertoNextScale = 0;
                //print("scale time");

                TargetToScale.localScale += ScalePerTick;

                if(TargetToScale.localScale.x >= MaxScale.x)
                {
                    ScaleMet = true;
                }

                /*
                if (TargetToScale.localScale.x <= MaxScale.x)
                {
                    TargetToScale.localScale.Set(TargetToScale.localScale.x + ScalePerTick.x, TargetToScale.localScale.y, TargetToScale.localScale.z);
                    print("scale x");
                }
                if (TargetToScale.localScale.y <= MaxScale.y)
                {
                    TargetToScale.localScale.Set(TargetToScale.localScale.x, TargetToScale.localScale.y + ScalePerTick.y, TargetToScale.localScale.z);
                    print("scale y");
                }
                if (TargetToScale.localScale.z <= MaxScale.z)
                {
                    TargetToScale.localScale.Set(TargetToScale.localScale.x, TargetToScale.localScale.y, TargetToScale.localScale.z + ScalePerTick.z);
                    print("scale z");
                }
                
                else
                {
                    ScaleMet = true;
                }*/
            }
        }
	}
}
