using UnityEngine;
using System.Collections;

public class HoneyDebuff : MonoBehaviour {

	public int slow = 10;
	public float duration = 2f;

	public void Start () {
		// BAJAR LA VELOCIDAD
		Debug.Log ("RALENTIZADO");
		StartCoroutine ("selfDestroy");
	}

	public IEnumerator selfDestroy () {
		yield return new WaitForSeconds (duration);
		Debug.Log ("FIN RALENTIZADO");
		// SUBIR LA VELOCIDAD
		Destroy (this);
	}
}
