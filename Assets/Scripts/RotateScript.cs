using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotateScript : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public TextMeshProUGUI displayText;

    void Update()
    {
        // Rotate the object around its up axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            displayText.text = "";
            Destroy(gameObject);
        }
    }
}
