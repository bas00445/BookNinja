using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMotion : MonoBehaviour {
	
	private bool isRotate;
	private Rigidbody bookRb;
	private Animator animator;

	public float thrust; 

	// Use this for initialization	
	void Start () {
		this.isRotate = true;
		this.bookRb = GetComponent<Rigidbody> ();
		this.animator = GetComponent<Animator> ();

		int side = Random.Range (1, 3);
		float zAxis = Random.Range (-2.5f, -3.7f);

		if (side == 1) {
			float xAxis = Random.Range (-2.5f, 0f);

			// Set a new random position to the book object
			this.transform.position = new Vector3(xAxis, 1f, zAxis);
			this.bookRb.AddForce (this.thrust / 3, this.thrust, 0, ForceMode.Acceleration);

		} else if (side == 2) {
			float xAxis = Random.Range (0f, 2.5f);
			// Set a new random position to the book object
			this.transform.position = new Vector3(xAxis, 1f, zAxis);
			this.bookRb.AddForce (-this.thrust / 3, this.thrust, 0, ForceMode.Acceleration);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate the book while floating
		if (this.isRotate == true) {
			transform.Rotate (Time.deltaTime * 50, Time.deltaTime * 50, Time.deltaTime * 50);
			// deltaTime = Current time started when this object is initialized
		}
	}

	void FixedUpdate() {
		
	}

	void OnCollisionEnter(Collision col)
	{	
		if (col.gameObject.name == "Floor")
		{
			this.isRotate = false;
			Invoke ("RemoveBook", 4f); // Call RemoveBook funtion after 2 seconds
		}
	}

	void RemoveBook() {
		this.animator.SetTrigger ("isFloor");
		Destroy (this.gameObject, 0.8f); // Remove this object from the game
	}
}
