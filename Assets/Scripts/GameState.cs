using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public GameObject canvasLevelCompleted;
    public GameObject canvasFailRetry;
	public GameObject canvasInGame;
	public GameObject tutorial;

    public GameObject goInputSystem;
	public GameObject goWater;
    public GameObject goAqueduct;

	private AudioSource audioSource;
	public AudioClip clap;
	public AudioClip gameOver;
	public AudioClip click;

	private int currentLevel;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

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
		tutorial.SendMessage ("Hide", true);
		audioSource.PlayOneShot (clap);
    }

    public void ShowCanvasRetry()
    {
        canvasLevelCompleted.SetActive(false);
        canvasFailRetry.SetActive(true);
        canvasInGame.SetActive(false);
		audioSource.PlayOneShot (gameOver);
    }

    public void LevelCompleted(bool value) 
    {
        ShowCanvasLevelCompleted();
	}

	public void NewLevel(int level) {
        Reset(true);
        ShowCanvasInGame();
		audioSource.PlayOneShot (click);
	}

	public void RetryLevel(){
		Reset(false);
		ShowCanvasInGame();
		tutorial.SendMessage ("ShowPress", true);
		audioSource.PlayOneShot (click);
	}

	private void Reset(bool bType)
    {
		goAqueduct.SendMessage("Reset", bType);
        goWater.SendMessage("Reset", true);
        goInputSystem.SendMessage("Reset", true);
    }

}