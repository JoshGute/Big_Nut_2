using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitLogic : MonoBehaviour
{
    public Canvas QuitCanvas;

    private bool QuitOpen;

	// Use this for initialization
	void Start ()
    {
        QuitOpen = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void QuitMenu()
    {
        if(QuitOpen == false)
        {
            QuitCanvas.enabled = true;
            QuitOpen = true;
        }
    }

    public void Deny()
    {
        QuitCanvas.enabled = false;
        QuitOpen = false;
    }

    public void Confirm()
    {
        Application.Quit();
    }
}
