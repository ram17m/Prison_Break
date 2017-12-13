using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroll : MonoBehaviour {
	private Rigidbody2D bullet;
	public Vector2 speed; 
	// Use this for initialization
	void Start () {
		bullet = GetComponent<Rigidbody2D> ();
		bullet.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {

		bullet.velocity = speed;
		if (Time.frameCount > 10) {
			Destroy (this.gameObject);
		}
	}
}
