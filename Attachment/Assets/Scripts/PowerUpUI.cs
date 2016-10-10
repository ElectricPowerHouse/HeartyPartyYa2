using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour {


	private float startScale = 0;
	private float endScale = 0.3f;
	private float lerpSpeed = 0.5f;
	private float t = 0;
	private bool scaleStart;


	private float timer;
	private string powerup;
	private bool timeEnable;







	// Use this for initialization
	void Start () {
		scaleStart = false;

	
	}
	
	// Update is called once per frame
	void Update () {

		if (scaleStart) {
			Scale ();
		}

		if (timer > 0 ) {

			if (timeEnable == true) {
				gameObject.GetComponent<Text> ().text = powerup + " " + Mathf.Round (timer);
			} else {
				gameObject.GetComponent<Text> ().text = powerup;
			}
			timer -= Time.deltaTime;

		}
	}







	void Scale(){
		transform.localScale = new Vector3 (Mathf.Lerp (startScale, endScale, Mathf.Sin(t/lerpSpeed * Mathf.PI * 0.5f)), Mathf.Lerp (startScale, endScale, Mathf.Sin(t/lerpSpeed * Mathf.PI * 0.5f)), 0);
		t += Time.deltaTime;

		if (t > lerpSpeed) {
			scaleStart = false;
			t = 0;
		}

		gameObject.GetComponent<Text> ().text = powerup + " " + timer;
		timer -= Time.deltaTime;


	}

		public void Trigger(string powerupName, float powerupTime, bool timerEnabled){
		timer = powerupTime;
		powerup = powerupName;
		timeEnable = timerEnabled;

		

		scaleStart = true;
	}

		
}
