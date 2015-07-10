using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

    public bool endWayPoint = false;
    public WayPoint nextWayPoint;
    public WayPoint[] wayPoints;
	// Use this for initialization
	void Start () {
        if (!endWayPoint && nextWayPoint == null)
        {
            Debug.LogError("Error en WayPoint. Un WayPoint que no sea final no puede no tener un nextWayPoint");
        }
        ChangeNextWayPoint();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ChangeNextWayPoint()
    {
        if (wayPoints.Length > 0)
        {
            int w_nextWayPoint = (int)Random.Range(0, wayPoints.Length);
            nextWayPoint = wayPoints[w_nextWayPoint];
        }
    }
}
