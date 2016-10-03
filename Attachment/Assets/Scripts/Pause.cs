using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

	public bool isPaused;

	private int currentSelect;
	public GameObject selector;

	public GameObject pauseMenu;
	public GameObject deathScreen;

	public Text resumeGame;
	public Text mainMenu;


	void Start(){
	
		currentSelect = 1;

	}

	void Update () {

		///////////////////////////////

		if (Input.GetKeyDown ("up") || Input.GetKey ("r")) {
		if (currentSelect <= 1) {
			currentSelect = 2;
		} else
			currentSelect--;
	}

	if (Input.GetKeyDown ("down") || Input.GetKey ("f")) {
			if (currentSelect >= 2) {
			currentSelect = 1;
		} else
			currentSelect++;

	}

	if (Input.GetKeyDown (KeyCode.LeftControl) || Input.GetKey ("a")) {

		enterPressed ();
	}

	changeSelector ();

		checkForPause ();

}





public void changeSelector(){

	switch (currentSelect) {

	case 1:
		selector.transform.position = resumeGame.transform.position + new Vector3(50,-5,0);
		break;
	case 2:
			selector.transform.position = mainMenu.transform.position + new Vector3(70,-5,0);
		break;
	


	}

}



public void enterPressed(){

		switch (currentSelect) {

		case 1:
			resume ();
			break;
		case 2:
			Application.LoadLevel ("MainMenu");
			break;
	


		}
	}











		 
		public void checkForPause(){

		if (deathScreen.active == false) {


			if (isPaused) {
			
				pauseMenu.SetActive (true);
				Time.timeScale = 0f;

			} else {
			
				pauseMenu.SetActive (false);
				Time.timeScale = 1f;

			}

			if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Alpha2)) {
				isPaused = !isPaused;


			}
		}
		if (isPaused) {
		
			if (Input.GetKeyDown (KeyCode.LeftControl) || (Input.GetKeyDown("a"))) {
			
				Application.LoadLevel ("MainMenu");
			}
		}
	
	}




	public void resume() {

		isPaused = false;
	}
}
