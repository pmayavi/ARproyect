using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class MaskStartScript : MonoBehaviour
{
    public TextMeshProUGUI startGameText;
    public TextMeshProUGUI displayText;
    public string description;
    public GameObject objectToDisplay;
    public float rotationSpeed = 30f;

    public Image reticicle;
    public Text targets;
    public Text count;
    public GameObject enemies;

    Transform cameraLocation;
    GameObject displayedObject;
    bool isTouched = false;
    bool isPlaying = false;
    GameObject player;
    MeshRenderer maskMesh;

    int items;
    public int maxItems;
    public ShootProjectile shooter;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraLocation = GameObject.FindGameObjectWithTag("MainCamera").transform;
        maskMesh = GetComponent<MeshRenderer>();
        count.text = items.ToString() + "/" + maxItems.ToString();
    }

    void Update()
    {
        // Check for touch input on mobile devices
        if (!isPlaying && isTouched && (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            Gotten();
    }

    void OnTriggerEnter(Collider collision)
    {
        startGameText.text = "Presiona para empezar el minijuego";
        isTouched = true;
    }

    void OnTriggerExit(Collider collision)
    {
        startGameText.text = "";
        isTouched = false;
    }

    public void Gotten()
    {
        isPlaying = true;
        reticicle.enabled = true;
        targets.enabled = true;
        count.enabled = true;
        shooter.enabled = true;
        startGameText.enabled = false;
        maskMesh.enabled = false;
        GameObject maskEnemies = Instantiate(enemies, cameraLocation.position, Quaternion.identity);
    }

    public void Completed()
    {
        reticicle.enabled = false;
        targets.enabled = false;
        count.enabled = false;
        shooter.enabled = false;
        player.GetComponent<InteractScript>().PartInteraction();
        DisplayObject();
        Destroy(gameObject);
    }

    public void PickItem()
    {
        items++;
        count.text = items.ToString() + "/" + maxItems.ToString();

        if (items == maxItems)
        {
            Completed();
        }
    }

    public void DisplayObject()
    {
        // Instantiate the object in front of the player
        //Transform camaraTransform = FindObjectOfType<ARSessionOrigin>().transform;
        displayedObject = Instantiate(objectToDisplay, cameraLocation.position + cameraLocation.forward * 2f, Quaternion.Euler(180f, 0f, 0f));
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
