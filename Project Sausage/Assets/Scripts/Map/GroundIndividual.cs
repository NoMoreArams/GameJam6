using UnityEngine;
using System.Collections;

public class GroundIndividual : MonoBehaviour {

	public Material normal;
	public Material selected;
	public bool trapped = false;

	void OnMouseEnter () {
		GetComponent<MeshRenderer> ().material = selected;
	}

	void OnMouseExit () {
		GetComponent<MeshRenderer> ().material = normal;
	}
}
