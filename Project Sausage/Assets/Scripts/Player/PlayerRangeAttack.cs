using UnityEngine;
using System.Collections;

public class PlayerRangeAttack : MonoBehaviour {

	// Fuerza con la que se lanza el cuchillo
	public float force;

	// Velocidad del cuchillo
	public float speed;

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
		// Calcular rotacion inicial
		float rz_ini = Random.Range (0f, 60f);
		Quaternion rot = thrower.rotation;
		rot.x += rz_ini;

		// Instanciar cuchillo
		GameObject knifeClone = (GameObject)Instantiate(knife, thrower.position, knife.transform.rotation);
		knifeClone.transform.SetParent (thrower);
	}
}
