using UnityEngine;
using UnityEngine.UI;

public class PartScript : MonoBehaviour
{
    private bool isTouched = false;
    public Text targetText; // Assign the Text component you want to update in the Inspector.

    public void UpdateText()
    {
        if (targetText != null)
        {
            // Update the Text component's text with the new value
            targetText.text = (int.Parse(targetText.text) + 1).ToString();
        }
    }

    void Update()
    {
        // Check for touch input on mobile devices
        if (Input.touchCount > 0)
        {
            UpdateText();
            Touch touch = Input.GetTouch(0); // Assuming only one touch at a time

            if (touch.phase == TouchPhase.Began && !isTouched)
            {
                // Cast a ray from the touch position
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider == GetComponent<Collider>())
                    {
                        // Make the object invisible when the collider is touched
                        gameObject.SetActive(false);
                        isTouched = true;
                        UpdateText();
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
        UpdateText();
    }
}
