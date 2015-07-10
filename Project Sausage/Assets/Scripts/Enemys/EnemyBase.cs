using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    private static int enemyNumber = 0;
    private EnemyMovement enemyMovement;

    protected virtual void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>(); 
    }

    // Use this for initialization
    protected virtual void Start()
    {
        gameObject.name = "EnemyType0_" + enemyNumber;
        enemyNumber++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setWayPoint(WayPoint pe_wayPointToMove)
    {
        enemyMovement.SetWayPointToMove(pe_wayPointToMove);
    }
}
