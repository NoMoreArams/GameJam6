using UnityEngine;
using System.Collections;

public class DamageDebuff : MonoBehaviour {
	
	public int damage = 10;
	
	public void Start () {
		// BAJAR LA VELOCIDAD
		Debug.Log ("DAÑO REALIZADO");
		Destroy (this);
	}
}
