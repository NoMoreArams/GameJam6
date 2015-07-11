using UnityEngine;
using System.Collections;

public class Knife : MonoBehaviour {

	// Velocidad de rotacion
	public float RSpeed;

	// Daño del cuchillo
	public int damage;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		// Rotacion
		transform.Rotate(Vector3.left * RSpeed);
	}

	// Colisionar
	void OnTriggerEnter(Collider other)
	{
		// Si colisiona con un enemigo hacer daño
		if (other.gameObject.tag == "Enemy")
		{
			//other.gameObject.GetComponent<EnemyStats>().ReceiveDamage(1);
			DamageDebuff db = other.gameObject.AddComponent<DamageDebuff>();
			db.Execute(damage);
		}

		// Destruir cuchillo
		Destruir ();
	}

	// Destruir cuchillo
	private void Destruir()
	{
		// Particulas

		// Destruir
		Destroy(gameObject);

		// Log
		Debug.Log ("Cuchillo destruido");
	}
}
