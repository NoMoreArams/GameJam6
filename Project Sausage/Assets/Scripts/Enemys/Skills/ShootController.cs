using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

    private Vector3 direction;
    private int damage;
    public float speed;
    private bool markToDestroy = false;
	// Use this for initialization
	void Start () {
        
        Destroy(gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (direction != null)
            transform.Translate(direction * Time.deltaTime * speed);

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

    public void SetPlayerTarget(Vector3 pe_direction)
    {
        direction = pe_direction;
    }

    public void SetEnemyDamage(int pe_enemyDamage)
    {
        damage = pe_enemyDamage;
    }
}
