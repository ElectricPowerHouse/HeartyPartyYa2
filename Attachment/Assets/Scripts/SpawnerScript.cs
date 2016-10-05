using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    //public Transform background;
    public BoxCollider2D	rt;





    public GameObject[] prefabs;
	public GameObject[] fuel;
    public GameObject[] captureBlocks;

	public float changeSpawn = 0.00001f;


    public float maxRate;
    public float minRate;
	public float rate;



    private float blockDelayMin = 0.6f;
    private float blockDelayMax = 1.5f;
    private float blockDelay = 1f;

    private float captureDelayMin = 8f;
    private float captureDelayMax = 16;
    public float captureDelay = 10f;


	public float fuelDelay = 8f;

	// Use this for initialization
	void Start () {



        //RectTransform rt = background.GetComponent<RectTransform>();
        StartCoroutine(blockGenerator());
		StartCoroutine (fuelGenerator ());
		StartCoroutine (captureGenerator ());


	
	}
	
	// Update is called once per frame
	void Update () {


		
		if (Time.timeScale != 0) {
			rate -= changeSpawn;
			//blockDelay = rate;
		}
	}



    public IEnumerator blockGenerator()
    {
        //this will return the method everytime the delay is not reached,
        //so the rest of the method is not called.
        yield return new WaitForSeconds(blockDelay);


        //gets a random position between the min and max x values of the background
		Vector2 newPosition = new Vector2(Random.Range(-(rt.size.x/2), (rt.size.x/2)),transform.position.y);
        transform.position = newPosition;


        var newTransform = transform;

		Instantiate(prefabs[Random.Range(0, prefabs.Length)],newTransform.position,Quaternion.identity);

        //randomize spawn rate
        blockDelay = Random.Range(blockDelayMin, blockDelayMax);

        StartCoroutine(blockGenerator());
    }



	public IEnumerator fuelGenerator()
	{
		//this will return the method everytime the delay is not reached,
		//so the rest of the method is not called.
		yield return new WaitForSeconds(fuelDelay);


		//gets a random position between the min and max x values of the background
		Vector2 newPosition = new Vector2(Random.Range(-(rt.size.x/2), (rt.size.x/2)),transform.position.y);
		transform.position = newPosition;


		var newTransform = transform;

		Instantiate(fuel[Random.Range(0, fuel.Length)],newTransform.position,Quaternion.identity);

		StartCoroutine(fuelGenerator());
	}



    public IEnumerator captureGenerator()
    {
        //this will return the method everytime the delay is not reached,
        //so the rest of the method is not called.
        yield return new WaitForSeconds(captureDelay);


        //gets a random position between the min and max x values of the background
        Vector2 newPosition = new Vector2(Random.Range(-(rt.size.x / 2), (rt.size.x / 2)), transform.position.y);
        transform.position = newPosition;


        var newTransform = transform;

        Instantiate(captureBlocks[Random.Range(0, captureBlocks.Length)], newTransform.position, Quaternion.identity);


        //randomize spawn rate
        captureDelay = Random.Range(captureDelayMin, captureDelayMax);

        StartCoroutine(captureGenerator());
    }




    void OnTriggerExit2D(Collider2D other){
		if (other != null) {
			Destroy (other.gameObject);
		}
	}
}
