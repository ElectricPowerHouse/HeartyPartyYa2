using UnityEngine;
using System.Collections;

public class CollectScript : MonoBehaviour {

	public bool collectTrigger = false;

	public GameObject control;
	public ScoreManager scoreManager;


	public AudioClip[] fuelSounds;
	public AudioSource fuelSound;

	// Use this for initialization
	void Start () {
		scoreManager = control.GetComponent<ScoreManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		/*
		if (other.tag == "player2" && this.tag == "player2") {
			
			collectTrigger = true;
			if (other != null) {
				Destroy (other.gameObject);
				fuelSound.clip = fuelSounds [Random.Range (0, fuelSounds.Length)];
				fuelSound.Play ();
				scoreManager.addScore (2);

			}

		}
//		else if(other.tag == "player2" && this.tag == "player2"){
		else if(other.tag == "player2" && this.tag == "player1"){
			
			collectTrigger = true;
			if (other != null) {
				Destroy (other.gameObject);
				fuelSound.clip = fuelSounds [Random.Range (0, fuelSounds.Length)];
				fuelSound.Play ();
				scoreManager.addScore (2);
			}

		}
		*/
	}
}
