using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    HitManager HitManager;
    Transform golfBallTrans;
    // Start is called before the first frame update
    void Start()
    {
        HitManager = GameObject.FindObjectOfType<HitManager>();
        Ball[] golfBalls = GameObject.FindObjectsOfType<Ball>();
        foreach (var golfBall in golfBalls) {
            if (!golfBall.isMimicBall) {
                golfBallTrans = golfBall.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = golfBallTrans.position;
        this.transform.rotation = Quaternion.Euler(0, HitManager.DirAngle, 0);        
    }

}
