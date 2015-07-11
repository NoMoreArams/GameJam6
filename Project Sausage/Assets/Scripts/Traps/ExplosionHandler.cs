using UnityEngine;
using System.Collections;

public class ExplosionHandler : MonoBehaviour {

	public TrapAttributtes tAttr;
	public float duration;

	void Start () {
		StartCoroutine ("Die");
	}

	public IEnumerator Die () {
		yield return new WaitForSeconds (duration);
		Destroy (gameObject);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			DamageDebuff buff = other.gameObject.AddComponent<DamageDebuff>();
			buff.Execute(tAttr.damage);
		}
	}
}
