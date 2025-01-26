using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // Array of prefabs to spawn
    public GameObject[] objectPrefabs;
    public Transform[] spawnPoints;

    public float minDelay;
    public float maxDelay;

    public PlayerHP NotZero;

    public IEnumerator SpawnPrefabs()
    {
        // As long as the player's health is not zero, spawn prefabs at random spawnpoints
        while (NotZero.PlayerHealth > 0)
        {
            // Randomize the delay timer
            float delay = UnityEngine.Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // Random spawn point for random prefab
            int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnPointIndex];

            // Random prefab for random spawnpoint
            int prefabIndex = UnityEngine.Random.Range(0, objectPrefabs.Length);
            GameObject prefabToSpawn = objectPrefabs[prefabIndex];

            // Spawn random prefab at the random spawn point
            Stack<GameObject> spawnedObjects = new Stack<GameObject>();
            spawnedObjects.Push(Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation));

            if (spawnedObjects.Count() > 0)
            {
                for (int i = 0; i < spawnedObjects.Count(); i++)
                {
                    Destroy(spawnedObjects.Pop(), 5f);
                }
            }
        }
    }
}