using UnityEngine;
using System.Collections;

public class EnemyType3 : EnemyBase
{
    public GameObject[] skills;

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
        //StopCoroutine("ThrowSkill");
        base.Movement();
    }

    protected override void Attack()
    {
        base.Attack();
    }

    void ThrowSkill()
    {
        GameObject ob_hit = Instantiate(skills[0], thrower.transform.position, Quaternion.identity) as GameObject;
        ob_hit.transform.parent = transform;
        ob_hit.gameObject.name = "Hit";
        HitController w_shootControler = ob_hit.GetComponent<HitController>();
        w_shootControler.SetEnemyDamage(enemyStats.Damage);
    }
    /*IEnumerator ThrowSkill()
    {
        // Realizar en animación
        while (true)
        {
            GameObject ob_shoot = Instantiate(skills[0], thrower.transform.position, Quaternion.identity) as GameObject;
            Vector3 w_direction = targetPlayer.transform.position - thrower.transform.position;
            w_direction = w_direction / w_direction.magnitude;
            ShootController w_shootControler = ob_shoot.GetComponent<ShootController>();
            w_shootControler.SetPlayerTarget(w_direction);
            w_shootControler.SetEnemyDamage(enemyStats.Damage);

            yield return new WaitForSeconds(3.0f);
        }
    }*/

    protected override void StarAttack()
    {
        //ThrowSkill();
    }
}
