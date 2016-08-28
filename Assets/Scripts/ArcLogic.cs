using UnityEngine;
using System.Collections;

public class ArcLogic : MonoBehaviour {

	public bool bActive = false;
	public float bVelocity = 0.1f;
    public Vector3 posInit;

	void Reset(int level) {
        this.transform.position = posInit;
		bVelocity = 0.1f * level;
    }
	
	// Update is called once per frame
	void Update () {
		if (bActive) {
			Vector3 pos = this.transform.position;
			pos.y += bVelocity;
			this.transform.position = pos;
		}
	}

	void SetStatus(bool bValue){
		bActive = bValue;
	}
}
