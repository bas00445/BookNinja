using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;
    public Text fpsText;
	public int score; // Global score to display
    public float deltaTime;

    public bool isGameStart = false;

    // Use this for initialization
    void Start () {
		this.score = 0;
		this.scoreText.text = "Score: " + this.score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		this.scoreText.text = "Score: " + this.score.ToString ();

    }
}
