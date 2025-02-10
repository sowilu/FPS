using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public Transform[] spawnPoints;
    public Vector2 spawnTimeRange = new Vector2(3f, 6f);
    
    public bool spawnEndless = false;
    public int count = 100;
    
    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        while (spawnEndless || count > 0)
        {
            var zombie = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
            Instantiate(zombie, spawnPoint.position, Quaternion.identity);
            
            count--;
            
            yield return new WaitForSeconds(Random.Range(spawnTimeRange.x, spawnTimeRange.y));
        }
    }
}
