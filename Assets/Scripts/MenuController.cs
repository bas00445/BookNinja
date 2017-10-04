using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	private string currentGameMode;
	private string currentGameLevel;
	public GameObject MainMenu;
	public GameObject LevelMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetGameMode(string mode) {
		this.currentGameMode = mode;  // easy, normal, hard
		Debug.Log ("Mode:" + mode);

		if (mode == "single") {
			this.ShowLevelMenu ();
		} else if (mode == "multiplayer") {
			Application.LoadLevel (0); // Load in-game scene
		}
	}

	public void SetGameLevel(string level) {
		this.currentGameLevel = level;
		Debug.Log ("Level:" + level);

		Application.LoadLevel (0); // Load in-game scene
	}
		
	public void ShowLevelMenu() {
		this.MainMenu.SetActive (false);
		this.LevelMenu.SetActive (true);
	}
		
	public void ShowAboutus() {
		Debug.Log ("About us");
	}

	public void BackToMainMenu() {
		this.MainMenu.SetActive (true);
		this.LevelMenu.SetActive (false);
	}
		
}
