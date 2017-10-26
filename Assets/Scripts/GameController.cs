﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;
    public Text comboText;
	public int score; // Global score to display
    public int combo = 1;
    public float deltaTime;

    public bool isGameStart = false;

    // Use this for initialization
    void Start () {
		this.score = 0;
        this.scoreText.text = "" ;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.isGameStart)
        {
            this.scoreText.text = "Score: " + this.score.ToString();
            this.comboText.text = "x" + this.combo.ToString();
        }
    }
}
