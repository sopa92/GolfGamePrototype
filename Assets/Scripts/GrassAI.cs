using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassAI : MonoBehaviour
{
    int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Vector3.right * 4f * Time.deltaTime);

        if (transform.position.x > 3f)
        {
            direction = -1;
        }
        if (transform.position.x < -3f)
        {
            direction = 1;
        }
    }
}
