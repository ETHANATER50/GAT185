using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject spawn;
    [Range(1, 4)] public float spawnTimeMin = 2;
    [Range(4, 7)] public float spawnTimeMax = 5;

    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            spawnTimer -= Time.deltaTime;
        }


        if(spawnTimer <= 0)
        {
            spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
            Instantiate(spawn, transform.position, transform.rotation, transform);
        }
    }
}
