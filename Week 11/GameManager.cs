using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;   // First enemy (straight movement)
    public GameObject enemyTwoPrefab;   // Second enemy (different pattern)

    void Start()
    {
        // Enemy 1: spawns every 2 seconds
        InvokeRepeating("CreateEnemyOne", 1f, 2f);

        // Enemy 2: spawns every 4 seconds (different spawn rate)
        InvokeRepeating("CreateEnemyTwo", 2f, 4f);
    }

    void CreateEnemyOne()
    {
        // Spawn enemy 1 at a random X position at the top
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        // Spawn enemy 2 at a random X position at the top
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
}
