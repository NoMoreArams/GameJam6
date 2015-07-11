using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    protected static int enemyNumber = 0;
    protected EnemyMovement enemyMovement;
    protected NavMeshAgent enemyAgent;
    protected EnemyStats enemyStats;

    protected bool isAttacker = false;
    public float percentAttacker = 20.0f;

    protected string nameType;

    protected virtual void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyStats = GetComponent<EnemyStats>();
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    protected virtual void Start()
    {
        gameObject.name = nameType + enemyNumber;
        enemyNumber++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setWayPoint(WayPoint pe_wayPointToMove)
    {
        enemyMovement.SetWayPointToMove(pe_wayPointToMove);
    }

    void SetIsAttacker()
    {
        if (Random.Range(0, 100) <= percentAttacker)
        {
            isAttacker = true;
        }
    }
}
