using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{

    Rigidbody golfBallRb;
    GameObject arrow;
    public float DirAngle { get; protected set; }
    public float HitForce { get; protected set; }

    public float MaxForce;
    public float MinForce;

    public float ForceFillingSpeed;
    int fillDirection = 1;

    public enum HitStateEnum {
        READYTOHIT,
        AIMING,
        FORCE,
        ROLLING
    };
    public HitStateEnum HitState { get; protected set; }
    // Start is called before the first frame update
    void Start()
    {
        ResetForce();
        FindGolfBall();
        arrow = GameObject.FindObjectOfType<DirectionIndicator>().gameObject;
    }

    void FindGolfBall() {
        GameObject golfBall = GameObject.FindGameObjectWithTag("Player");

        if (golfBall == null) {
            Debug.LogError("Couldn't find the golf ball");
        }
        golfBallRb = golfBall.GetComponent<Rigidbody>();

        if (golfBallRb == null) {
            Debug.LogError("Golf ball has no rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HitState == HitStateEnum.AIMING)
        {
            arrow.SetActive(true);
            DirAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;
            //Debug.Log(HitState);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                HitState = HitStateEnum.FORCE;
                return;
            }
        }
        else {            
            arrow.SetActive(false);
        }
        
        if (HitState == HitStateEnum.FORCE)
        {
            //Debug.Log(HitState);
            HitForce += (ForceFillingSpeed * fillDirection) * Time.deltaTime;
            if (HitForce > MaxForce)
            {
                HitForce = MaxForce;
                fillDirection = -1;
            }

            if (MinForce > 0 && HitForce < MinForce)
            {
                HitForce = MinForce;
                fillDirection = 1;
            }
            else
            {
                if (HitForce < 0)
                {
                    HitForce = 0;
                    fillDirection = 1;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                HitState = HitStateEnum.READYTOHIT;
                //Debug.Log(HitState);
            }
            
        }
    }

    public void IncreaseForce() {
        MaxForce = 50f;
        ForceFillingSpeed = 40f;
        MinForce = 30f;
    }

    public void ResetForce()
    {
        MaxForce = 30f;
        ForceFillingSpeed = 20f;
        HitForce = MinForce = 0f;
    }

    void CheckForMoving() {
        //Debug.Log(golfBallRb.velocity);
        if (golfBallRb.IsSleeping()) {
            HitState = HitStateEnum.AIMING;
        }
    }

    //FixedUpdate runs on every tick of the physics engine
    void FixedUpdate()
    {
        if (golfBallRb == null)
        {
            return;
        }

        if (HitState != HitStateEnum.READYTOHIT)
        {
            if (HitState == HitStateEnum.ROLLING)
            {                
                CheckForMoving();   //wait to stop
            }
            return;
        }


        Vector3 forceVec = new Vector3(0, 0, HitForce);
        golfBallRb.AddForce(Quaternion.Euler(0, DirAngle, 0) * forceVec, ForceMode.Impulse);

        HitForce = MinForce>0 ? MinForce : 0;
        fillDirection = 1;
        HitState = HitStateEnum.ROLLING;
    }
}
