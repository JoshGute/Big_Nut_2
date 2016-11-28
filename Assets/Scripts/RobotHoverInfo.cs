using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*this script will handle all the info each robot contains
 * the RobotSelectionLogic talks to this, then this talks to the actual changing UI */
public class RobotHoverInfo : MonoBehaviour
{
    public bool isSelectable;
    // Use this for initialization
    void Start ()
    {
        isSelectable = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
    }

    public void OnHover()
    {
        
    }
}
