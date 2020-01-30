using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody rigidBd;
    public Camera mainCamera;
    public int BonusPointsScore;

    [SerializeField]
    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        rigidBd = this.GetComponent<Rigidbody>();
        rigidBd.sleepThreshold = 0.8f;
        score.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCameraAlongTheBall();
        if (BonusPointsScore > 0) {
            //Debug.Log("Score" + BonusPointsScore);
            score.text = "Bonus Points: " + BonusPointsScore;
            score.enabled = true;
        }
    }

    public void TransportToTheEnd() {
        GameObject endHole = GameObject.FindObjectOfType<Endhole>().gameObject;
        this.transform.position = new Vector3(endHole.transform.position.x, endHole.transform.position.y + 3, endHole.transform.position.z - 2);
    }

    private void MoveCameraAlongTheBall() {
        if (transform.position.z > 0 && transform.position.x > 0)
        {
            mainCamera.transform.position = new Vector3(transform.position.x + 3f, transform.position.y + 5f, transform.position.z + 3f);
            mainCamera.transform.rotation = Quaternion.Euler(35f, -135, mainCamera.transform.rotation.z);
        }
        else if (transform.position.z > 0 && transform.position.x < -0)
        {
            mainCamera.transform.position = new Vector3(transform.position.x - 3f, transform.position.y + 5f, transform.position.z + 3f);
            mainCamera.transform.rotation = Quaternion.Euler(35f, 135, mainCamera.transform.rotation.z);
        }
        else if (transform.position.z < -0 && transform.position.x > 0)
        {
            mainCamera.transform.position = new Vector3(transform.position.x + 3f, transform.position.y + 5f, transform.position.z - 3f);
            mainCamera.transform.rotation = Quaternion.Euler(35f, -45, mainCamera.transform.rotation.z);
        }
        else if (transform.position.z < -0 && transform.position.x < -0)
        {
            mainCamera.transform.position = new Vector3(transform.position.x - 3f, transform.position.y + 5f, transform.position.z - 3f);
            mainCamera.transform.rotation = Quaternion.Euler(35f, 45, mainCamera.transform.rotation.z);
        }
    }


}
