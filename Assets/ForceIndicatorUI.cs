using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceIndicatorUI : MonoBehaviour
{
    HitManager HitManager;
    Image forceImg;
    // Start is called before the first frame update
    void Start()
    {
        HitManager = GameObject.FindObjectOfType<HitManager>();
        forceImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        forceImg.fillAmount = HitManager.HitForce/HitManager.MaxForce;
    }
}
