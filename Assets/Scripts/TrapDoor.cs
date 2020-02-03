using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour {
    public Rigidbody leftDoor;
    public Rigidbody rightDoor;
    public bool itsATrap;
    TrapButton[] buttons;
    bool needsCoOp;
    [SerializeField]
    bool doorMustOpen;

    // Use this for initialization
    void Start () {
		leftDoor.useGravity = false;
		leftDoor.isKinematic = true;
		rightDoor.useGravity = false;
		rightDoor.isKinematic = true;
        needsCoOp = false;
        if (MultiplePlayersExist()) {
            buttons = GameObject.FindObjectsOfType<TrapButton>();
            if (MultipleButtonsExist()) {
                needsCoOp = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (needsCoOp) {
            this.GetComponent<BoxCollider>().enabled = false;
            bool doorMustOpen = true;
            foreach (TrapButton button in buttons)
            {
                if (!button.isActivated) {
                    doorMustOpen = false;
                }
            }
            if (doorMustOpen)
            {                
                leftDoor.useGravity = true;
                leftDoor.isKinematic = false;
                rightDoor.useGravity = true;
                rightDoor.isKinematic = false;
            }
            
        }
    } 

    bool MultipleButtonsExist()
    {
        if (buttons.Length > 1)
        {
            return true;
        }
        return false;
    }

    bool MultiplePlayersExist()
    {
        GameObject playerB = GameObject.FindGameObjectWithTag("PlayerB");
        if (playerB != null)
        {
            return true;
        }
        return false;
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
