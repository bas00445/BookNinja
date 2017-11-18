﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

	public GameController gameController;
    public Transform hitEffect;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "FruitTag")
        {
            this.gameController.PlayHitFruitSound();
            this.ShowHitEffect();

            Destroy(col.gameObject); // Remove the book when hand/foot touch with the book
            string fruitType = col.gameObject.GetComponent<FruitMotion>().fruitType;
            
            if(fruitType == "carrot") { this.gameController.score += 100 *this.gameController.combo; }
            if(fruitType == "corn") { this.gameController.score += 300 * this.gameController.combo; }
            if(fruitType == "eggPlant") { this.gameController.score += 200 * this.gameController.combo; }
            if(fruitType == "pumpkin") { this.gameController.score += 300 * this.gameController.combo; }
            if(fruitType == "tomato") { this.gameController.score += 200 * this.gameController.combo; }
            if(fruitType == "turnip") { this.gameController.score += 50 * this.gameController.combo; }

            this.gameController.combo += 1;
        }
    }

    private void ShowHitEffect()
    {
        this.hitEffect.transform.position = new Vector3(this.transform.position.x, 
                                                        this.transform.position.y,
                                                        this.transform.position.z - 1);
        Instantiate(this.hitEffect);
    }
		
}
