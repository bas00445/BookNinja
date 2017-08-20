using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMotion : MonoBehaviour {
	
	private bool isRotate;

	// Use this for initialization	
	void Start () {
		this.isRotate = true;
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate the book while floating
		if (this.isRotate == true) {
			transform.Rotate (Time.deltaTime * 50, Time.deltaTime * 50, Time.deltaTime * 50);
			// deltaTime = Current time started when this object is initialized
		}
	}

	void OnCollisionEnter(Collision col)
	{	
		if (col.gameObject.name == "Floor")
		{
			this.isRotate = false;
			Invoke ("RemoveBook", 2f); // Call RemoveBook funtion after 2 seconds
		}
	}

	void RemoveBook() {
		Destroy (this.gameObject); // Remove this object from the game
	}
}
