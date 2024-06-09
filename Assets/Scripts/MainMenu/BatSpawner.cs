using UnityEngine;
using System.Collections;

public class BatSpawner : MonoBehaviour
{
    [SerializeField] private Transform batSpawner;
    [SerializeField] private GameObject batPrefab;
    public float timebetweenSpawns = 5f;
    public bool canSpawn = true;
    private void Start()
    {
        StartCoroutine(SpawnBats());
    }

    IEnumerator SpawnBats()
    {
        while (canSpawn)
        {
            var randomBatSize = Random.Range(0.1f, 1f);
            
            // Instantiate a new bat at the spawner's position and with no rotation
            GameObject newBat = Instantiate(batPrefab, batSpawner.position, Quaternion.identity);
            
            // Set the bat's size
            newBat.transform.localScale = new Vector3(randomBatSize, randomBatSize, randomBatSize);
            
            // Wait for the specified time before spawning the next bat
            yield return new WaitForSeconds(timebetweenSpawns);
            
        }
    }
}