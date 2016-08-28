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
	public GameObject goTutorialScript;

	public Text goTxtLevel;
	public int Level = 1;


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
		if (Level == 1) {
			goTutorialScript.SendMessage ("ButtonPressed", true);
		}
		listArcs[CurrentArc].SendMessage("SetStatus", true);
	}

	void ButtonReleased(bool value) {
		Debug.Log ("Button released");
		listArcs[CurrentArc].SendMessage("SetStatus", false);
		//listArcs.Add((GameObject)CreateNewArc ());
		CurrentArc++;

		if (CurrentArc > TotalArcs) {
			buttonGo.interactable = true;
			if (Level == 1) {
				goTutorialScript.SendMessage ("ShowGo");
				goTutorialScript.SendMessage ("SetActive", false);
			}
			InputSystem.SendMessage ("ActiveGoButton", true, SendMessageOptions.RequireReceiver);
		} else if (Level == 1) 
		{
			goTutorialScript.SendMessage ("ButtonReleased", CurrentArc);
		}
	}

	Object CreateNewArc(){
		Vector3 newPos = listArcs [CurrentArc].transform.position;
		newPos.x += 2.0f;
		newPos.y = -9.0f;
		newPos.z = 10.0f;
		return Instantiate(prefabArc, newPos, Quaternion.identity);
	}

	//If bValue == true, new level
	//else, retry level
	void Reset(bool bType)
    {
		if (bType) {
			goTutorialScript.SendMessage ("Hide", true);
			Level += 1;
		} else {
			Level = 1;
			Debug.Log ("a");
			goTutorialScript.SendMessage ("Reset", true);
		}
		goTxtLevel.text = "Level " + Level.ToString();

        for (int i = 0; i < listArcs.Count; ++i)
        {
            listArcs[i].SendMessage("Reset", Level);
        }
        CurrentArc = 0;
        buttonGo.interactable = false;
    }
}
