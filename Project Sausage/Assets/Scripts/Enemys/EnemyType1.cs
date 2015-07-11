using UnityEngine;
using System.Collections;

public class EnemyType1 : EnemyBase {

    protected override void Awake()
    {
        base.Awake();
    }
	// Use this for initialization
    protected override void Start()
    {
        nameType = "EnemyType1_";
        base.Start();
        enemyAgent.speed = enemyStats.Speed;
	}

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
