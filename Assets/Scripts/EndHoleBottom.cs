using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndHoleBottom : MonoBehaviour
{
    public GameObject winningMessage;
    // Start is called before the first frame update
    void Start()
    {
        winningMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            winningMessage.SetActive(true);
        }
    }
}
