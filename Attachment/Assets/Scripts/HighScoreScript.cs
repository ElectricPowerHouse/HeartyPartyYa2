using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighScoreScript : MonoBehaviour {

	public GameObject[] spotNameTexts;
	public GameObject[] spotScoreTexts;
	public GameObject newSpotName;


	private int[] spotScores = new int[10];
	private string[] spotNames = new string[10];
	private string playerNameText = "??????"; // <-------- CHANGE THIS TO INCREASE OR DECREASE YOUR NAME INPUT LENGTH

	//--------------------- DONT WORRY ABOUT THE VARIABLES BELOW
	private int playerSpotIndex = 0;
	private int currentLetterSelection = 0;
	private int currentSelectedSpot = 0;
	private bool underscoreActive = true;
	private bool showUnderscore = true;
	private float underscoreTimer;
	private float underscoreShowTime = 2;
	private string[] letters = {"?", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", 
		"N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
	};

	// Use this for initialization
	void Start () {
		newSpotName.GetComponent<Text> ().text = playerNameText;
		//--------------------- USE THE GLOBAL HIGHSCORES SCRIPT TO UPDATE YOUR SCORE YOU CAN ACCESS IT FROM
		//--------------------- ANY SCRIPT JUST BY TYPING GlobalHighscore.lastHighscore MAKE SURE YOU UPDATE
		//--------------------- GlobalHighscore.lastHighscore WHEN GAME OVER HAPPENS BEFORE YOU SWITCH TO THE
		//--------------------- HIGHSCORE SCENE!
		GlobalHighscore.lastHighscore = Random.Range(1,99999); //----------- REMOVE THIS, ITS FOR TESTING ONLY

		//PlayerPrefs.DeleteAll (); // <-------------- ENABLE THIS TO CLEAR YOUR HIGHSCORES DATA
		LoadScores ();
		if (GlobalHighscore.lastHighscore <= spotScores [spotScores.Length - 1]) {
			gameObject.SetActive (false);
		} else {
			SetupHighscores (GlobalHighscore.lastHighscore);
		}
	}

	void Update(){
		bool letterChange = false;
		bool spotChange = false;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			currentLetterSelection -= 1;
			letterChange = true;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			currentLetterSelection += 1;
			letterChange = true;
		} else if(Input.GetKeyDown(KeyCode.LeftArrow)){
			currentSelectedSpot -= 1;
			spotChange = true;
		} else if(Input.GetKeyDown(KeyCode.RightArrow)){
			currentSelectedSpot += 1;
			spotChange = true;
		}
		if (letterChange) {
			if (currentLetterSelection < 0) {
				currentLetterSelection = letters.Length - 1;
			}
			if (currentLetterSelection > letters.Length - 1) {
				currentLetterSelection = 0;
			}
			UpdatePlayerName ();
		}
		if (spotChange) {
			if(currentSelectedSpot < 0){
				currentSelectedSpot = playerNameText.Length - 1;
			}
			if (currentSelectedSpot > playerNameText.Length - 1) {
				currentSelectedSpot = 0;
			}
			currentLetterSelection = 0;
		}
		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Alpha2)) {
			SaveScore (GlobalHighscore.lastHighscore);

			//--------------------- SET THE SCENE YOU WANT TO LOAD AFTER HIGHSCORES HERE

			SceneManager.LoadScene (0); //           <-------------------- IMPORTANT
		}
	}

	//--------------------- WHENEVER A LETTER IS CHANGED ON SCREEN THIS IS CALLED TO UPDATE IT

	private void UpdatePlayerName(){
		char temp = letters [currentLetterSelection] [0];
		char[] tempArray = playerNameText.ToCharArray ();
		tempArray [currentSelectedSpot] = temp;
		playerNameText = new string (tempArray);
		newSpotName.GetComponent<Text> ().text = playerNameText;
	}

	private void SetupHighscores(int score){
		playerSpotIndex = 0;
		for (int i = 0; i < spotScores.Length; i++) {
			if (score > spotScores [i]) {
				playerSpotIndex = i;
				break;
			}
		}
		for (int i = spotScores.Length - 1; i > -1; i--) {
			if (i == playerSpotIndex) {
				spotScores [i] = score;
				spotNames [i] = "";
				break;
			}
			spotScores [i] = spotScores [i - 1];
			spotNames [i] = spotNames [i - 1];
		}
		newSpotName.transform.position = spotNameTexts [playerSpotIndex].transform.position;
		UpdateScores ();
	}

	private void UpdateScores(){
		for(int i = 0; i < spotScores.Length; i++){
			spotNameTexts [i].GetComponent<Text> ().text = spotNames [i];
			spotScoreTexts [i].GetComponent<Text> ().text = spotScores [i].ToString();
		}
	}

	private void SaveScore(int score){
		string name = playerNameText;
		int index = playerSpotIndex;
		print ("SAVING: " + name + " | " + score + " | " + index);
		spotScores [index] = score;
		spotNames [index] = name;
		string scoreString = "spotScore_" + index.ToString ();
		string nameString = "spotName_" + index.ToString ();
		SaveScoresToLocal ();
	}

	private void SaveScoresToLocal(){
		for (int i = 0; i < spotScores.Length; i++) {
			string scoreString = "spotScore_" + i.ToString ();
			PlayerPrefs.SetInt (scoreString, spotScores[i]);
		}
		for (int i = 0; i < spotNames.Length; i++) {
			string nameString = "spotName_" + i.ToString ();
			PlayerPrefs.SetString (nameString, spotNames[i]);
		}
	}

	private void LoadScores(){
		for (int i = 0; i < spotScores.Length; i++) {
			string scoreString = "spotScore_" + i.ToString ();
			spotScores [i] = PlayerPrefs.GetInt (scoreString);
		}
		for (int i = 0; i < spotNames.Length; i++) {
			string nameString = "spotName_" + i.ToString ();
			spotNames [i] = PlayerPrefs.GetString (nameString);
		}
	}
}
