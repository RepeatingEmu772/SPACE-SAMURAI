using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_script : MonoBehaviour {

	public void drawGizmos (){
		Gizmos.DrawWireSphere (transform.position, 1);
	}
}
