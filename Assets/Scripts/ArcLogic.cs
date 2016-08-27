using UnityEngine;
using System.Collections;

public class ArcLogic : MonoBehaviour {

	public bool bActive = false;
	public float bVelocity = 0.1f;

    public Vector3 posInit;

	// Use this for initialization
	void Start () {
	
	}

    void Reset() {
        this.transform.position = posInit;
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
