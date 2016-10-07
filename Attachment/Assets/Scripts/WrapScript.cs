using UnityEngine;
using System.Collections;

public class WrapScript : MonoBehaviour {

	public Rigidbody2D player1;
	public Rigidbody2D player2;


	private bool trigger = false;
	private GameObject collectObject;

	public AudioSource collectSound;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "capture"){
		collectObject = other.gameObject;
		}
	
		if (other.gameObject.tag == "capture" && this.tag == "rope") {
			trigger = true;
			Invoke ("InvokeTrigger", 0.5f);

		}

	}

	void OnCollisionExit2D(Collision2D other){
	
		trigger = false;
	}

	void InvokeTrigger(){
		if (trigger == true) {

			//Why is adding a force to the player objects causing the rope to break???

			//GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300,ForceMode2D.Impulse);
			//player1.AddForce (Vector2.up * 300,ForceMode2D.Impulse);
			//player2.AddForce (Vector2.up * 300,ForceMode2D.Impulse);
			if(collectObject != null){
				Destroy (collectObject);
				collectSound.Play ();
			}
		}
		
	}

}
			

		