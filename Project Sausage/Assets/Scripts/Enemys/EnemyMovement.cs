﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    private NavMeshAgent enemyAgent;
    private EnemyStats enemyStats;
    public WayPoint wayPointToMove;

    public float rank = 1.5f;
    public bool haveTarget = false;
    //public float distance;

    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyStats = GetComponent<EnemyStats>();
    }
	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
    {
        if (!haveTarget)
        {
            if (!InRank())
            {
                enemyAgent.speed = enemyStats.Speed;
                if (CheckDistances())
                    MoveEnemyToNextPoint();
            }
            else
            {
                if (!wayPointToMove.endWayPoint)
                {
                    MoveEnemyToNextPoint();
                }
                else
                {
                    DestroyImmediate(gameObject);
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {
        //distance = Vector3.Distance(transform.position, wayPointToMove.transform.position);
	}

    public void StopMovenment()
    {
        enemyAgent.Stop();
    }

    public void ResumeMovenment()
    {
        enemyAgent.Resume();
    }

    public void MoveToTarget(Vector3 pe_targetPosition)
    {
        haveTarget = true;
        SetEnemyDestination(pe_targetPosition);
    }

    public void ResumeToWayPoint()
    {
        haveTarget = false;
        SetEnemyDestination(wayPointToMove.transform.position);
        ResumeMovenment();
    }

    public void SetWayPointToMove(WayPoint pe_wayPointToMove)
    {
        wayPointToMove = pe_wayPointToMove;
        SetEnemyDestination(wayPointToMove.transform.position);
    }

    bool InRank()
    {
        float w_distance = Vector3.Distance(transform.position, wayPointToMove.transform.position);
        return w_distance < rank;
    }
    void MoveEnemyToNextPoint()
    {
        wayPointToMove = wayPointToMove.nextWayPoint;
        wayPointToMove.ChangeNextWayPoint();
        SetEnemyDestination(wayPointToMove.transform.position);
    }

    void SetEnemyDestination(Vector3 pe_destination)
    {
        Vector3 w_destination = new Vector3(pe_destination.x,
                                            transform.position.y,
                                            pe_destination.z);
        enemyAgent.SetDestination(w_destination);
    }

    bool CheckDistances()
    {
        if (wayPointToMove.endWayPoint)
            return false;

        float w_distanceToWayPoint, w_distanceToNextWayPoint;
        w_distanceToWayPoint = Vector3.Distance(transform.position,wayPointToMove.transform.position);
        w_distanceToNextWayPoint = Vector3.Distance(transform.position, wayPointToMove.nextWayPoint.transform.position);

        if (w_distanceToNextWayPoint < w_distanceToWayPoint)
            return true;

        return false;
    }
}
