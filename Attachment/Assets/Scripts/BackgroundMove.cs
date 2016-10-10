using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {

	private Rigidbody2D rigidBody;
	float speed;

	private Vector2 velocity = Vector2.zero;

	// Use this for initialization
	void Start () {


		speed = Random.Range (-15, -50);
		rigidBody = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

		velocity = new Vector2(0, speed);
		rigidBody.velocity = velocity;
	}
}
