using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxYpos;
    public float spawnTime;
    public GameObject pipe;

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPipe", 0.2f, spawnTime);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnPipe");
    }
    void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-maxYpos, maxYpos), 0f), Quaternion.identity);
    }
}
