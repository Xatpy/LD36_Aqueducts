using UnityEngine;
using System.Collections;

public class WaterLogic : MonoBehaviour {

	bool bActive = false;
	public float forceX = 400.0f;

	private Rigidbody rb;

	void Start() {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (bActive) {
			
		}
	}

	public void GoWater() {
		Debug.Log ("go Water");
		bActive = true;
		Vector3 force = new Vector3 (forceX, -100, 0);
		rb.AddForce (force);
		rb.isKinematic = false;
	}
}
