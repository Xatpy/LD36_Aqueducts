using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputSystem : MonoBehaviour {

	public GameObject goAqueductManager;
	public GameObject goWater;

	private bool bIsGoActive = false;
	private bool bIsBeingPressed = false;
	
	// Update is called once per frame
	void Update () {
		if (goAqueductManager == null) {
			return;
		}

		if (bIsGoActive) {
			return;
		}

        if (EventSystem.current.currentSelectedGameObject != null &&
           (EventSystem.current.currentSelectedGameObject.GetComponent<Text>() != null ||
                  EventSystem.current.currentSelectedGameObject.GetComponent<Button>() != null))
        {
            return;
        }

		if (Input.GetButton ("Fire1")) {
			if (!bIsBeingPressed) {
				bIsBeingPressed = true;
				goAqueductManager.SendMessage ("ButtonPressed", true, SendMessageOptions.RequireReceiver);
			}
		} else {
			if (bIsBeingPressed) {
				bIsBeingPressed = false;
				goAqueductManager.SendMessage ("ButtonReleased", true, SendMessageOptions.RequireReceiver);
			}
		}
	}

    public void Reset()
    {
        bIsGoActive = false;
        bIsBeingPressed = false;
    }

	public void ActiveGoButton(bool value) {
		bIsGoActive = value;
	}

}
