using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCScript : MonoBehaviour
{
    public GameObject displayObject;
    public TextMeshProUGUI displayText;
    public List<Sprite> imageList1; // List of Sprites for Image 1
    public List<Sprite> imageList2; // List of Sprites for Image 2
    public List<string> textList;   // List of Strings for Text
    public List<string> speakerName;

    public Image image1;
    public Image image2;
    public Image bubble;
    public TextMeshProUGUI bubbletext;
    public TextMeshProUGUI bubblename;

    int currentIndex = 0;
    bool isTouched = false;
    bool isTalking = false;
    GameObject player;
    GameObject displayedObject;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Check for touch input on mobile devices
        //if (isTouched && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (isTouched && (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            BeginConversation();
        else if (isTalking && (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            Talk();
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            isTouched = true;
            displayText.text = "Presiona para hablar";
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            isTouched = false;
            displayText.text = "";
        }
    }

    void BeginConversation()
    {
        isTouched = false;
        isTalking = true;
        image1.enabled = true;
        image2.enabled = true;
        bubbletext.enabled = true;
        bubble.enabled = true;
        bubblename.enabled = true;
        displayText.text = "";
        Talk();
    }

    public void Talk()
    {
        if (currentIndex == textList.Count)
        {
            isTalking = false;
            image1.enabled = false;
            image2.enabled = false;
            bubbletext.enabled = false;
            bubble.enabled = false;
            bubblename.enabled = false;
            if (displayObject){
                displayObject.GetComponent<PartScript>().DisplayObject(displayObject);
            }
            Destroy(gameObject);
        }
        else
        {
        // Update images and text based on the current index
        image1.sprite = imageList1[currentIndex];
        image2.sprite = imageList2[currentIndex];
        bubbletext.text = textList[currentIndex];
        bubblename.text = speakerName[currentIndex];

        // Cycle through the lists
        currentIndex++;
        }
    }

}