using UnityEngine;

public class SpinCoin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 180f; // degrees per second

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
