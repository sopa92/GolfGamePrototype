﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigidBd;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        rigidBd = this.GetComponent<Rigidbody>();
        rigidBd.sleepThreshold = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCameraAlongTheBall();
    }

    public void TransportToTheEnd() {
        GameObject endHole = GameObject.FindObjectOfType<Endhole>().gameObject;
        this.transform.position = new Vector3(endHole.transform.position.x, endHole.transform.position.y + 3, endHole.transform.position.z - 2);
    }

    private void MoveCameraAlongTheBall() {
        if (transform.position.z > 0 && transform.position.x > 0)
        {
            camera.transform.position = new Vector3(transform.position.x + 3f, transform.position.y + 5f, transform.position.z + 3f);
            camera.transform.rotation = Quaternion.Euler(35f, -135, camera.transform.rotation.z);
        }
        else if (transform.position.z > 0 && transform.position.x < -0)
        {
            camera.transform.position = new Vector3(transform.position.x - 3f, transform.position.y + 5f, transform.position.z + 3f);
            camera.transform.rotation = Quaternion.Euler(35f, 135, camera.transform.rotation.z);
        }
        else if (transform.position.z < -0 && transform.position.x > 0)
        {
            camera.transform.position = new Vector3(transform.position.x + 3f, transform.position.y + 5f, transform.position.z - 3f);
            camera.transform.rotation = Quaternion.Euler(35f, -45, camera.transform.rotation.z);
        }
        else if (transform.position.z < -0 && transform.position.x < -0)
        {
            camera.transform.position = new Vector3(transform.position.x - 3f, transform.position.y + 5f, transform.position.z - 3f);
            camera.transform.rotation = Quaternion.Euler(35f, 45, camera.transform.rotation.z);
        }
    }


}