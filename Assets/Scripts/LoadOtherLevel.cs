using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOtherLevel : MonoBehaviour {

	[SerializeField]
	private string level;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void LoadLevel()
	{
		SceneManager.LoadScene (level);
	}
}
