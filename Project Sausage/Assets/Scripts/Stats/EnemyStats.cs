using UnityEngine;
using System.Collections;

public class EnemyStats : PlayerStats {

	// Stats especificos de los enemigos
	public int Score;

    private NavMeshAgent enemyAgent;

    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

	// Use this for initialization
	void Start () {
        //enemyAgent.radius = Random.Range(0.5f, 2.0f);
        enemyAgent.avoidancePriority = Random.Range(25, 75);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
