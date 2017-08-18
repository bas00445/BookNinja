using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour {

    public GameObject book;
    public float spawnTime = 3f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnBook", this.spawnTime, this.spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnBook()
    {
		GameObject newBook = book;
		newBook.gameObject.transform.position = new Vector3(0.78f, 8.692f, -3.95f);
        Instantiate(newBook);
    }
}
