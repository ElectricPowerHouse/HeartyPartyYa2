using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public Text healthAmount;
	public GameObject deathScreen;
	public GameObject players;


	private Image bar;
	private CollectScript collect1;
	private CollectScript collect2;


	public float decreaseSpeed;
	public float pointAmount;
	public float lerpSpeed;






	// Use this for initialization
	void Start () {
		bar = gameObject.GetComponent<Image> ();

		collect1 = player1.GetComponent<CollectScript> (); //Accessing the CollectScript script to get the bool trigger
		collect2 = player2.GetComponent<CollectScript> (); //Accessing the CollectScript script to get the bool trigger

	}
	
	// Update is called once per frame
	void Update () {



		//Checking to see if the collectTrigger bool from the CollectScript has been set to true

		if (collect1.collectTrigger == true) { 
			
			StartCoroutine (PointCollect());
			collect1.collectTrigger = false; //Setting it back to false so it doesnt loop
		}
		if (collect2.collectTrigger == true) { 
			
			StartCoroutine (PointCollect());
			collect2.collectTrigger = false; 
		}

		if (bar.fillAmount < 0.3f) { //Making the health bar turn red
			bar.color = Color.Lerp (bar.color, new Color(1.0f,0.25f,0.25f,1.0f), Time.deltaTime / lerpSpeed);
		} else {
			bar.color = Color.Lerp (bar.color, Color.white, Time.deltaTime / lerpSpeed);
		}
			
			
		bar.fillAmount -= Time.deltaTime / decreaseSpeed; //Gradually decreasing the amount of health
		healthAmount.text = Mathf.RoundToInt(bar.fillAmount * 100).ToString(); //Displaying score

		if (bar.fillAmount <= 0) { //Loss condition
			players.SetActive(false);
			deathScreen.SetActive (true);
		}

	}



	IEnumerator PointCollect(){ //Lerping between the current fillAmount and the fillAmount + pointAmount
		
		float t = 0;

		while(true){
			yield return null;
			bar.fillAmount = Mathf.Lerp(bar.fillAmount, bar.fillAmount + pointAmount / 1000, t/lerpSpeed);
			t += Time.deltaTime;

			if (t > lerpSpeed) {
				break;
			}
		}

	}
		
		
	}
		

