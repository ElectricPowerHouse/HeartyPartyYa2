﻿using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

   

	// Use this for initialization
	void Start () {

       
	
	}
	
	// Update is called once per frame
	void Update () {

       
	
	}

	void OnTriggerExit2D(Collider2D other){

		if(other.tag== "block"){
		Destroy (other.gameObject);
		}
	}


}
