using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyWorkingScript : MonoBehaviour {
	
	public GameObject laserbean;

	public float health = 150f;
	public float laserSpeed= 5.0f;
	public float shootPerSecond = 0.5f;
	public int ScoreValue = 100;
	private int counter = 0; 
	private static int tmp = 0;

	private scoreScript score;
 
	void Start(){
		score = GameObject.Find ("Text").GetComponent<scoreScript> ();


	}



	void Update(){
		float probability = Time.deltaTime * shootPerSecond;
		if (Random.value < probability) {
			shoot ();
		}
	}


	void shoot(){
		Vector3 startPosition =  transform.position + new Vector3 (0, -1, 0);
		Debug.Log (startPosition);
		GameObject missile = Instantiate (laserbean, startPosition, Quaternion.identity);
		missile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -laserSpeed);
		//missile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -laserSpeed);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{

		PlayerLaserscript laser = collider.gameObject.GetComponent<PlayerLaserscript> ();
		if (laser) {
			health -= laser.GetDamage ();
			laser.hit ();
			if (health <= 0) 
			{
				Destroy (gameObject);
				score.CalculateScore (ScoreValue);
				counter++;
				tmp = tmp + counter;
				print (tmp);
				if (tmp == 5) {
					SceneManager.LoadScene("win scene");
					tmp = 0;
				}
		}
	
	
		}
	}
}
