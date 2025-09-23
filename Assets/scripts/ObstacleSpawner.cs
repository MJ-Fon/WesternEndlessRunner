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
