using UnityEngine;
using System.Collections;

public class DamageDebuff : MonoBehaviour {

	public void Execute (int damage) {
		// BAJAR LA VELOCIDAD
		Debug.Log ("DAÑO REALIZADO");
		Destroy (this);
	}
}
