using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHider : MonoBehaviour {

    public MeshRenderer ObjectToReveal;
    private bool RevealObject = false;
    private Vector4 MaterialColor;

	// Use this for initialization
	void Start () 
    {
        MaterialColor = ObjectToReveal.material.color;	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (RevealObject == false)
        {
            //print("1 " + RevealObject);
            ObjectToReveal.material.color = new Vector4(MaterialColor.x, MaterialColor.y, MaterialColor.z, 0);
        }	

        if (RevealObject)
        {
            //print("2 " + RevealObject);
            ObjectToReveal.material.color = new Vector4(MaterialColor.x, MaterialColor.y, MaterialColor.z, ObjectToReveal.material.color.a + 0.05f);
        }

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<PlayerControllerVer2>())
        {
            RevealObject = true;
        }       
    }

    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<PlayerControllerVer2>())
        {
            RevealObject = false;
        }
    }
}
