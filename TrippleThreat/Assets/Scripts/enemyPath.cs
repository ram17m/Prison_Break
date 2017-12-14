//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPath : MonoBehaviour {
	public enemyPath nextNode;
	public Vector3 GetNextNodePosition(){
		return nextNode.GetPosition();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 GetPosition(){
		return transform.position;
	}

	void OnDrawGizmos(){//sketching a path using Gizmos attribute
		Gizmos.color = Color.white;
		Gizmos.DrawSphere (transform.position, 0.25f);
		if (nextNode != null) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine (GetPosition (), GetNextNodePosition ());
		}
	}

}
