using UnityEngine;
using System.Collections;

public class PlayerMeleeAttack : MonoBehaviour {

	// GameObject que va anclado en la animacion
	public GameObject KnifeMelee;

	// Segundos a esperar
	public float Esperar;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Click derecho
		if (Input.GetMouseButtonDown(1))
			Attack ();
	}

	// Atacar
	private void Attack()
	{
		// Comenzar a atacar
		KnifeMelee.GetComponent<KnifeMelee> ().BeginAttack ();

		// DEBUG -- Esperar
		StartCoroutine ("Wait");

	}

	// DEBUG: tiempo
	IEnumerator Wait()
	{
		// Esperar
		yield return new WaitForSeconds (Esperar);
		
		// Terminar de atacar
		KnifeMelee.GetComponent<KnifeMelee> ().EndAttack ();
	}
}
