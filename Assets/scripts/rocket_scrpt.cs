using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket_scrpt : MonoBehaviour {
	public float speed = 5.0f;
	public GameObject bult;
	public GameObject missile;
	public float health = 300f;
	static AudioSource gunshot;
	// Use this for initialization
	void Start () {
		
	}
	void attack(){
		GameObject bulletbeam = Instantiate (bult, transform.position, Quaternion.identity) as GameObject;
		bulletbeam.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 10f, 0f);

	}
	void missile_attack(){
		GameObject bulletbeam = Instantiate (missile, transform.position, Quaternion.identity) as GameObject;
		bulletbeam.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 10f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M) ){
			InvokeRepeating ("attack", 0.1f,0.2f);
			gunshot = GetComponent<AudioSource> ();
			gunshot.Play ();

		}

		else if(Input.GetKeyUp(KeyCode.M) ){ 
			CancelInvoke();
		}

		if(Input.GetKeyDown(KeyCode.N)){
			InvokeRepeating ("missile_attack", 0.1f, 0.2f);
			gunshot = GetComponent<AudioSource> ();
			gunshot.Play ();

		} else if (Input.GetKeyUp(KeyCode.N)) {
			CancelInvoke ();
		}


		if (Input.GetKey (KeyCode.A)) {
			Vector3 position = new Vector3 (0f, this.transform.position.y, 0f);
			transform.position += new Vector3 (-speed * Time.deltaTime, 0f, 0f);
		} else if (Input.GetKey (KeyCode.D)) {

			Vector3 position = new Vector3 (0f, this.transform.position.y, 0f);
			transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
		float restrictPosition = Mathf.Clamp (transform.position.x, -8.5f, 8.5f);
		transform.position = new Vector3 (restrictPosition, transform.position.y, transform.position.z);

	}
	
	//update ends
	void OnTriggerEnter2D (Collider2D collider)
	{

		PlayerLaserscript laser = collider.gameObject.GetComponent<PlayerLaserscript> ();
		if (laser) {
			health -= laser.GetDamage ();
			laser.hit ();
			if (health <= 0) {
				Destroy (gameObject);
				SceneManager.LoadScene("loose scene");
			}
		}
	}
	}


