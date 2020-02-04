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
    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        rigidBd = this.GetComponent<Rigidbody>();
        rigidBd.sleepThreshold = 0.8f;
        score.enabled = false;
        spawnPosition = transform.position;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
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

    void LoadScene()
    {
        SceneManager.LoadScene("Level2");
    }

    public void TransportToTheEnd()
    {
        GameObject endHole = GameObject.FindObjectOfType<Endhole>().gameObject;
        this.transform.position = new Vector3(endHole.transform.position.x, endHole.transform.position.y + 3, endHole.transform.position.z - 2);
    }
       
}
