using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class PlayerDie : MonoBehaviour {

	// Tiempo muerto
	public float DeadTime;

	// Stats del player
	private PlayerStats Stats;

	// Cabeza
	private GameObject cabeza;

	// Camara
	private GameObject camara;

	// Use this for initialization
	void Start ()
	{
		// Obtener stats
		if(Stats == null)
			Stats = gameObject.GetComponent<PlayerStats> ();

		// Obtener cabeza
		if (cabeza == null)
			cabeza = GameObject.Find ("Cabeza");

		// Obtener camara
		if (camara == null)
			camara = GameObject.Find ("Camera");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Comprobar si el player esta vivo
		if (!Stats.Alive)
		{
			StartCoroutine("Die");
		}
	}

	// Recoger tecla para morir -- DEBUG --
	void FixedUpdate()
	{
		// Kill
		if (Input.GetKey (KeyCode.K)) 
		{
			Stats.ReceiveDamage(Stats.Health);
		}
	}

	// Morir
	private IEnumerator Die()
	{
		// Particulas


		// Deshabilitar movimiento
		gameObject.GetComponent<PlayerMovement>().enabled = false;

		// Habilitar efectos
		camara.GetComponent<Blur> ().enabled = true;
		camara.GetComponent<Grayscale> ().enabled = true;

		// Hacer semitransparente
		Color color = gameObject.GetComponent<MeshRenderer> ().material.color;
		color.a = 0.3f;
		gameObject.GetComponent<MeshRenderer> ().material.color = color;

		// Cabeza
		Color color_cabeza = cabeza.GetComponent<MeshRenderer> ().material.color;
		color_cabeza.a = 0.3f;
		cabeza.GetComponent<MeshRenderer> ().material.color = color_cabeza;

		// Esperar muerto
		yield return new WaitForSeconds (DeadTime);


		// REVIVIR

		// Subir vida
		Stats.Health = Stats.MaxHealth;

		// Hacer solido
		color.a = 1.0f;
		gameObject.GetComponent<MeshRenderer> ().material.color = color;

		// Cabeza
		color_cabeza.a = 1.0f;
		cabeza.GetComponent<MeshRenderer> ().material.color = color_cabeza;

		// Habilitar efectos
		camara.GetComponent<Blur> ().enabled = false;
		camara.GetComponent<Grayscale> ().enabled = false;

		// Habilitar movimiento
		gameObject.GetComponent<PlayerMovement>().enabled = true;
	}
}
