using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private GameObject _RingPrefab;
    [SerializeField]
    private bool IsReceiverPort;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RingsSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator RingsSpawn()
    {
        while (true)
        {
            for (int i = 0; i <= 2; i++)
            {
                var newRing = Instantiate(_RingPrefab, new Vector3(transform.position.x, transform.position.y - (i * 0.23f), transform.position.z), Quaternion.identity);
                newRing.transform.parent = gameObject.transform.Find("Teleporter base").gameObject.transform;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Teleporter otherTeleporter = GetTheOtherTeleporter();
            if (otherTeleporter.IsReceiverPort)
            {
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.position = new Vector3(otherTeleporter.transform.position.x, otherTeleporter.transform.position.y + 1, otherTeleporter.transform.position.z);
                other.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    private Teleporter GetTheOtherTeleporter()
    {
        var teleporters = GameObject.FindObjectsOfType<Teleporter>();
        if (teleporters != null)
        {
            foreach (var teleporter in teleporters)
            {
                if (teleporter.gameObject != this.gameObject)
                {
                    return teleporter;
                }
            }
        }
        return null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsReceiverPort = false;
            Teleporter otherTeleporter = GetTheOtherTeleporter();
            otherTeleporter.IsReceiverPort = true;
                        
        }
    }
}
