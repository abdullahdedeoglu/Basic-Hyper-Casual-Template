using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public Transform[] pos;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 4f, 4f);
    }

    public void SpawnObstacle()
    {
        Instantiate(obstacle, pos[Random.Range(0, pos.Length)].position, Quaternion.identity);
    }
}
