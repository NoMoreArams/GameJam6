using UnityEngine;
using System.Collections;

public class PlayerRangeAttack : MonoBehaviour {

	// Fuerza con la que se lanza el cuchillo
	public float force;
	public float inclinacion;

	// Thrower
	public Transform thrower;

	// Cuchillo
	public GameObject knife;

	// Use this for initialization
	void Start ()
	{
		// Obtener thrower
		if (thrower == null)
			thrower = GameObject.Find ("KnifeThrower").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Click izquierdo
		if (Input.GetMouseButtonDown(0))
			ThrowKnife ();
	}

	// Lanzar cuchillo
	void ThrowKnife ()
	{
		// Random
		float r = Random.Range (0.0f, 25.0f);

		// Rotacion
		Quaternion rot = thrower.rotation;
		rot.x = r;

		// Instanciar cuchillo
		GameObject knifeClone = (GameObject)Instantiate(knife, thrower.position, rot);
		Physics.IgnoreCollision(knifeClone.GetComponent<Collider>(), GetComponent<Collider>());

		// Fuerza
		Vector3 lanzamiento = thrower.forward;
		lanzamiento.y = inclinacion;

		knifeClone.GetComponent<Rigidbody> ().AddForce (lanzamiento * force);
	}
}
