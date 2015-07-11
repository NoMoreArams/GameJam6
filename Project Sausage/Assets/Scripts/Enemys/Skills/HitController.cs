using UnityEngine;
using System.Collections;

public class HitController : MonoBehaviour {


    private int damage;
    private bool markToDestroy = false;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (markToDestroy)
            DestroyImmediate(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DamageDebuff db = other.gameObject.AddComponent<DamageDebuff>();
            db.Execute(damage);
            markToDestroy = true;
        }
    }

    public void SetEnemyDamage(int pe_enemyDamage)
    {
        damage = pe_enemyDamage;
    }
}
