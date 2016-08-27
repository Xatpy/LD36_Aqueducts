using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AqueductManager : MonoBehaviour {

	public List<GameObject> listArcs = new List<GameObject> ();
	public GameObject prefabArc;
	public Button buttonGo;
	public GameObject InputSystem;
	public int CurrentArc = 0;
	public int TotalArcs = 6;

	// Use this for initialization
	void Start () {
		buttonGo.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		//listArcs[0]
	}

	void ButtonPressed(bool value) {
		Debug.Log ("Button Pressed");
		listArcs[CurrentArc].SendMessage("SetStatus", true);
	}

	void ButtonReleased(bool value) {
		Debug.Log ("Button released");
		listArcs[CurrentArc].SendMessage("SetStatus", false);
		//listArcs.Add((GameObject)CreateNewArc ());
		CurrentArc++;

		if (CurrentArc > TotalArcs) {
			buttonGo.interactable = true;
			InputSystem.SendMessage ("ActiveGoButton", true, SendMessageOptions.RequireReceiver);
		}
	}

	Object CreateNewArc(){
		Vector3 newPos = listArcs [CurrentArc].transform.position;
		newPos.x += 2.0f;
		newPos.y = -9.0f;
		newPos.z = 10.0f;
		return Instantiate(prefabArc, newPos, Quaternion.identity);
	}

    void Reset()
    {
        for (int i = 0; i < listArcs.Count; ++i)
        {
            listArcs[i].SendMessage("Reset");
        }
        CurrentArc = 0;
        buttonGo.interactable = false;
    }
}
