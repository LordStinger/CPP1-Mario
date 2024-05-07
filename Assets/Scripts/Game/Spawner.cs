using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    // Define a list of spawn locations
    private List<Transform> spawnPoints = new List<Transform>();

    // Define a list of predefined objects
    public List<GameObject> predefinedObjects;

    private void Start()
    {
        // Find all spawn points in the scene and add them to the list
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach (var spawnPointObject in spawnPointObjects)
        {
            spawnPoints.Add(spawnPointObject.transform);
        }

        // Randomly spawn objects at spawn locations
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        if (spawnPoints.Count == 0 || predefinedObjects.Count == 0)
        {
            Debug.LogWarning("No spawn points or predefined objects available.");
            return;
        }

        // Randomly select a spawn point and object
        System.Random random = new System.Random();
        foreach (var spawnPoint in spawnPoints)
        {
            int randomIndex = random.Next(0, predefinedObjects.Count);
            GameObject spawnedObject = Instantiate(predefinedObjects[randomIndex], spawnPoint.position, Quaternion.identity);
            Debug.Log($"Object {spawnedObject.name} spawned at location {spawnPoint.position}");
        }
    }
}
