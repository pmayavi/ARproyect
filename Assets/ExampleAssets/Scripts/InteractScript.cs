using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    Collision currentCollision = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentCollision != null && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Assuming only one touch at a time

            if (touch.phase == TouchPhase.Began)
            {
                Destroy(currentCollision.gameObject);
                currentCollision = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object should be deleted
        if (collision.gameObject.CompareTag("Interactuable"))
        {
            currentCollision = collision;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactuable"))
        {
            currentCollision = null;
        }
    }
}
