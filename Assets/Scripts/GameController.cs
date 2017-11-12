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
    public FruitGenerator fruitGenerator;
    public AudioClip hitFruit;

    private Animator innerComboBarAnim;
    private AudioSource audioSource;

	public int score; // Global score to display
    public int combo;

    public float timeLeft;

    public string currentGameMode;

    public bool isGameStart = false;
    public bool isGameOver = false;

    private int highestScore;

    // Use this for initialization
    void Start () {
		this.score = 0;
        this.combo = 1;
        this.timeLeft = 60;
        this.scoreText.text = "";
        this.comboText.text = "";
        this.timeLeftText.text = "";

        this.innerComboBarAnim = this.innerComboBar.GetComponent<Animator>();
        this.audioSource = GetComponent<AudioSource>();
    }

    public void RestartLevel() {
        this.score = 0;
        this.combo = 1;
        this.timeLeft = 60;
        this.scoreText.text = "";
        this.comboText.text = "";
        this.timeLeftText.text = "";
    }

    void GameOver() {
        if(this.score > this.highestScore)
        {
            PlayerPrefs.SetInt(this.currentGameMode, this.score);
        }
        this.isGameStart = false;
        this.scoreText.text = "";
        this.comboText.text = "";
        this.timeLeftText.text = "";
        this.comboBar.SetActive(false);
        this.fruitGenerator.ClearFruits();
        this.menuController.ShowGameoverMenu();           
    }

    void ComboBarController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.combo += 1;
            this.innerComboBarAnim.SetTrigger("isNewCombo");

        }
        
        this.comboBar.SetActive(true);
        this.innerComboBarAnim.SetTrigger("isReduceCombo");

        if (this.innerComboBar.GetComponent<RectTransform>().rect.width <= 5)
        {
            this.combo = 1;
        }
        
        this.comboText.text = "x" + this.combo.ToString();
    }

    public void PlayHitFruitSound() {
        this.audioSource.PlayOneShot(this.hitFruit);
    }

    public void SetGameMode(string mode)
    {
        this.currentGameMode = mode;
        this.highestScore = PlayerPrefs.GetInt(mode, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (this.isGameStart)
        {
            if (this.timeLeft >= 0)
            {
                this.ComboBarController();
                this.timeLeft -= Time.deltaTime;
                this.timeLeftText.text = "Time Left: " + ((int)(this.timeLeft)).ToString();
                this.scoreText.text = "Score: " + this.score.ToString();

            } else {
                this.GameOver();
            }
        }
    }
}
