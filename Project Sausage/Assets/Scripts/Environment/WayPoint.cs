using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

    public bool endWayPoint = false;
    public WayPoint nextWayPoint;
	// Use this for initialization
	void Start () {
        if (!endWayPoint && nextWayPoint == null)
        {
            Debug.LogError("Error en WayPoint. Un WayPoint que no sea final no puede no tener un nextWayPoint");
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
