using UnityEngine;
using System.Collections;

public class OpacityScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		if (Application.loadedLevel == 0) {
			Color newColor = Color.white;
			newColor.a = 0.2f;
			gameObject.GetComponent<SpriteRenderer> ().color = newColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
