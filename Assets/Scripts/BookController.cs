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
		this.book.gameObject.transform.position = Vector3 (0.78, 8.692, -3.95);
        Instantiate(this.book);
    }
}
