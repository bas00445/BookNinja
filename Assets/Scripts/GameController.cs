using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;
    public Text comboText;
    public Text timeLeftText;
	public int score; // Global score to display
    public int combo;
    public float timeLeft;

    public bool isGameStart = false;

    // Use this for initialization
    void Start () {
		this.score = 0;
        this.combo = 1;
        this.timeLeft = 90;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.isGameStart)
        {
            this.timeLeft -= Time.deltaTime;
            this.timeLeftText.text = "Time Left: " + ((int)(this.timeLeft)).ToString();
            this.scoreText.text = "Score: " + this.score.ToString();
            this.comboText.text = "x" + this.combo.ToString();

            if(this.timeLeft < 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
