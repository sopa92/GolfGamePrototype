using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject _FireBallPrefab;
    [SerializeField]
    float z_position;
    //[SerializeField]
    //private GameObject[] powerups;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }
    public void StartSpawning()
    {
        StartCoroutine(FireballSpawn());
    }

    IEnumerator FireballSpawn()
    {
        while (true)
        {
            for(int i=0; i<=2; i++)
            {
                Instantiate(_FireBallPrefab, new Vector3(-5, Random.Range(2.5f, 3.5f), z_position), Quaternion.identity);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1.3f);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
    }
}
