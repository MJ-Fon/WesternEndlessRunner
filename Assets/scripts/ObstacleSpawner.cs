using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] Obstacles;
    public GameObject Coin;

    [Header("Spawn Settings")]
    public float minX;
    public float maxX;
    public float spawnY = 10f;

    [Header("Difficulty Settings")]
    public float startSpawnDelay = 2f;
    public float minSpawnDelay = 0.5f;
    public float difficultyRampUp = 60f;

    private float nextSpawnTime;

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime)
        {
            SpawnPattern();

            // scale difficulty over time
            float t = Mathf.Clamp01(Time.timeSinceLevelLoad / difficultyRampUp);
            float currentDelay = Mathf.Lerp(startSpawnDelay, minSpawnDelay, t);

            nextSpawnTime = Time.timeSinceLevelLoad + currentDelay;
        }
    }

    void SpawnPattern()
    {
        int patternType = Random.Range(0, 3); // 0=single obstacle, 1=row of coins, 2=obstacle+coins gap

        switch (patternType)
        {
            case 0: SpawnSingleObstacle(); break;
            case 1: SpawnCoinRow(); break;
            case 2: SpawnGapWithCoins(); break;
        }
    }

    void SpawnSingleObstacle()
    {
        float x = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(x, transform.position.y + spawnY, 0);

        GameObject prefab = Obstacles[Random.Range(0, Obstacles.Length)];
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    void SpawnCoinRow()
    {
        float x = Random.Range(minX, maxX);
        int length = Random.Range(3, 7); // number of coins in the row

        for (int i = 0; i < length; i++)
        {
            Vector3 spawnPos = new Vector3(x, transform.position.y + spawnY + (i * 1.5f), 0);
            Instantiate(Coin, spawnPos, Quaternion.identity);
        }
    }

    void SpawnGapWithCoins()
    {
        // Two obstacles with a coin trail in between
        float gapX = Random.Range(minX + 2f, maxX - 2f);

        Vector3 leftPos = new Vector3(minX, transform.position.y + spawnY, 0);
        Vector3 rightPos = new Vector3(maxX, transform.position.y + spawnY, 0);

        Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], leftPos, Quaternion.identity);
        Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], rightPos, Quaternion.identity);

        for (int i = -1; i <= 1; i++)
        {
            Vector3 coinPos = new Vector3(gapX + i, transform.position.y + spawnY, 0);
            Instantiate(Coin, coinPos, Quaternion.identity);
        }
    }
    /*
    [Header("Prefabs")]
    public GameObject[] Obstacles;
    public GameObject Coin;

    [Header("Spawn Settings")]
    public float minX;
    public float maxX;
    public float spawnY = 10f;

    [Header("Difficulty Settings")]
    public float startSpawnDelay = 2f;   // initial seconds between spawns
    public float minSpawnDelay = 0.5f;   // cap for how fast spawns can get
    public float difficultyRampUp = 60f; // seconds until max difficulty

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnObject();

            // Spawn rate difficulty
            float t = Mathf.Clamp01(Time.time / difficultyRampUp);
            float currentDelay = Mathf.Lerp(startSpawnDelay, minSpawnDelay, t);

            nextSpawnTime = Time.time + currentDelay;
        }
    }

    void SpawnObject()
    {
        float x = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(x, transform.position.y + spawnY, 0);

        // Coin chance decreases over time
        float coinChance = Mathf.Lerp(0.3f, 0.1f, Time.time / difficultyRampUp);

        GameObject prefabToSpawn;
        if (Random.value < coinChance)
        {
            prefabToSpawn = Coin;
        }
        else
        {
            prefabToSpawn = Obstacles[Random.Range(0, Obstacles.Length)];
        }

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }


    /*
    [Header("Prefabs")]
    public GameObject[] Obstacles;  // drag both obstacle prefabs here
    public GameObject Coin;         // drag your coin prefab here

    [Header("Spawn Settings")]
    public float minX;
    public float maxX;
    public float spawnY = 10f;          // how far above camera we spawn
    public float timeBetweenSpawn = 2f;
    private float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnObject()
    {
        float x = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(x, transform.position.y + spawnY, 0);

        GameObject prefabToSpawn;

        // 25% chance coin, 75% chance obstacle
        if (Random.value < 0.25f)
        {
            prefabToSpawn = Coin;
        }
        else
        {
            prefabToSpawn = Obstacles[Random.Range(0, Obstacles.Length)];
        }

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }

    */

    /*
    public GameObject Obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float TimeBetweenSpawn;
    private float SpawnTime;

    void Update()
    {
        if(Time.time > SpawnTime)
        {
            Spawn();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
        
    }

    void Spawn()
    {
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);

        Instantiate(Obstacle, transform.position + new Vector3(X,Y,0),transform.rotation);
    }
    */
}
