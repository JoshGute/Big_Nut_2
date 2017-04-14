using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOtherLevel : MonoBehaviour {

	[SerializeField]
	public string level;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene (level);
	}
}
