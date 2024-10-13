using System.Collections;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab; // Drag your "note" prefab here
    public Transform[] spawnPoints; // Drag your lane positions here (e.g., Lane1, Lane2, Lane3)
    public float spawnInterval = 1f; // Adjust the time interval between notes

    void Start()
    {
        // Start spawning notes at regular intervals
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        while (true)
        {
            if (spawnPoints.Length > 0) // Ensure the array has elements
            {
                // Choose a random spawn point from the array of spawn points
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Instantiate a note at the random spawn point
                Instantiate(notePrefab, randomSpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("No spawn points assigned!");
            }

            // Wait for the next spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }


}
