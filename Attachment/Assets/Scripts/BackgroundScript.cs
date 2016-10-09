using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

	//public Transform background;
	public BoxCollider2D	rt;





	public GameObject[] prefabs;

	public float changeSpawn = 0.00001f;

	public float minSize;
	public float maxSize;



	public float maxRate;
	public float minRate;
	public float rate;

	private float blockDelayMin = 0.6f;
	private float blockDelayMax = 1.5f;
	private float blockDelay = 0.1f;

	// Use this for initialization
	void Start () {



		//RectTransform rt = background.GetComponent<RectTransform>();

		StartCoroutine(blockGenerator());
	




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


		float size = Random.Range (minSize, maxSize);
		//gets a random position between the min and max x values of the background
		Vector2 newPosition = new Vector2(Random.Range(-(rt.size.x/2), (rt.size.x/2)),transform.position.y);
		//Vector2 newScale = new Vector2 (size, size);


		transform.position = newPosition;
		//transform.localScale = newScale;


		var newTransform = transform;


		Instantiate(prefabs[Random.Range(0, prefabs.Length)],newTransform.position,Quaternion.identity);

		//randomize spawn rate
		//blockDelay = Random.Range(blockDelayMin, blockDelayMax);

		StartCoroutine(blockGenerator());
	}
}