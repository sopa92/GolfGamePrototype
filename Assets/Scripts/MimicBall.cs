using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicBall : MonoBehaviour
{
    [SerializeField]
    private GameObject playerA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(-playerA.transform.position.x, playerA.transform.position.y, -playerA.transform.position.z);
    }
}
