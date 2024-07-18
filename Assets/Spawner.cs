using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject bigAsteroid;
    [SerializeField] private float spawnRate;
    private float m_SpawnTime;
    private float cameraTopBound;
    private float cameraBottomBound;
    private float cameraLeftBound;
    private float cameraRightBound;
    private int randomBound;

    private void Start()
    {
        cameraLeftBound = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect);
        cameraRightBound = Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect);
        cameraBottomBound = Camera.main.transform.position.y - Camera.main.orthographicSize;
        cameraTopBound = Camera.main.transform.position.y + Camera.main.orthographicSize;
        
    }

    private void Update()
    {
        if (spawnRate < m_SpawnTime)
        {
            SpawnAsteroid();
            m_SpawnTime = 0;
        }
        m_SpawnTime += Time.deltaTime;
        
    }

    private void SpawnAsteroid()
    {
        randomBound = Random.Range(0, 4);
        Vector3 spawnPosition = Vector3.zero;
        if (randomBound == 0) // Left side
            spawnPosition = new Vector3(cameraLeftBound, Random.Range(cameraBottomBound, cameraTopBound), 0f);
        else if (randomBound == 1) // Right side
            spawnPosition = new Vector3(cameraRightBound, Random.Range(cameraBottomBound, cameraTopBound), 0f);
        else if (randomBound == 2) // Bottom side
            spawnPosition = new Vector3(Random.Range(cameraLeftBound, cameraRightBound), cameraBottomBound, 0f);
        else if (randomBound == 3) // Top side
            spawnPosition = new Vector3(Random.Range(cameraLeftBound, cameraRightBound), cameraTopBound, 0f);

        Instantiate(bigAsteroid,spawnPosition, Quaternion.identity);
    }
}
