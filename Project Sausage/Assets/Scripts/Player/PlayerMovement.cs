using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Camara
	public GameObject camara;

	// Limite rotacion vertical de la camara
	public float max_ry;
	public float min_ry;

	// Axis
	private float h;
	private float v;

	// Rotation
	private float rx;
	private float ry;

	// Velocidad del player
	private float speed;

	// Use this for initialization
	void Start ()
	{
		if (camara == null)
			camara = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Recoger movimiento
		//Debug.Log ("h: " + h + "; v: " + v + "; camara_rx: " + camara.transform.rotation.x + "; ry: " + ry);

		// Obtener velocidad
		speed = gameObject.GetComponent<PlayerStats>().Speed;

      	// Mover player
		transform.Translate(h * speed * Time.deltaTime, 0.0f, v * speed * Time.deltaTime);

		// Rotar player (horizontal)
		transform.Rotate(Vector3.up * rx * speed * 2);

		// Comprobar limites de rotacion
			// Si esta arriba y mueves hacia abajo
		if((camara.transform.rotation.x <= min_ry && ry < 0)

		   // Si esta abajo y mueves hacia arriba
		   || (camara.transform.rotation.x >= max_ry && ry > 0)

		   // Si esta entre medias
		   || (camara.transform.rotation.x > min_ry && camara.transform.rotation.x < max_ry))
				// Rotar camara (vertical)
				camara.transform.Rotate (Vector3.right, -ry * speed);

	}

	void FixedUpdate()
	{
		// Recoger movimiento
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		rx = Input.GetAxis ("Mouse X");
		ry = Input.GetAxis ("Mouse Y");
	}
}
