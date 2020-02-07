using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Rigidbody rigidBd;
    public Camera mainCamera;
    public int BonusPointsScore;
    public Vector3 spawnPosition;
    public bool isAlive;

    [SerializeField]
    public bool isMimicBall;
    [SerializeField]
    private Text score;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        rigidBd = this.GetComponent<Rigidbody>();
        rigidBd.sleepThreshold = 0.8f;
        score.enabled = false;
        spawnPosition = transform.position;
        isAlive = true;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMimicBall)
        {
            if (BonusPointsScore > 0)
            {
                score.text = "Bonus Points: " + BonusPointsScore;
                score.enabled = true;
            }
            if (!isAlive)
            {
                Invoke("LoadScene", 2);
            }
        }
        else {
            if (isAlive)
            {
                Ball playerA = GetTheOtherBall();
                this.transform.position = new Vector3(-playerA.transform.position.x, playerA.transform.position.y, -playerA.transform.position.z);
            }
            else
            {
                var hatch = GameObject.FindObjectOfType<TrapDoor>();
                if (hatch.doorMustOpen == false)
                {
                    hatch.itsATrap = true;
                    var buttons = GameObject.FindObjectsOfType<TrapButton>();
                    foreach (var button in buttons)
                    {
                        Destroy(button.transform.parent.gameObject);
                    }
                }
            }
        }
    }

    private Ball GetTheOtherBall()
    {
        var golfballs = GameObject.FindObjectsOfType<Ball>();
        if (golfballs != null)
        {
            foreach (var golfball in golfballs)
            {
                if (golfball.gameObject != this.gameObject)
                {
                    return golfball;
                }
            }
        }
        return null;
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void TransportToTheEnd()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        GameObject endHole = GameObject.FindObjectOfType<Endhole>().gameObject;
        this.transform.position = new Vector3(endHole.transform.position.x, endHole.transform.position.y + 3, endHole.transform.position.z + Random.Range(-1.5f, 1.5f));
        this.GetComponent<Rigidbody>().isKinematic = false;
    }
       
}
