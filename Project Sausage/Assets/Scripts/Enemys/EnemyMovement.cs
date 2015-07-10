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
        if (!InRank())
        {
            enemyAgent.SetDestination(wayPointToMove.transform.position);
        }
        else
        {
            if (!wayPointToMove.endWayPoint)
            {
                wayPointToMove = wayPointToMove.nextWayPoint;
                wayPointToMove.ChangeNextWayPoint();
            }
            else
            {
                DestroyImmediate(gameObject);
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

    bool InRank()
    {
        float w_distance = Vector3.Distance(transform.position, wayPointToMove.transform.position);
        return w_distance < rank;
    }
}
