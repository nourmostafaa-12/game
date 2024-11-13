using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CubePrefab;
    public float spawnInterval = 2.0f;  // Interval for spawning cubes
    public float spawnRangeX = 10.0f;  // Range on the X-axis for random spawn position
    public float spawnRangeZ = 10.0f;  // Range on the Z-axis for random spawn position
    public float spawnHeight = 10.0f;  // Height at which cubes spawn

    void Start()
    {
        StartCoroutine(SpawnCubes());  // Start spawning cubes
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

            // Instantiate the cube at the random position
            GameObject cube = Instantiate(CubePrefab, randomPosition, Quaternion.identity);

            // Assign a random color to the cube (either purple or red)
            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            if (Random.Range(0, 2) == 0)  // Randomly pick either purple or red
            {
                cubeRenderer.material.color = Color.magenta;  // Purple
            }
            else
            {
                cubeRenderer.material.color = Color.red;  // Red
            }

            // Add a Rigidbody if it doesn't already exist
            if (cube.GetComponent<Rigidbody>() == null)
            {
                cube.AddComponent<Rigidbody>();
            }

            yield return new WaitForSeconds(spawnInterval);  // Wait before spawning the next cube
        }
    }
}
