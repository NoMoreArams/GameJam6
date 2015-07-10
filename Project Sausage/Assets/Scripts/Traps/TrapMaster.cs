using UnityEngine;
using System.Collections;

public class TrapMaster : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			Debug.Log("Enemigo Dañado");
		}
	}


}
