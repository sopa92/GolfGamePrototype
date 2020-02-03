using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;        //Public variable to store a reference to the player game object    
    [SerializeField]
    List<GameObject> camPositions;
    
    void Start()
    {

    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        MoveCameraAlongTheBall();        
    }
    
    private void MoveCameraAlongTheBall()
    {
        Vector3 playerPos = player.transform.position;
        float minDistance = Vector3.Distance(playerPos, camPositions[0].transform.position);
        Vector3 nextPos = camPositions[0].transform.position;
        foreach (GameObject camPosition in camPositions) {
            float distFromCamPos = Vector3.Distance(playerPos, camPosition.transform.position);
            if (distFromCamPos <= minDistance) {
                minDistance = distFromCamPos;
                nextPos = camPosition.transform.position;
            }
        }
        transform.position = Vector3.Lerp(transform.position, nextPos, Time.deltaTime);
        transform.LookAt(player.transform);

    }
}
