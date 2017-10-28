using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;
    public Text comboText;
    public Text timeLeftText;
    public GameObject comboBar;
    private Animator comboBarAnim;

    public MenuController menuController;

	public int score; // Global score to display
    public int combo;
    public float timeLeft;

    public bool isGameStart = false;
    public bool isGameOver = false;

    // Use this for initialization
    void Start () {
		this.score = 0;
        this.combo = 1;
        this.timeLeft = 15;
        this.scoreText.text = "";
        this.comboText.text = "";
        this.timeLeftText.text = "";
        this.comboBarAnim = this.comboBar.GetComponent<Animator>();
        this.comboBarAnim.SetTrigger("isReduceCombo");
    }

    void GameOver() {
        this.isGameStart = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.isGameStart)
        {

            if (this.timeLeft >= 0)
            {
                if(Input.GetMouseButtonDown(0)) { 
                    this.comboBarAnim.SetTrigger("isNewCombo");
                }
                this.timeLeft -= Time.deltaTime;
                this.timeLeftText.text = "Time Left: " + ((int)(this.timeLeft)).ToString();
                this.scoreText.text = "Score: " + this.score.ToString();
                this.comboText.text = "x" + this.combo.ToString();

            } else
            {
                Debug.Log("Game Over");
                this.menuController.ShowGameoverMenu();
                this.GameOver();
            }
        }
    }
}
