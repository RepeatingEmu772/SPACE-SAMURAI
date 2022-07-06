using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyship_script : MonoBehaviour {
	public GameObject enemyprefab;
	public float width=10f;
	public float height=5f;
	public float speed = 5f;


	private bool moveRight = true;
	private float xmax;
	private float xmin;




	// Use this for initialization
	void Start () 
	{                
		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		//print ("camera Distance = " + cameraDistance);
		Vector3 leftPosition = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, cameraDistance));
		Vector3 rightPosition = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, cameraDistance));
		xmax = rightPosition.x;
		//print ("xmax = "+ xmax);
		xmin = leftPosition.x;
		//print ("xmin = "+xmin);

		foreach( Transform child in transform){
			GameObject enemy =   Instantiate (enemyprefab,child.transform.position,Quaternion.identity);
			enemy.transform.parent = child;
	}
	}
	public void drawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update () {
		if (moveRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} 
		else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		
		}

		float rightMove = transform.position.x + (0.5f * width);
		float leftMove = transform.position.x - (0.5f * width);

		if (leftMove < xmin || rightMove > xmax) {
		
			moveRight = !moveRight;
			}
			
	}

}

