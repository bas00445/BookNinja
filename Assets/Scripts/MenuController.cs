﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	private string currentGameMode;
	private string currentGameLevel;
    public GameObject Menu;
	public GameObject MainMenu;
	public GameObject LevelMenu;
    public GameObject GameoverMenu;
	public GameObject InGameProps;

    public GameController gameController;

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

        this.Menu.GetComponent<Animator>().SetTrigger("isSelectedLevel");

        Invoke("StartGame", 1.5f);

	}

    public void StartGame()
    {
        this.Menu.SetActive(false);
        this.gameController.isGameStart = true;
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

    public void ShowGameoverMenu()
    {
        this.GameoverMenu.SetActive(true);
    }

	public void HideGameOverMenu()
	{
        this.GameoverMenu.SetActive(false);		
	}

	public void RestartLevel()
	{
		this.gameController.RestartLevel();
		this.gameController.isGameStart = true;
		this.HideGameOverMenu();
	}

    public void NavigateToStartMenu()
    {
        Application.LoadLevel(0); 
    }

}
