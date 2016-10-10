using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Time;


	void Start () {

		Time.GetComponent<TimeCounter> ().StartTimeCounter ();
	
	}
	

	void Update () {
	
	}
}
