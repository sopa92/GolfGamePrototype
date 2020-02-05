using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, transform.position.y, 0) * 0.3f *  Time.deltaTime);

        if (transform.position.y > transform.parent.position.y + 2.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
