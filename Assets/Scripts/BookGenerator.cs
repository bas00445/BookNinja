using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGenerator : MonoBehaviour {

	public GameObject book;
	public Rigidbody bookRb;
	public float spawnTime = 3f;
	public float thrust  = 30f;
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
		float xAxis = Random.Range (-2.5f, 2.5f);
		float zAxis = Random.Range (-2.5f, -3.7f);

		// Set a new random position to the book object
		book.gameObject.transform.position = new Vector3(xAxis, 0.5f, zAxis);
		this.bookRb.AddForce (this.thrust, this.thrust, 0, ForceMode.Impulse);
		Instantiate(book); // Clone a new book object
	}

}
