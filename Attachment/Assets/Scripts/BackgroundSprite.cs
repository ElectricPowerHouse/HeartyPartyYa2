using UnityEngine;
using System.Collections;

public class BackgroundSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float colorRange = Random.Range (0.5f, 0.9f);
		float blockAlpha = Random.Range (0.2f, 0.5f);
		GetComponent<SpriteRenderer> ().color = new Color (colorRange, colorRange, colorRange, blockAlpha);



		float size = Random.Range (0.2f, 2f);
		Vector2 newScale = new Vector2 (size, size);
		transform.localScale = newScale;

	
	}
	
	// Upd	ate is called once per frame
	void Update () {
	
	}
}
