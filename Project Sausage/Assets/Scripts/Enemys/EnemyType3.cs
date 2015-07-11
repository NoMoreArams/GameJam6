using UnityEngine;
using System.Collections;

public class EnemyType3 : EnemyBase
{

    protected override void Awake()
    {
        base.Awake();
    }
    // Use this for initialization
    protected override void Start()
    {
        nameType = "EnemyType3_";
        base.Start();
        enemyAgent.speed = enemyStats.Speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
