using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class GlobalState : MonoBehaviour {

	public static int round;
	public static int score;
	public static int lifes;
	public static int coins;
	public float time = 5f;
	private float time2Start;
	public int nEnemies = 5;
	public float tEnemies = 0.5f;

	public Text scoreText;
	public GameObject time2StartText;

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
			GameObject.Find ("pr_InitialWayPoint").GetComponent<EnemyGeneration> ().StartWave (nEnemies, tEnemies);
			time2StartText.SetActive(false);
		} else {
			time2Start -= Time.fixedDeltaTime;
			time2StartText.GetComponent<Text>().text = time2Start + "";
		}
	}

}
