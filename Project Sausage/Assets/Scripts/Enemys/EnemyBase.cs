using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    private static int enemyNumber = 0;
    private EnemyMovement enemyMovement;

    void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Use this for initialization
	void Start () {
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
