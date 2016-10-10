using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {


	public float shakeTime;
	public float shakeAmount;

	float posX;
	float posY;
	float posZ;


	// Use this for initialization
	void Start () {

		posX = transform.position.x;
		posY = transform.position.y;
		posZ = transform.position.z;
	
	}

	void FixedUpdate(){
	
		transform.position = new Vector3 (posX, posY, posZ);
	}
	
	// Update is called once per frame
	void Update () {



		if (shakeTime >= 0) {
		
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

			shakeTime -= Time.deltaTime;
		}
	
	}

	public void ShakeCamera(float shakePwr, float shakeDur){
	
		shakeAmount = shakePwr;
		shakeTime = shakeDur;
	}
}
