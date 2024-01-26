using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketManager : MonoBehaviour
{
    public GameObject basket;

    public int numOfPrefebs = 0;
    public int maxNumOfPrefebs = 3;

    public float spawnRadius = 10f;
    public float minSpawnDelay = 1f; // 最小生成延迟
    public float maxSpawnDelay = 5f; // 最大生成延迟
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPrefabs", 0f, Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    void SpawnPrefabs()
    {
        CountPrefabs();
        if (numOfPrefebs < maxNumOfPrefebs)
        {
            Vector3 randomPosition = GetRandomPosition();
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            GameObject newPrefab = Instantiate(basket, randomPosition, randomRotation);
        }
    }
    
    void CountPrefabs()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        numOfPrefebs = 0;
        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag(basket.tag))
            {
                numOfPrefebs++;
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-spawnRadius, spawnRadius);
        float randomZ = Random.Range(-spawnRadius, spawnRadius);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ) + transform.position;
        return randomPosition;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
