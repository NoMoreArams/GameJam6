using UnityEngine;
using System.Collections;

public class EnemyStats : PlayerStats {

	// Stats especificos de los enemigos
	public int Score;
    public GameObject prHealthPoints;
    private HealthPoints healthPoints;

    private NavMeshAgent enemyAgent;

    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

	// Use this for initialization
	void Start () {
        enemyAgent.avoidancePriority = Random.Range(25, 75);
        SetAnchorCanvas();
	}

    public void GetRewards()
    {
        GlobalState.addCoins(Coins);
        GlobalState.addScore(Score);
    }

    public void KillEnemy()
    {
        Health = 0;
    }

    void SetAnchorCanvas()
    {
        GameObject enemyCanvas = GameObject.FindGameObjectWithTag("CanvasEnemys");
        Transform anchorCanvas = transform.FindChild("AnchorCanvas");

        Vector3 w_cameraPosition = Camera.main.WorldToScreenPoint(anchorCanvas.position);
        GameObject go_AnchorCanvas = Instantiate(prHealthPoints) as GameObject;

        go_AnchorCanvas.name = "EnemyCanvas" + this.name;
        go_AnchorCanvas.transform.SetParent(enemyCanvas.transform, false);
        go_AnchorCanvas.transform.position = w_cameraPosition;

        healthPoints = go_AnchorCanvas.GetComponent<HealthPoints>();
        healthPoints.SetAnchorCanvas(anchorCanvas);
        healthPoints.SetInitialHealthPoints(Health);
    }

    public GameObject GetEnemyCanvas()
    {
        return healthPoints.gameObject;
    }

    protected override void UpdateEnemyCanvas(int pe_damage)
    {
        healthPoints.UpdateHealthPoints(pe_damage);
    }
}
