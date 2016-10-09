using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public Collider2D player1;
	public Collider2D player2;
	public Collider2D background;

	private bool player1In;
	private bool player2In;

	public GameObject deathScreen;
	public GameObject players;


	// Use this for initialization
	void Start () {

		deathScreen.SetActive (false);
		players.SetActive (true);
		player1In = true;
		player2In = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!player1In && !player2In) {

			players.SetActive( false);
			deathScreen.SetActive (true);
		}

	
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.name == "Player1") {
			player1In = false;
		}

		if (other.gameObject.name == "Player2") {
			player2In = false;
		}
			
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.name == "Player1") {
			player1In = true;
		}

		if (other.gameObject.name == "Player2") {
			player2In = true;
		}
	}


}
