using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalState : MonoBehaviour {

	public static int round;
	public static int score;
	public static int lifes;
	public static int coins = 10;
	public float time = 5f;
	private float time2Start;
	public int nEnemies;
	public float tEnemies;
	public bool gameStarted = false;
	public int incrementBetweenWaves;

	public Text scoreText;
	public GameObject time2StartText;
	public Text coinsText;

	public static void addScore (int score) {
		GlobalState.score += score;
	}

	public static void addCoins (int coins) {
		GlobalState.coins += coins;
	}

	public static void subsLife () {
		GlobalState.lifes--;
	}

	void Start () {
		time2Start = time;
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
	}

}
