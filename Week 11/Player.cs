using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;

    public GameObject bulletPrefab;

    private Camera mainCamera;
    private float bottomLimit;
    private float middleLimit;

    void Start()
    {
        playerSpeed = 6f;

        // Get the main camera
        mainCamera = Camera.main;

        // Calculate bottom and middle Y positions in world space
        bottomLimit = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;  // bottom of screen
        middleLimit = mainCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y;  // middle of screen

        // Start the player somewhere in the bottom half
        transform.position = new Vector3(0, bottomLimit + 1f, 0);
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        // Get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the player in world space
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * playerSpeed * Time.deltaTime, Space.World);

        // Horizontal wrap-around
        if (transform.position.x > horizontalScreenLimit)
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        else if (transform.position.x < -horizontalScreenLimit)
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);

        // Clamp vertical position to bottom half
        float clampedY = Mathf.Clamp(transform.position.y, bottomLimit, middleLimit);
        transform.position = new Vector3(transform.position.x, clampedY, 0);
    }
}
