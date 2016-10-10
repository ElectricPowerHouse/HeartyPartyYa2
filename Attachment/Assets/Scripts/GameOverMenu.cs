using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	private int currentSelect;

	public GameObject selector;

	public Text retry;
	public Text mainMenu;
	public Text highscore;

	public AudioSource selectSound;


	public void Start(){

		currentSelect = 1;
	}

	public void Update(){

		if (Input.GetKeyDown ("up") || Input.GetKeyDown ("r")) {
			if (currentSelect <= 1) {
				currentSelect = 3;
			} else
				currentSelect--;

			selectSound.Play ();
		}

		if (Input.GetKeyDown ("down") || Input.GetKeyDown ("f")) {
			if (currentSelect >= 3) {
				currentSelect = 1;
			} else
				currentSelect++;

			selectSound.Play ();

		}

		if (Input.GetKeyDown (KeyCode.LeftControl) || Input.GetKeyDown ("a")) {

			enterPressed ();
		}

		changeSelector ();

	}





	public void changeSelector(){

		switch (currentSelect) {

		case 1:
			selector.transform.position = retry.transform.position + new Vector3(50,-5,0);
			break;
		case 2:
			selector.transform.position = highscore.transform.position + new Vector3(68,-5,0);
			break;
		case 3: 
			selector.transform.position = mainMenu.transform.position + new Vector3 (50, -5, 0);
			break;
		


		}

	}



	public void enterPressed(){


		switch (currentSelect) {

		case 1:
			SceneManager.LoadScene ("Game");
			break;
		case 2:
			SceneManager.LoadScene ("HighScoreEnter");
			break;
		case 3:
			SceneManager.LoadScene ("MainMenu");
			break;

		}

	}
}
