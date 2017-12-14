using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public enemyPath startnode;
	public float speed;
	public GameObject target;
	private float range=10f;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		//checking if the target is in range
		if (Vector3.Distance (transform.position, target.transform.position) > range) {
			patrol ();
		} else {
			chase ();
		}
	}

	void patrol(){


		//checking distance from objects current position to the next node.	
		if (Vector3.Distance (transform.position, startnode.GetPosition()) < 0.5f) {
			startnode = startnode.nextNode;//setting up next 
			transform.position = Vector3.MoveTowards (transform.position, startnode.GetPosition (), speed * Time.deltaTime);//movement
		} else {
			
			transform.position = Vector3.MoveTowards (transform.position, startnode.GetPosition(), speed * Time.deltaTime);	

		}


	}


	void chase(){
		
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);

	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.rigidbody.tag=="bullet") {
			Destroy (gameObject);
		}
	}
}
