using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform[] spawnPoints;

    public float minDelay;
    public float maxDelay;

    public PlayerHP NotZero;


    public IEnumerator SpawnPrefabs()
    {
        // As long as the player's health is not zero, spawn prefabs at random spawnpoints
        while (NotZero.PlayerHealth > 0)
        {
            float delay = UnityEngine.Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedObject, 5f);
        }

    }

}
