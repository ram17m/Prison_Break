﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision collision){
		if (collision.rigidbody.CompareTag ("enemy")) {
			Destroy (gameObject);
		}
	}
}
