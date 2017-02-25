using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{

    public int Player1Robot;
    public int Player2Robot;

    private void Start()
    {
        Player1Robot = 0;
        Player2Robot = 0;
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    } 
}
