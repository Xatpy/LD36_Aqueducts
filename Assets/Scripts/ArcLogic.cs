using UnityEngine;
using System.Collections;

public class ArcLogic : MonoBehaviour {

	public bool bActive = false;
	public float bVelocity = 0.1f;
    public Vector3 posInit;

	public AudioClip soundRock;
	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

	void Reset(int level) {
        this.transform.position = posInit;
		bVelocity = 0.1f * level;
    }
	
	void Update () {
		if (bActive) {
			if (!audioSource.isPlaying) {
				audioSource.PlayOneShot (soundRock);
			}
			Vector3 pos = this.transform.position;
			pos.y += bVelocity;
			this.transform.position = pos;
		}
	}

	void SetStatus(bool bValue){
		bActive = bValue;
	}
}
