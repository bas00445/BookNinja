using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;
    public Text comboText;
    public Text timeLeftText;
    public GameObject comboBar;
    public GameObject innerComboBar;

    public MenuController menuController;

    private Animator innerComboBarAnim;

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

        this.innerComboBarAnim = this.innerComboBar.GetComponent<Animator>();
        this.innerComboBarAnim.SetTrigger("isReduceCombo");
    }

    void GameOver() {
        this.isGameStart = false;
    }

    void ComboBarController()
    {
        if(this.combo >= 1) {
            if (Input.GetMouseButtonDown(0))
            {
                this.combo += 1;
                this.innerComboBarAnim.SetTrigger("isNewCombo");

            }
        } 

        this.comboText.text = "x" + this.combo.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (this.isGameStart)
        {
            this.comboBar.SetActive(true);
            if (this.timeLeft >= 0)
            {
                this.ComboBarController();
                this.timeLeft -= Time.deltaTime;
                this.timeLeftText.text = "Time Left: " + ((int)(this.timeLeft)).ToString();
                this.scoreText.text = "Score: " + this.score.ToString();
                

            } else
            {
                Debug.Log("Game Over");
                this.menuController.ShowGameoverMenu();
                this.GameOver();
            }
        }
    }
}
