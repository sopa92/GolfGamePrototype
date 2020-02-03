using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapButton : MonoBehaviour
{
    public bool isActivated;
    Animator anim;
    AudioSource audioSrc;
    AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        anim = this.GetComponent<Animator>();
        audioSrc = this.GetComponent<AudioSource>();
        audioClip = audioSrc.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerB")
        {
            anim.SetBool("ballCollides", true);
            isActivated = true;
            audioSrc.loop = false;
            audioSrc.PlayOneShot(audioClip, 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("ballCollides", false);
        }
    }
}
