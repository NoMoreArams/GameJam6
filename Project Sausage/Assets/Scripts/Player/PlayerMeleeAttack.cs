using UnityEngine;
using System.Collections;

public class PlayerMeleeAttack : MonoBehaviour {

	// GameObject que va anclado en la animacion
	public GameObject KnifeMelee;

	public float cooldown;
	private float time2Attack;

	// Segundos a esperar
	public float Esperar;

	// Use this for initialization
	void Start ()
	{
		time2Attack = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Click derecho
		if (Input.GetMouseButtonDown (1)) {
			if (time2Attack <= 0) {
				Attack ();
				time2Attack = cooldown;
			}
		}
		time2Attack -= Time.deltaTime;
	}

	// Atacar
	private void Attack()
	{
		// Comenzar a atacar
		KnifeMelee.GetComponent<KnifeMelee> ().BeginAttack ();
		GetComponent<Animator> ().SetBool ("attack", true);

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
		GetComponent<Animator> ().SetBool ("attack", false);
	}
}
