using UnityEngine;
using System.Collections;

public class SpikeMoveScript : MonoBehaviour {


    public float time;
    private float startSpeed = 0;
    private float speed;

    public float changeAmount = 0.05f;


    public GameObject block;

    private Vector2 velocity = Vector2.zero;

    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start () {



        speed = startSpeed + Random.Range(-100, -10);

        block.SetActive(true);
        rigidBody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        time = Time.timeSinceLevelLoad / 25;


        transform.Rotate(Vector3.forward * 0);

        velocity = new Vector2(0, speed);
        rigidBody.velocity = velocity;

        if (Time.timeScale != 0)
        {
            speed -= time;
        }

    }
}
