using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCScript : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public List<Sprite> imageList1; // List of Sprites for Image 1
    public List<Sprite> imageList2; // List of Sprites for Image 2
    public List<string> textList;   // List of Strings for Text
    public List<bool> speaker;

    public Image image1;
    public Image image2;
    public Image bubble;
    public TextMeshProUGUI bubbletext;

    int currentIndex = 0;
    GameObject displayedObject;
    bool isTouched = false;
    bool isTalking = false;
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
            BeginConversation();
        else if (isTalking && (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            Talk();
    }

    void OnTriggerEnter(Collider collision)
    {
        isTouched = true;
        displayText.text = "Presiona para hablar";
    }

    void OnTriggerExit(Collider collision)
    {
        isTouched = false;
        displayText.text = "";
    }

    void BeginConversation()
    {
        isTouched = false;
        isTalking = true;
        image1.enabled = true;
        image2.enabled = true;
        bubbletext.enabled = true;
        bubble.enabled = true;
        displayText.text = "";
        Talk();
    }

    public void Talk()
    {
        // Update images and text based on the current index
        image1.sprite = imageList1[currentIndex];
        image2.sprite = imageList2[currentIndex];
        bubbletext.text = textList[currentIndex];

        if (!speaker[currentIndex])
            bubble.rectTransform.localRotation = Quaternion.Euler(0, 180, 0);
        else
            bubble.rectTransform.localRotation = Quaternion.identity;

        // Cycle through the lists
        currentIndex++;
        if (currentIndex == Mathf.Min(imageList1.Count, imageList2.Count, textList.Count))
        {
            isTalking = false;
            image1.enabled = false;
            image2.enabled = false;
            bubbletext.enabled = false;
            bubble.enabled = false;
            Destroy(gameObject);
        }
    }

}