using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;
    private GameManager gameManager;

    private void Start()
    {
        // Find the GameManager in the scene and store a reference
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add 1 point to the score
            gameManager.AddScore(1);

            // Destroy the coin when collected
            Destroy(gameObject);
        }
    }
}