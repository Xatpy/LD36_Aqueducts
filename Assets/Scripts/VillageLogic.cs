using UnityEngine;
using System.Collections;

public class VillageLogic : MonoBehaviour {

	public GameObject GameState;

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Water") {
			Debug.Log ("end");
			GameState.SendMessage ("LevelCompleted", true, SendMessageOptions.RequireReceiver);
		}
	}
}
