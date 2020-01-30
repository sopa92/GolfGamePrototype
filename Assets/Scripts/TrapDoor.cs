using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour {
public Rigidbody leftDoor;
public Rigidbody rightDoor;
public bool itsATrap;
	// Use this for initialization
	void Start () {
		leftDoor.useGravity = false;
		leftDoor.isKinematic = true;
		rightDoor.useGravity = false;
		rightDoor.isKinematic = true;
	}
	
	void OnTriggerEnter(Collider other)
	{
		 if (other.tag == "Player") {
			if (itsATrap) {
			leftDoor.useGravity = true;
			leftDoor.isKinematic = false;
			rightDoor.useGravity = true;
			rightDoor.isKinematic = false;
			}
		}
	}
}
