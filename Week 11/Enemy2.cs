using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private float verticalSpeed = 2.5f;
    private float horizontalSpeed = 3f;
    private float moveDirection = 1f;

    void Update()
    {
        // Move diagonally (zig-zag down)
        transform.Translate(new Vector3(moveDirection * horizontalSpeed, -verticalSpeed, 0) * Time.deltaTime);

        // Reverse horizontal direction when reaching edges
        if (transform.position.x > 8.5f)
        {
            moveDirection = -1f;
        }
        else if (transform.position.x < -8.5f)
        {
            moveDirection = 1f;
        }

        // Destroy enemy when it leaves bottom of screen
        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }
}
