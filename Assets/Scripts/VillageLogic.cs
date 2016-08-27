using UnityEngine;
using System.Collections;

public class VillageLogic : MonoBehaviour {

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Water") {
			Debug.Log ("end");
		}
	}
}
