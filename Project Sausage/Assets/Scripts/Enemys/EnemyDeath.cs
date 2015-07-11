using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

    private EnemyStats enemyStats;
    void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyStats != null && enemyStats.Health <= 0)
        {
            DestroyImmediate(gameObject);
        }
	}
}
