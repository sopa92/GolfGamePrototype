using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    /*  0: Acceleration
        1: Transportation next to the hole
        2: Swap players' position
        3: Make ball extremely heavy
        4: Bouncing Ball
        5: Hatch and buttons appear */
    [SerializeField]
    private int _powerUpID = 0;

    [SerializeField]
    private AudioClip powerUpSoundClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //access the player
            Ball golfBall = other.GetComponent<Ball>();
            if (golfBall != null)
            {
                if (_powerUpID == 0)
                {
                    //Increase force limit
                    HitManager hitManager = GameObject.FindObjectOfType<HitManager>();
                    hitManager.MaxForce = 50f;
                    hitManager.ForceFillingSpeed = 40f;
                }
                else if (_powerUpID == 1)
                {
                    //Transport next to the end hole
                    golfBall.TransportToTheEnd();
                }
            }
            
            //destroy the power up
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
