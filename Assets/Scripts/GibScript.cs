using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibScript : MonoBehaviour
{
    public GameObject[] Gibs;
    int randNum;

    public void SpawnGibs(int iHealth_)
    {
        for (int i = 0; i <= 6 -iHealth_; i++)
        {
            randNum = Random.Range(0, Gibs.Length);
            GameObject Gib = Instantiate(Gibs[randNum], new Vector3(transform.position.x + Random.insideUnitCircle.x, 
                transform.position.y + Random.insideUnitCircle.y, transform.position.z), Random.rotation) as GameObject;
            Gib.GetComponent<Rigidbody>().AddExplosionForce(5000, Gib.transform.position, 20.0f);
        }
    }
}
