using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

	private int currentSelect;

	public GameObject selector;

	public Text retry;
	public Text mainMenu;


	public void Start(){

		currentSelect = 1;
	}

	public void Update(){

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

	}





	public void changeSelector(){

		switch (currentSelect) {

		case 1:
			selector.transform.position = retry.transform.position + new Vector3(50,-5,0);
			break;
		case 2:
			selector.transform.position = mainMenu.transform.position + new Vector3(50,-5,0);
			break;
		


		}

	}



	public void enterPressed(){

		switch (currentSelect) {

		case 1:
			Application.LoadLevel ("Game");
			break;
		case 2:
			Application.LoadLevel ("MainMenu");
			break;


		}

	}
}
