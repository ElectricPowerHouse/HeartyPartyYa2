using UnityEngine;
using System.Collections;

public class BackgroundSprite : MonoBehaviour {


	public float minSize;
	public float maxSize;


	private float rotateMin = 0.5f;
	private float rotateMax = -0.5f;
	private float rotateAmount;

	// Use this for initialization
	void Start () {
		rotateAmount = Random.Range(rotateMin, rotateMax);
		float colorRange = Random.Range (0.5f, 0.9f);
		float blockAlpha = Random.Range (0.2f, 0.3f);
		GetComponent<SpriteRenderer> ().color = new Color (colorRange, colorRange, colorRange, blockAlpha);



		float size = Random.Range (minSize, maxSize);
		Vector2 newScale = new Vector2 (size, size);
		transform.localScale = newScale;

	
	}
	
	// Upd	ate is called once per frame
	void Update () {

		transform.Rotate(Vector3.forward * rotateAmount);
	
	}
}
