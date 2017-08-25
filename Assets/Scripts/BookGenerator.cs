using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGenerator : MonoBehaviour {

	public GameObject book;
	public float spawnTime;

	// Use this for initialization
	void Start () {
		// Call target function every 3 seconds
		InvokeRepeating("SpawnBook", this.spawnTime, this.spawnTime);
	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnBook()
	{
		Instantiate(book); // Clone a new book object
	}

}
