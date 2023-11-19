using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Linq; // Add this line
using TMPro;

public class MovePartScript : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private ARSessionOrigin arSessionOrigin;
    public TextMeshProUGUI displayText;

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        arSessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Raycast(touch.position, out ARRaycastHit hit))
                {
                    SelectObject(hit);
                }
            }
        }
    }

    bool Raycast(Vector2 screenPosition, out ARRaycastHit hit)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, TrackableType.AllTypes);

        hit = hits.FirstOrDefault();
        return hit != null;
    }

    void SelectObject(ARRaycastHit hit)
    {
        // Perform actions when an object is selected.
        // For example, you can log the name of the selected object:
        Debug.Log("Selected Object: " + hit.trackable.name);
        displayText.text = "Selected Object: " + hit.trackable.name;

    }
}
