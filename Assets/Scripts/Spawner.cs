using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public Vector2 cooldownRange = new Vector2(3, 6);
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            var enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(cooldownRange.x, cooldownRange.y));
        }
    }
}
