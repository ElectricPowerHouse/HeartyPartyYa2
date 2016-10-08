using UnityEngine;
using System.Collections;

public class BlockMoveScript : MonoBehaviour {

    private float slowBonusTimer = -1f;

	public float time;
	private float startSpeed = 0;
	private float speed;


    private float rotateMin = 0.5f;
    private float rotateMax = -0.5f;
    private float rotateAmount;

	public float changeAmount = 0.05f;

    public GameObject block;
    public GameObject backgroundBlock;


    private Vector2 velocity = Vector2.zero;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {

		speed = startSpeed + Random.Range(-100,-10);

        rotateAmount = Random.Range(rotateMin, rotateMax);

        block.SetActive(true);
        rigidBody = GetComponent<Rigidbody2D>();


	
	}
	
	// Update is called once per frame
	void Update () {



        time = Time.timeSinceLevelLoad/25;


        transform.Rotate(Vector3.forward * rotateAmount);

        if (slowBonusTimer > 0)
        {
            //print("slow!");
            velocity = new Vector2(0, -60f);
           
        }
        else
        {
            velocity = new Vector2(0, speed);
        }

        rigidBody.velocity = velocity;
	
		if (Time.timeScale != 0) {
			speed -= time;
		}
	}

    public void slowBonus(float timer)
    {
        slowBonusTimer = timer;
    }
}
