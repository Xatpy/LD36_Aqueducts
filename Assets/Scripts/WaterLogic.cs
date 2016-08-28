using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaterLogic : MonoBehaviour {

	public GameObject GameState;
	public GameObject goTutorial;
	public AudioSource audioSource;

	public float forceX = 500.0f;
	public Vector3 initPos;
    public Button buttonGo;

	private Rigidbody rb;
	private bool bActive = false;

	void Start() {
		rb = this.GetComponent<Rigidbody>();
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (bActive) {
			//Debug.Log (rb.velocity.x);
			if (!audioSource.isPlaying) {
				audioSource.Play ();
			}

			if (rb.IsSleeping () || rb.velocity.x < -0.05f) {
				GameState.SendMessage ("WaterEnd", true);
				bActive = false;
				audioSource.Stop ();
			}
		}
	}

    public void SetActive(bool value)
    {
        bActive = value;
    }

	public void GoWater() {
		goTutorial.SendMessage ("Hide");
		bActive = true;
		Vector3 force = new Vector3 (forceX, -100, 0);
		rb.AddForce (force);
		rb.isKinematic = false;
        buttonGo.interactable = false;
	}

    public void Reset()
    {
		this.transform.position = initPos;
        bActive = false;
        rb.isKinematic = true;
        this.GetComponent<TrailRenderer>().Clear();
	}
}
