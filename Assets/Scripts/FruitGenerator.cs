using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour {

	public GameObject carrot;
	public GameObject corn;
	public GameObject eggPlant;
	public GameObject pumpkin;
	public GameObject tomato;
    public GameObject turnip;
	public float spawnFreq;

    public GameController gameController;

	// Use this for initialization
	void Start () {
		// Call target function every 3 seconds
		InvokeRepeating("SpawnBook", this.spawnFreq, this.spawnFreq);
	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnBook()
	{
        if (this.gameController.isGameStart == true)
        {
            int fruitType = Random.Range(0, 6);
            switch (fruitType)
            {
                case 0: Instantiate(carrot); break;
                case 1: Instantiate(corn); break;
                case 2: Instantiate(eggPlant); break;
                case 3: Instantiate(pumpkin); break;
                case 4: Instantiate(tomato); break;
                case 5: Instantiate(turnip); break;
            }
        }
    }

}
