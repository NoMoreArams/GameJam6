using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    public enum EnemyStates
    {
        start,
        movenment,
        movenmentToAttack,
        Attack
    }

    public EnemyStates actualState;

    protected static int enemyNumber = 0;
    protected EnemyMovement enemyMovement;
    protected NavMeshAgent enemyAgent;
    protected EnemyStats enemyStats;
    public GameObject targetPlayer;

    public bool isAttacker = false;
    public float percentAttacker = 20.0f;
    public float rankAttacker = 10.0f;
    public float rankAttack = 7.0f;
    public bool ataco = false;
    public float distancia;

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
        SetIsAttacker();
        actualState = EnemyStates.movenment;
	}

    protected virtual void FixedUpdate()
    {
        switch (actualState)
        {
            case EnemyStates.movenment: Movement(); break;
            case EnemyStates.movenmentToAttack: MovenmentToAttack(); break;
            case EnemyStates.Attack: Attack(); break;
            default: break;
        }

        if (!targetPlayer.GetComponent<PlayerStats>().Alive)
            RestarMovenment();
    }

	// Update is called once per frame
	void Update () {
        
	}

    void Movement()
    {
        if (targetPlayer.GetComponent<PlayerStats>().Alive && InRankAttack(rankAttacker))
        {
            actualState = EnemyStates.movenmentToAttack;
            //enemyMovement.StopMovenment();
            enemyMovement.MoveToTarget(targetPlayer.transform.position);
        }
    }

    void MovenmentToAttack()
    {
        if (InRankAttack(rankAttack))
        {
            enemyMovement.StopMovenment();
            actualState = EnemyStates.Attack;
        }
        else if (InRankAttack(rankAttacker))
        {
            enemyMovement.ResumeMovenment();
            actualState = EnemyStates.movenment;
        }
                
    }

    void Attack()
    {
        if (!InRankAttack(rankAttack))
        {
            actualState = EnemyStates.movenment;
            enemyMovement.ResumeMovenment();
        }
    }

    void RestarMovenment()
    {
        enemyMovement.ResumeToWayPoint();
        actualState = EnemyStates.movenment;
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
            targetPlayer = GameObject.FindGameObjectWithTag("Player");
        }
    }

    bool InRankAttack(float pe_attack)
    {
        if (isAttacker && targetPlayer != null)
            return Vector3.Distance(transform.position, targetPlayer.transform.position) < pe_attack;

        return false;
    }

}
