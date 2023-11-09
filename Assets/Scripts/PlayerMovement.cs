using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Speed of player movement
    public float rotationSpeed = 3.0f; // Speed of player rotation

    private float mouseX; // Mouse X input for rotation
    private bool isCursorLocked = true;

    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCursorLocked = !isCursorLocked;
            Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isCursorLocked;
        }
        if (isCursorLocked)
            Move();
    }

    void Move()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        // Player rotation with mouse input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        transform.localRotation = Quaternion.Euler(0, mouseX, 0);
    }
}


