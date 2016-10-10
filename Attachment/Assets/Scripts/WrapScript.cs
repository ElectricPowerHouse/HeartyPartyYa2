using UnityEngine;
using System.Collections;

public class WrapScript : MonoBehaviour {

	public Rigidbody2D player1;
	public Rigidbody2D player2;
	public Camera mainCamera;

	public GameObject explodingParticles;

	public GameObject collectTile1;
	public GameObject collectTile2;
	public GameObject collectTile3;
	public GameObject collectTile4;


	private bool trigger = false;
	public GameObject collectObject;

	public AudioSource collectSound;
	public AudioSource boom;

	public AudioClip[] fuelSounds;
	public AudioSource fuelSound;


    //gettings scripts for powerups
	public GameObject powerUp;
	public PowerUpUI powerUpScript;
	public GameObject health;
	private HealthScript healthScript;
    public GameObject spawner;
    public SpawnerScript spawnerScript;
    public BlockMoveScript blockMoveScript;
    public GameObject control;
    public MovementScript movementScript;
	public ScoreManager scoreManager;

    //powerup scripts
   // private bool slowBonusActive = false;
    private float slowBonusTimer = 0f;
	private float ropeBonusTimer = 0f;


	// Use this for initialization
	void Start () {

		powerUpScript = powerUp.GetComponent<PowerUpUI> ();
		healthScript = health.GetComponent<HealthScript> ();
        movementScript = control.GetComponent<MovementScript>();
        spawnerScript = spawner.GetComponent<SpawnerScript>();
		scoreManager = control.GetComponent<ScoreManager> ();

	}
	
	// Update is called once per frame
	void Update () {

        if (slowBonusTimer > -1f)
        {
            slowBonusTimer -= Time.deltaTime;
        
            
        }

		if (ropeBonusTimer > 0f) {

			//print (ropeBonusTimer);
			ropeBonusTimer -= Time.deltaTime;
		}

        if(slowBonusTimer > 0f)
        {
            callScriptOnBlocks();
        }
        

        
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "capture"){
			


			//other.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		collectObject = other.gameObject;

		}
	
		if (other.gameObject.tag == "capture" && this.tag == "rope") {
			trigger = true;
			Invoke ("InvokeTrigger", 0.5f);

		}

		if (other.gameObject.tag == "block" && ropeBonusTimer > 0 && this.tag == "rope") {

			if (other != null) {


				Destroy(other.gameObject);

			}
		}



	}
		


	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "fuel") {


			if (other != null) {
				Destroy (other.gameObject);
				healthScript.runScript ();
				fuelSound.clip = fuelSounds [Random.Range (0, fuelSounds.Length)];
				fuelSound.Play ();
				scoreManager.addScore (2);

			}

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

            if (collectObject != null)
            {


				explodingParticles.transform.position = collectObject.transform.position;
				explodingParticles.GetComponent<ParticleSystem> ().Play ();
				//boom.Play ();
                Destroy(collectObject);
				mainCamera.GetComponent<CameraShake> ().ShakeCamera (4f, 0.35f);
                collectSound.Play();

                string name = collectObject.name;
                print(name);

                if (name.Contains("captureBlock1"))
                {
					//activateRopeBonus ();
                    activateFuelBonus();
                }
                else if (name.Contains("captureBlock2"))
                {
					//activateRopeBonus ();
                    activateDashBonus();
                }
                else if (name.Contains("captureBlock3"))
                {
					//activateRopeBonus ();
                    activateSlowBonus();
                }
                else
                {
					activateRopeBonus ();
                }
              
               

               
              
               
            }
		}
		
	}

    private void activateFuelBonus()
    {
         spawnerScript.fuelPowerup();
		powerUpScript.Trigger ("Points Bonus", 5f, false);
    }

    private void activateDashBonus()
    {
        movementScript.dashPowerup();
		powerUpScript.Trigger ("Dash Increase", 5f, false);
    }


    private void activateSlowBonus()
    {
        this.slowBonusTimer = 5f;
		powerUpScript.Trigger ("Slow Motion", slowBonusTimer, true);
    }

	private void activateRopeBonus()
	{
		this.ropeBonusTimer = 9f;
		powerUpScript.Trigger ("Destroy All Blocks!", ropeBonusTimer, true);
	}

    private void callScriptOnBlocks()
    {
        BlockMoveScript[] blockScripts = Object.FindObjectsOfType(typeof(BlockMoveScript)) as BlockMoveScript[];
        for (int i = 0; i < blockScripts.Length; i++)
            blockScripts[i].slowBonus(slowBonusTimer);


        SpikeMoveScript[] spikeScripts = Object.FindObjectsOfType(typeof(SpikeMoveScript)) as SpikeMoveScript[];
        for (int i = 0; i < spikeScripts.Length; i++)
            spikeScripts[i].slowBonus(slowBonusTimer);
    }

}
			

		