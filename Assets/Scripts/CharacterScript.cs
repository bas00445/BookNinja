using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

	public GameController gameController;

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
            Destroy(col.gameObject); // Remove the book when hand/foot touch with the book
            string fruitType = col.gameObject.GetComponent<FruitMotion>().fruitType;
            
            if(fruitType == "carrot") { this.gameController.score += 100; }
            if(fruitType == "corn") { this.gameController.score += 300; }
            if(fruitType == "eggPlant") { this.gameController.score += 200; }
            if(fruitType == "pumpkin") { this.gameController.score += 300; }
            if(fruitType == "tomato") { this.gameController.score += 200; }
            if(fruitType == "turnip") { this.gameController.score += 50; }

            this.gameController.combo += 1;
        }
    }
		
}
