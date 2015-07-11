using UnityEngine;
using System.Collections;

public class EnemyGeneration : MonoBehaviour {

    public GameObject[] enemy;
    public WayPoint[] initialsWayPoints;

    public int numEnemys;
    public float timeBetweenEnemys;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && enemy.Length > 0)
        {
            int w_enemy = (int)Random.Range(0, enemy.Length);
            GameObject go_enemy = Instantiate(enemy[w_enemy], transform.position, Quaternion.identity) as GameObject;
            int w_wayPoint = (int)Random.Range(0, initialsWayPoints.Length);
            go_enemy.GetComponent<EnemyBase>().setWayPoint(initialsWayPoints[w_wayPoint]);
        }
	}

    public void StartWave(int pe_numEnemys, float pe_timeBetweenEnemys)
    {

    }
}
