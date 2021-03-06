﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour {
    public Rigidbody leftDoor;
    public Rigidbody rightDoor;
    public bool itsATrap;
    TrapButton[] buttons;
    bool needsCoOp;
    public bool doorMustOpen;

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
                itsATrap = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (needsCoOp)
        {
            doorMustOpen = true;
            foreach (TrapButton button in buttons)
            {
                if (!button.isActivated)
                {
                    doorMustOpen = false;
                }
            }
            if (doorMustOpen)
            {
                if (!this.gameObject.GetComponent<AudioSource>().isPlaying)
                    this.gameObject.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip, 1f);
                needsCoOp = false;
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
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length>1)
        {
            return true;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player")
        {
            if (itsATrap)
            {
                leftDoor.useGravity = true;
                leftDoor.isKinematic = false;
                rightDoor.useGravity = true;
                rightDoor.isKinematic = false;
            }
        }
	}
}
