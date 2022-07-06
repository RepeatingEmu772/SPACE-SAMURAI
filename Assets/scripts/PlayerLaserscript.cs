using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserscript : MonoBehaviour {

	public float damage=100f;

	public float GetDamage(){
		return damage;
	}
	public void hit(){
		Destroy (gameObject);
	}

}
