using UnityEngine;
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
        //if (isTouched && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (isTouched && (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
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
        displayedObject = Instantiate(objectToDisplay, Camera.main.transform.position + Camera.main.transform.forward * 2f, Quaternion.identity);
        displayText.text = description;

        // Make the object a child of the ARSessionOrigin (or the main camera)
        //displayedObject.transform.parent = FindObjectOfType<ARSessionOrigin>().transform;
        displayedObject.transform.parent = cameraLocation;
        displayedObject.transform.localScale *= 2f;

        // Start rotating the object and the delete timer
        displayedObject.AddComponent<RotateScript>().rotationSpeed = rotationSpeed;
        displayedObject.GetComponent<RotateScript>().displayText = displayText;
    }
}
