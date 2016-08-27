using UnityEngine;
using System.Collections;

public class ArcLogic : MonoBehaviour {

	public bool bActive = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bActive) {
			Vector3 pos = this.transform.position;
			pos.y += 0.05f;
			this.transform.position = pos;
			Debug.Log ("out");
		}
	}

	void SetStatus(bool bValue){
		bActive = bValue;
	}
}
