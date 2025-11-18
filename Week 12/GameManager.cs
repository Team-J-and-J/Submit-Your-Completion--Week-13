using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab; // 👈 NEW — for spawning coins

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;

        // Initialize UI
        UpdateScoreText();
        ChangeLivesText(3); // Example starting lives (you can adjust)

        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();

        // Repeating spawns
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("CreateCoin", 2, 5); // 👈 NEW — spawn a coin every 5 seconds
    }

    void Update()
    {

    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab,
            new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0),
            Quaternion.Euler(180, 0, 0));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab,
                new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize),
                            Random.Range(-verticalScreenSize, verticalScreenSize),
                            0),
                Quaternion.identity);
        }
    }

    // 👇 NEW: Spawns coins at random positions
    void CreateCoin()
    {
        Instantiate(coinPrefab,
            new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize),
                        Random.Range(-verticalScreenSize * 0.5f, verticalScreenSize * 0.5f),
                        0),
            Quaternion.identity);
    }

    // 👇 Called by coins when collected
    public void AddScore(int earnedScore)
    {
        score += earnedScore;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}
