﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject _FireBallPrefab;
    [SerializeField]
    float zPositionFireball;
    [SerializeField]
    private GameObject _GrassObstaclePrefab;
    [SerializeField]
    float zPositionGrassObstacle;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }
    public void StartSpawning()
    {
        StartCoroutine(FireballSpawn());
        GenerateGrassObstacles();
    }

    IEnumerator FireballSpawn()
    {
        while (true)
        {
            for(int i=0; i<=2; i++)
            {
                Instantiate(_FireBallPrefab, new Vector3(-5, transform.position.y + Random.Range(-0.5f, 1.5f), zPositionFireball), Quaternion.identity);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1.3f);
        }
        
    }

    void GenerateGrassObstacles() {
        Instantiate(_GrassObstaclePrefab, new Vector3(-3, transform.position.y + 0.53f, zPositionGrassObstacle), Quaternion.identity);
        Instantiate(_GrassObstaclePrefab, new Vector3(3, transform.position.y + 0.53f, zPositionGrassObstacle - Random.Range(1.5f, 2.5f)), Quaternion.identity);
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
