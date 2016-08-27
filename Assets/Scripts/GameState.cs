using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public GameObject canvasLevelCompleted;
    public GameObject canvasFailRetry;
	public GameObject canvasInGame;

    public GameObject goInputSystem;
	public GameObject goWater;
    public GameObject goAqueduct;


	public void WaterEnd(bool value) {
        ShowCanvasRetry();
	}

    public void ShowCanvasInGame()
    {
        canvasLevelCompleted.SetActive(false);
        canvasFailRetry.SetActive(false);
        canvasInGame.SetActive(true);
    }

    public void ShowCanvasLevelCompleted()
    {
        canvasLevelCompleted.SetActive(true);
        canvasFailRetry.SetActive(false);
        canvasInGame.SetActive(false);
    }

    public void ShowCanvasRetry()
    {
        canvasLevelCompleted.SetActive(false);
        canvasFailRetry.SetActive(true);
        canvasInGame.SetActive(false);
    }

    public void LevelCompleted(bool value) 
    {
        ShowCanvasLevelCompleted();
	}

	public void NewLevel(int level) {
		Debug.Log ("New level");
        Reset();
        ShowCanvasInGame();
	}

    private void Reset()
    {
        goWater.SendMessage("Reset", true);
        goAqueduct.SendMessage("Reset", true);
        goInputSystem.SendMessage("Reset", true);
    }
}