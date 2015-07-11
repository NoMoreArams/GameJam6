using UnityEngine;
using System.Collections;

public class EnemyType2 : EnemyBase
{
    private GameObject thrower;

    public GameObject[] skills;
    protected override void Awake()
    {
        base.Awake();
        thrower = transform.FindChild("Thrower").gameObject;
    }
    // Use this for initialization
    protected override void Start()
    {
        nameType = "EnemyType2_";
        base.Start();
        enemyAgent.speed = enemyStats.Speed;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Movement()
    {
        StopCoroutine("ThrowSkill");
        base.Movement();
    }

    protected override void Attack()
    {
        base.Attack();
        
    }

    IEnumerator ThrowSkill()
    {
        while (true)
        {
            GameObject ob_shoot = Instantiate(skills[0], thrower.transform.position,Quaternion.identity) as GameObject;
            Vector3 w_direction = targetPlayer.transform.position - thrower.transform.position;
            w_direction = w_direction / w_direction.magnitude;
            ob_shoot.GetComponent<ShootController>().SetPlayerTarget(w_direction);
            
            yield return new WaitForSeconds(3.0f);
        }
    }

    protected override void StarAttack()
    {
        StartCoroutine("ThrowSkill");
    }
}
