using UnityEngine;
using System.Collections;

public class WaterLogic : MonoBehaviour {

	public GameObject GameState;
	public float forceX = 400.0f;
	public Vector3 initPos;

	private Rigidbody rb;
	private bool bActive = false;

	void Start() {
		rb = this.GetComponent<Rigidbody>();
		initPos = new Vector3 (-7.7f, 4.3f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		if (bActive) {
			Debug.Log (rb.velocity.magnitude);
			if (rb.IsSleeping ()) {
				Debug.Log ("Sleeping");
				GameState.SendMessage ("WaterEnd", true);
				bActive = false;
			}
		}
	}

	public void GoWater() {
		Debug.Log ("go Water");
		bActive = true;
		Vector3 force = new Vector3 (forceX, -100, 0);
		rb.AddForce (force);
		rb.isKinematic = false;
	}
		
	public void SetInitPos() {
		this.transform.position = initPos;
	}
}
