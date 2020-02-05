using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicBall : MonoBehaviour
{
    [SerializeField]
    private GameObject playerA;
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
            this.transform.position = new Vector3(-playerA.transform.position.x, playerA.transform.position.y, -playerA.transform.position.z);
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
