using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class PartScript : MonoBehaviour
{
    public string description;
    public GameObject objectToDisplay;
    public float rotationSpeed = 30f;

    GameObject displayedObject;
    bool isTouched = false;

    void Update()
    {
        // Check for touch input on mobile devices
        if (isTouched && (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            //if (isTouched)
            Gotten();
    }

    void OnTriggerEnter(Collider collision)
    {
        isTouched = true;
    }

    void OnTriggerExit(Collider collision)
    {
        isTouched = false;
    }

    public void Gotten()
    {
        DisplayObject(objectToDisplay);
        Destroy(gameObject);
    }

    public void DisplayObject(GameObject obj)
    {
        Transform cameraLocation = GameObject.FindGameObjectWithTag("MainCamera").transform;
        TextMeshProUGUI displayText = GameObject.FindGameObjectWithTag("UIDetails").GetComponent<TextMeshProUGUI>();
        // Instantiate the object in front of the player
        //Transform camaraTransform = FindObjectOfType<ARSessionOrigin>().transform;
        displayedObject = Instantiate(obj, cameraLocation.position + cameraLocation.forward * 2f, Quaternion.identity);
        displayText.text = description;

        // Make the object a child of the ARSessionOrigin (or the main camera)
        //displayedObject.transform.parent = camaraTransform;
        displayedObject.transform.parent = cameraLocation;
        displayedObject.transform.localScale *= 2f;

        // Start rotating the object and the delete timer
        displayedObject.AddComponent<RotateScript>().rotationSpeed = rotationSpeed;
        displayedObject.GetComponent<RotateScript>().displayText = displayText;
    }
}
