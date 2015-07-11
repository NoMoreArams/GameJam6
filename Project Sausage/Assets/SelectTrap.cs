﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectTrap : MonoBehaviour {

	public Image[] skills;
	public GameObject[] prefabSkills;

	public int selected;

	// Use this for initialization
	void Start () {
		selected = 0;
		skills[selected].color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			if (selected < skills.Length -1) {
				skills[selected].color = Color.white;
				selected++;
				skills[selected].color = Color.green;
			}
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (selected > 0) {
				skills [selected].color = Color.white;
				selected--;
				skills [selected].color = Color.green;
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray,out hit, 1000)) {
				if (hit.collider.tag == "Ground" && !hit.collider.gameObject.GetComponent<GroundIndividual>().trapped) {
					GameObject go = Instantiate(prefabSkills[selected],
					                            hit.transform.position + new Vector3(-1f, 0, 1f),
					                            prefabSkills[selected].transform.rotation) as GameObject;
					go.GetComponent<TrapMaster>().gi = hit.collider.gameObject.GetComponent<GroundIndividual>();
					hit.collider.gameObject.GetComponent<GroundIndividual>().trapped = true;

				}
			}
		}
	}
}
