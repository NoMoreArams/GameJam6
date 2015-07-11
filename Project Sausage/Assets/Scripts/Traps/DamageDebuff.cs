using UnityEngine;
using System.Collections;

public class DamageDebuff : MonoBehaviour {

	public void Execute (int damage) {
        GetComponent<EnemyStats>().ReceiveDamage(damage);
		Debug.Log ("DAÑO REALIZADO");
		Destroy (this);
	}
}
