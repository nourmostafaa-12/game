using System.Collections;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject CubePrefab;
    public float spawnInterval = 2.0f; // Interval for spawning cubes
    public float spawnRangeX = 10.0f; // Range on the X-axis for random spawn position
    public float spawnRangeZ = 10.0f; // Range on the Z-axis for random spawn position
    public float spawnHeight = 10.0f; // Height at which cubes spawn

    void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    IEnumerator SpawnCubes()
    {
        while (true)
        {
            // Generate a random spawn position within specified ranges
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX), 
                spawnHeight, 
                Random.Range(-spawnRangeZ, spawnRangeZ)
            );

            // Instantiate the cube at the random position with a Rigidbody for gravity
            GameObject cube = Instantiate(CubePrefab, randomPosition, Quaternion.identity);

            if (cube.GetComponent<Rigidbody>() == null)
            {
                cube.AddComponent<Rigidbody>(); // Add Rigidbody if it doesn't already exist
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
