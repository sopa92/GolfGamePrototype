using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCountdown : MonoBehaviour
{
    HitManager hitManager;
    Image countDownMeter;
    public float timeLeft;
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        hitManager = GameObject.FindObjectOfType<HitManager>();
        countDownMeter = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            if(!this.gameObject.GetComponent<AudioSource>().isPlaying)
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip, 5f);
            countDownMeter.fillAmount = (timeLeft / maxTime);
            timeLeft--;
            if(timeLeft==0)
            {
                hitManager.ResetForce();
                this.gameObject.GetComponent<AudioSource>().Stop();
            }
        }
    }

}
