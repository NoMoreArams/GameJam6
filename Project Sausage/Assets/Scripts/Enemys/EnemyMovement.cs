using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    private NavMeshAgent enemyAgent;
    public WayPoint wayPointToMove;

    public float rank = 0.75f;
    public float distance;

    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }
	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
    {
        float w_distance = Vector3.Distance(transform.position, wayPointToMove.transform.position);
        if (w_distance < rank && wayPointToMove.endWayPoint)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            if (w_distance > rank)
            {
                enemyAgent.SetDestination(wayPointToMove.transform.position);
            }
            else
            {
                wayPointToMove = wayPointToMove.nextWayPoint;
            }
        }
    }

	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(transform.position, wayPointToMove.transform.position);
	}

    public void SetWayPointToMove(WayPoint pe_wayPointToMove)
    {
        wayPointToMove = pe_wayPointToMove;
    }
}
