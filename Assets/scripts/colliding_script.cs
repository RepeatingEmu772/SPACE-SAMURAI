using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliding_script : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		DestroyObject (collider.gameObject);
		Debug.Log ("yo");
	}
}
