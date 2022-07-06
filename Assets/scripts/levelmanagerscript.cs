using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmanagerscript : MonoBehaviour {

	public void LoadScene(string name)
	{
		//hit_script.breakableCount = 0;
		Debug.Log ("scene is loaded" + name);
		SceneManager.LoadScene (name);	
	}
	public void quitrequest(){
		Application.Quit ();
	}
}

