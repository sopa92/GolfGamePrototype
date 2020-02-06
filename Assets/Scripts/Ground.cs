using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    enum GroundType { STICKY, SEMI_STICKY, SLIPPERY, SEMI_SLIPPERY, NORMAL }
    [SerializeField]
    private GroundType groundType;
    private Rigidbody golfBallRb;
    private float initialDrag;
    private float initialMass;

    // Start is called before the first frame update
    void Start()
    {
        initialDrag = 0.5f;
        initialMass = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            golfBallRb = other.gameObject.GetComponent<Rigidbody>();
            if (groundType == GroundType.SLIPPERY)
            {
                golfBallRb.drag = golfBallRb.angularDrag = 0;
                golfBallRb.mass = initialMass;
            }
            else if (groundType == GroundType.SEMI_SLIPPERY)
            {
                golfBallRb.drag = golfBallRb.angularDrag = 0.3f;
                golfBallRb.mass = initialMass;
            }
            else if (groundType == GroundType.STICKY)
            {
                golfBallRb.drag = golfBallRb.angularDrag = 1;
                golfBallRb.mass = 2f;
            }
            else if (groundType == GroundType.SEMI_STICKY)
            {
                golfBallRb.drag = golfBallRb.angularDrag = 0.8f;
                golfBallRb.mass = 1.5f;
            }
            else
            {
                golfBallRb.drag = golfBallRb.angularDrag = initialDrag;
                golfBallRb.mass = initialMass;
            }
        }
    }

}
