using UnityEngine;
using System.Collections;

public class TrapMaster : MonoBehaviour {

	protected TrapAttributtes tAttr;
	public GroundIndividual gi;

	void Start () {
		tAttr = GetComponent<TrapAttributtes> ();
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			if (tAttr.CanUse()) {
				Execute(other.gameObject);
			}
		}
	}

	virtual
	public void Execute (GameObject other) {}

}
