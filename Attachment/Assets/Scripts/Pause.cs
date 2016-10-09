using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public bool isPaused;

	private int currentSelect;
	public GameObject selector;

	public GameObject pauseMenu;
	public GameObject deathScreen;

	public Text resumeGame;
	public Text mainMenu;

	public AudioSource selectSound;
	public AudioSource startSound;


	void Start(){
	
		currentSelect = 1;

	}

	void Update () {

		///////////////////////////////

		if (Input.GetKeyDown ("up") || Input.GetKeyDown ("r")) {
		if (currentSelect <= 1) {
			currentSelect = 2;
		} else
			currentSelect--;

			selectSound.Play ();
	}

	if (Input.GetKeyDown ("down") || Input.GetKeyDown ("f")) {
			if (currentSelect >= 2) {
			currentSelect = 1;
		} else
			currentSelect++;

			selectSound.Play ();

	}

	if (Input.GetKeyDown (KeyCode.LeftControl) || Input.GetKeyDown ("a")) {

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

        if (!isPaused)
        {

            return;
        }


		switch (currentSelect) {

		case 1:
			resume ();
			break;
		case 2:
			SceneManager.LoadScene ("MainMenu");
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

                SceneManager.LoadScene("MainMenu");
			}
		}
	
	}




	public void resume() {

		isPaused = false;
	}
}
