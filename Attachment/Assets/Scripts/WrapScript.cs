using UnityEngine;
using System.Collections;

public class WrapScript : MonoBehaviour {

	public Rigidbody2D player1;
	public Rigidbody2D player2;


	private bool trigger = false;
	private GameObject collectObject;

	public AudioSource collectSound;


    //gettings scripts for powerups
    public GameObject spawner;
    public SpawnerScript spawnerScript;
    public BlockMoveScript blockMoveScript;
    public GameObject control;
    public MovementScript movementScript;

    //powerup scripts
   // private bool slowBonusActive = false;
    private float slowBonusTimer = 0f;
	private float ropeBonusTimer = 0f;


	// Use this for initialization
	void Start () {

        movementScript = control.GetComponent<MovementScript>();
        spawnerScript = spawner.GetComponent<SpawnerScript>();

	}
	
	// Update is called once per frame
	void Update () {

        if (slowBonusTimer > -1f)
        {
            slowBonusTimer -= Time.deltaTime;
        
            
        }

		if (ropeBonusTimer > 0f) {

			print (ropeBonusTimer);
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

                Destroy(collectObject);
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
    }

    private void activateDashBonus()
    {
        movementScript.dashPowerup();
    }


    private void activateSlowBonus()
    {
        this.slowBonusTimer = 5f;
    }

	private void activateRopeBonus()
	{
		this.ropeBonusTimer = 9f;
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
			

		