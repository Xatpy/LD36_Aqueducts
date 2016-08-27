using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public GameObject canvasLevelCompleted;
	public GameObject canvasInGame;

	public GameObject goWater;

	public void WaterEnd(bool value) {
		Debug.Log ("ENDD");
		canvasLevelCompleted.SetActive (true);
		canvasInGame.SetActive (false);
	}

	public void LevelCompleted(bool value) {

	}

	public void NewLevel(int level) {
		Debug.Log ("New level");
		goWater.SendMessage ("SetInitPos", true);

	}
}