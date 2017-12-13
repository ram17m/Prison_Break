using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
	public Rigidbody bullet;
	public Rigidbody2D Player;
	public float speed;
	// Use this for initialization
	void Start () {
		Player = GetComponent<Rigidbody2D> ();
		bullet = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		attack ();
	}
	void attack ()
	{
		//
	}
}
