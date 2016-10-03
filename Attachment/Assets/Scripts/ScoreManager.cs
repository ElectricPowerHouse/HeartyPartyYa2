using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text finalScoreText;
	public GameObject deathScreen;
	public float scoreCount;

	public Text finalTimeText;
	float ellapsedTime;
	int minutes;
	int seconds;

	public float pointsPerSecond;

	void Start () {



	}

	void Update () {


	


		if (deathScreen.active == false) {
			scoreCount += pointsPerSecond * Time.deltaTime;

			scoreText.text = " " + Mathf.Round (scoreCount);

			updateTime ();
		} else {


		}

		finalScoreText.text = " " + Mathf.Round (scoreCount);
	}

	public void updateTime(){

		ellapsedTime = Time.time;

		minutes = (int)ellapsedTime / 60;
		seconds = (int)ellapsedTime % 60;

		finalTimeText.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
	}
}