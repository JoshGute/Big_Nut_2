using UnityEngine;
using System.Collections;

public class RemakeScript : MonoBehaviour
{
    public void RebuildLevel(string sLevelToLoad)
    {
        Application.LoadLevel(sLevelToLoad);
    }
}
