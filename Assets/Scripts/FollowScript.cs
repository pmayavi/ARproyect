using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform player; // Reference to the player's transform.
    public float distance = 3.0f; // Desired distance from the player.

    private Vector3 offset; // Offset from the player.

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player transform not assigned. Please assign the player's transform in the Inspector.");
            enabled = false; // Disable the script to prevent errors.
            return;
        }

        // Calculate the initial offset.
        offset = transform.position - player.position;
    }

    private void Update()
    {
        // Calculate the target position.
        Vector3 targetPosition = player.position + offset.normalized * distance;

        // Smoothly move towards the target position.
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
}

