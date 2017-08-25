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
        if (col.gameObject.tag == "BookTag")
        {
            Destroy(col.gameObject); // Remove the book when hand/foot touch with the book
			this.gameController.score += 1;
        }
    }
		
}
