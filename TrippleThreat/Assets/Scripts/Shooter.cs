using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
	public Rigidbody bullet;
	public float bulletspeed=20;
	public Transform bulletSpawn;
	// Use this for initialization
	void Start () {
		bullet = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		while (true) {
			Rigidbody shoot = Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation)as Rigidbody;//instantiate bullets
			shoot.velocity = transform.TransformDirection(new Vector3(0f,bulletspeed,0f));//bullet velocity, magnitude and direction
			Destroy (bullet, 3.0f);//distroys bullet in 3 seconds
		}

	}
}
