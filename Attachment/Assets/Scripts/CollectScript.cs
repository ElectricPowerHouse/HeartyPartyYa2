using UnityEngine;
using System.Collections;

public class CollectScript : MonoBehaviour {

	public bool collectTrigger = false;

	public AudioSource fuelSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "player1" && this.tag == "player1") {
			
			collectTrigger = true;
			if (other != null) {
				Destroy (other.gameObject);
				fuelSound.Play ();

			}

		}
		else if(other.tag == "player2" && this.tag == "player2"){
			
			collectTrigger = true;
			if (other != null) {
				Destroy (other.gameObject);
				fuelSound.Play ();
			}

		}
	}
}
