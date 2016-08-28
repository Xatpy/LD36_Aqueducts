using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	public float ReleaseTime = 0.78f;
	public GameObject goPress;
	public GameObject goRelease;
	public GameObject goGo;

	bool bActive = false;
	float seconds;

	bool bWaiting = false;
	float secondsWaiting = .0f;
	float maxWait = 0.4f;

	void Reset() {
		seconds = 0f;
		bActive = false;
		ReleaseTime = 0.78f;
		bWaiting = false;
		secondsWaiting = .0f;
	}

	void SetActive(bool value) {
		bActive = value;
	}
		
	// Update is called once per frame
	void Update () {
		if (bActive) {
			seconds += Time.deltaTime;
			if (seconds > ReleaseTime) {
				ShowRelease ();
			}
		}

		if (bWaiting) {
			secondsWaiting += Time.deltaTime;
			if (secondsWaiting > maxWait) {
				ShowPress ();
				bWaiting = false;
				secondsWaiting = 0.0f;
			}
		}
	}

	void SetReleaseTime(int currentArc){
		if (currentArc <= 3) {
			ReleaseTime -= 0.07f;
		} else if (currentArc < 6) {
			ReleaseTime -= 0.035f;
		} else {
			ReleaseTime -= 0.01f;
		}
	}

	void ShowPress() {
		goPress.SetActive (true);
		goRelease.SetActive (false);
		goGo.SetActive (false);
	}

	void ShowRelease() {
		goPress.SetActive (false);
		goRelease.SetActive (true);
		goGo.SetActive (false);
	}

	void ShowGo() {
		goPress.SetActive (false);
		goRelease.SetActive (false);
		goGo.SetActive (true);
	}

	void Hide() {
		goPress.SetActive (false);
		goRelease.SetActive (false);
		goGo.SetActive (false);
		bActive = false;
		bWaiting = false;
	}

	void ButtonPressed() {
		bActive = true;
	}

	void ButtonReleased(int currentArc) {
		bActive = false;
		bWaiting = true;
		bWaiting = true;
		seconds = 0f;
		SetReleaseTime (currentArc);
	}
}
