using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

	private int currentSelect;

	public GameObject selector;

	public Text startGame;
	public Text instructions;
	public Text highScores;

	public AudioSource selectSound;

	public void Start(){

		currentSelect = 1;
	}
		
	public void Update(){

//		selector.clip = selectSound;

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
			selector.transform.position = startGame.transform.position + new Vector3(45,-5,0);
			break;
		case 2:
			selector.transform.position = instructions.transform.position + new Vector3(50,-6.5f,0);
			break;
		case 3:
			selector.transform.position = highScores.transform.position + new Vector3(50,-3,0);
			break;


		}

	}



	public void enterPressed(){

		switch (currentSelect) {

		case 1:
				Application.LoadLevel ("Game");
				break;
		case 2:
				Application.LoadLevel ("Instructions");
				break;
		case 3:
				Application.LoadLevel ("HighScores");
				break;


		}

	}
}
