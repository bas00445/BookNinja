using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMotion : MonoBehaviour {
	
	private bool isRotate;
    private bool hitFloor;
	private Rigidbody bookRb;
	private Animator animator;

    private GameController gameController;

	public float thrust;
    public float minDistance = -3.6f;
    public float maxDistance = -4.5f;
    public string fruitType;


	// Use this for initialization	
	void Start () {
        this.hitFloor = false;
		this.isRotate = true;
		this.bookRb = GetComponent<Rigidbody> ();
		this.animator = GetComponent<Animator> ();
        this.gameController = GameObject.Find("GameController").GetComponent<GameController>();


        Physics.gravity = new Vector3(0, -0.9f, 0);

		int side = Random.Range (1, 3);
		float zAxis = Random.Range (minDistance, maxDistance);

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
			this.transform.Rotate (Time.deltaTime * 50, Time.deltaTime * 50, Time.deltaTime * 50);
			// deltaTime = Current time started when this object is initialized

            if (this.transform.position.y > 3.15) // The fruits reach to the highest pont
            {
                Physics.gravity = new Vector3(0, -1.5f, 0);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }

    void OnCollisionEnter(Collision col)
	{	
		if (col.gameObject.name == "Terrain" && this.hitFloor == false)
		{
            this.hitFloor = true;
            this.isRotate = false;
            this.gameController.combo = 1;
			Invoke ("RemoveFruit", 2f); // Call RemoveBook funtion after 2 seconds
		}
	}

	void RemoveFruit() {
		this.animator.SetTrigger ("isFloor");
		Destroy (this.gameObject, 0.8f); // Remove this object from the game
	}
}
