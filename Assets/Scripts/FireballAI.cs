using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 15f * Time.deltaTime);

        if (transform.position.x > 5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            other.GetComponent<Rigidbody>().isKinematic = true;

            if (other.GetComponent<Ball>() != null)
                other.GetComponent<Ball>().isAlive = false;
            else
            {
                other.GetComponent<MimicBall>().isAlive = false;
            }
        }
    }
}
