﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!this.gameObject.GetComponent<AudioSource>().isPlaying)
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip, 1f);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Ball golfBall = other.gameObject.GetComponent<Ball>();
            other.transform.position = golfBall != null ? golfBall.spawnPosition : new Vector3(0, 4, -13);

            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
