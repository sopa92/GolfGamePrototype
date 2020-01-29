using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endhole : MonoBehaviour
{
    public int LayerForEnter;
    public int LayerForExit;

    // Update is called once per frame
    void Update()  {  }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            other.gameObject.layer = LayerForEnter;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = LayerForExit;
        }
    }
}
