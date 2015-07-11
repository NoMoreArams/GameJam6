using UnityEngine;
using System.Collections;

public class HoneyDebuff : MonoBehaviour {

	public int slow  = 1;
	public float duration = 2f;

	public void Execute (int slow, float duration) {
		this.slow = slow;
		this.duration = duration;
		GetComponent<EnemyStats> ().Speed -= slow;
		GetComponent<MeshRenderer> ().material.color = Color.red;
		Debug.Log ("RALENTIZADO");
		StartCoroutine ("selfDestroy");
	}

	public IEnumerator selfDestroy () {
		yield return new WaitForSeconds (duration);
		Debug.Log ("FIN RALENTIZADO");
		GetComponent<EnemyStats> ().Speed += slow;
		GetComponent<MeshRenderer> ().material.color = Color.yellow;
		// SUBIR LA VELOCIDAD
		Destroy (this);
	}
}
