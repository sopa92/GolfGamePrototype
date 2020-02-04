using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HitManager = GameObject.FindObjectOfType<HitManager>();
        golfBallTrans = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    HitManager HitManager;
    Transform golfBallTrans;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = golfBallTrans.position;
        this.transform.rotation = Quaternion.Euler(0, HitManager.DirAngle, 0);        
    }

}
