using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class PartScript : MonoBehaviour
{
    public Transform cameraLocation;
    public TextMeshProUGUI displayText;
    public string description;
    public GameObject objectToDisplay;
    public float rotationSpeed = 30f;

    GameObject displayedObject;
    bool isTouched = false;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

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
        player.GetComponent<InteractScript>().PartInteraction();
        DisplayObject();
        Destroy(gameObject);
    }

    public void DisplayObject()
    {
        // Instantiate the object in front of the player
        //Transform camaraTransform = FindObjectOfType<ARSessionOrigin>().transform;
        displayedObject = Instantiate(objectToDisplay, cameraLocation.position + cameraLocation.forward * 2f, Quaternion.identity);
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
