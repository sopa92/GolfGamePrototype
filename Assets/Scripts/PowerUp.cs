using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    /*  0: Acceleration
        1: Transportation next to the hole
        2: Swap players' position
        3: Make ball extremely heavy */
    [SerializeField]
    private int _powerUpID = 0;

    [SerializeField]
    private AudioClip powerUpSoundClip;
    PowerUpCountdown countdownManager;
    HitManager hitManager;

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
                    hitManager.IncreaseForce();
                    StartCoroutine(SpeedCountDownRoutine());
                }
                else if (_powerUpID == 1)
                {
                    //Transport next to the end hole
                    golfBall.TransportToTheEnd();
                }
                else if (_powerUpID == 2)
                {
                    SwapPlayersPositions();
                }
            }
            
            //destroy the power up
            Destroy(this.gameObject);
        }
    }

    IEnumerator SpeedCountDownRoutine()
    {
        countdownManager.gameObject.SetActive(true);
        countdownManager.timeLeft = countdownManager.maxTime = 1500f;
        yield return new WaitForSeconds(countdownManager.timeLeft);
    }

    void SwapPlayersPositions()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            GameObject playerA = players[0];
            GameObject playerB = players[1];
            playerB.GetComponent<Rigidbody>().isKinematic = playerA.GetComponent<Rigidbody>().isKinematic = true;
            Vector3 tempPos = playerB.transform.position;
            playerB.transform.position = playerA.transform.position;
            playerA.transform.position = tempPos;
            playerB.GetComponent<Rigidbody>().isKinematic = playerA.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            Debug.Log("Only one player exists.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hitManager = GameObject.FindObjectOfType<HitManager>();
        countdownManager = GameObject.FindObjectOfType<PowerUpCountdown>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
