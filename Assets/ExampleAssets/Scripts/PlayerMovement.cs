using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Speed of player movement
    public float rotationSpeed = 2f; // Speed of player rotation

    // Update is called once per frame
    void Update()
    {
        // Get player input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the input
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Move the player based on the calculated direction
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        // Rotate the player based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);
    }
}



