using UnityEngine;
using System.Collections;

public class DamageDebuff : MonoBehaviour {

	public void Execute (int damage) {
		GetComponent<EnemyStats> ().Health -= damage;
		Debug.Log ("DAÑO REALIZADO");
		Destroy (this);
	}
}
