using UnityEngine;
using System.Collections;

public class PlayerRangeAttack : MonoBehaviour {

	// Fuerza con la que se lanza el cuchillo
	public float force;

	// Velocidad del cuchillo
	public float speed;

	// Cuchillo
	public GameObject knife;

	// Use this for initialization
	void Start ()
	{
	
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
		GameObject knifeClone = (GameObject)Instantiate(knife, transform.position, transform.rotation);
		//knifeClone.velocity = transform.forward * speed;
	}
}
