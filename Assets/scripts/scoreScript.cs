using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {


	public int score=0;
	private Text myText;

	void Start (){
		myText = GetComponent<Text> ();
		reset ();
	}


	public void CalculateScore(int points){
		score = score + points;
		myText.text = score.ToString ();
	}


	public void reset(){
		score = 0;
		myText.text = score.ToString ();
	}

}
