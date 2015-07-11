using UnityEngine;
using System.Collections;

public class EnemyStats : PlayerStats {

	// Stats especificos de los enemigos
	public int Score;

    private NavMeshAgent enemyAgent;

    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        /*GameObject go_player = GameObject.FindGameObjectWithTag("Player");
        if (go_player != null)
        {
            playerStats = go_player.GetComponent<PlayerStats>();
        }
        else
        {
            Debug.LogError("Error. Player don't find.");
        }*/
    }

	// Use this for initialization
	void Start () {
        //enemyAgent.radius = Random.Range(0.5f, 2.0f);
        enemyAgent.avoidancePriority = Random.Range(25, 75);
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

    public void GetRewards()
    {
        GlobalState.addCoins(Coins);
        GlobalState.addScore(Score);
    }
}
