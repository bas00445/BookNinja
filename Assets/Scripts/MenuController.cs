using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public string[] gameLevel = { "easy", "medium", "hard" };
	public string currentGameMode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setGameMode(string mode){
		this.currentGameMode = mode;
	}
		
}
