using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalState : MonoBehaviour {

	public static int round = 0;
	public static int score = 0;
	public static int lifes = 4;
	public static int coins = 10;
	public PlayerStats ps;
	public float time = 5f;
	private float time2Start;
	public int nEnemies;
	public float tEnemies;
	public bool gameStarted = false;
	public int incrementBetweenWaves;

	public Text scoreText;
	public GameObject time2StartText;
	public Text coinsText;

	public Image hpbar;

	public static void addScore (int score) {
		GlobalState.score += score;
	}

	public static void addCoins (int coins) {
		GlobalState.coins += coins;
	}

	public static void subsLife () {
		GlobalState.lifes--;
		GameObject.Find("Lifes").transform.GetChild(GlobalState.lifes).gameObject.SetActive(false);

        if (lifes == 0)
            ;//Time.timeScale = 0.0f;
			//; // FIN DE PARTIDA
	}

	void Start () {
		time2Start = time;
		//Cursor.visible = false;
		ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats> ();
	}

	void FixedUpdate () {
		if (time2Start <= 0) {
			gameStarted = true;
			GameObject.Find ("pr_InitialWayPoint").GetComponent<EnemyGeneration> ().StartWave (nEnemies, tEnemies);
			time2StartText.SetActive(false);
			time2Start = 20;
			nEnemies += incrementBetweenWaves;
		} else if (time2Start <= 10 && time2Start >= 0) { 
			time2StartText.SetActive(true);
			time2Start -= Time.fixedDeltaTime;
			time2StartText.GetComponent<Text>().text = time2Start.ToString("F0");
		} else {
			time2Start -= Time.fixedDeltaTime;
			time2StartText.GetComponent<Text>().text = time2Start.ToString("F0");
		}
		coinsText.text = coins.ToString ();
		scoreText.text = score.ToString ();

		hpbar.fillAmount = (float)ps.Health / (float)ps.MaxHealth;
	}

}
