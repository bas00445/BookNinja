using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour {

    public float lifetime = 4f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, this.lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
