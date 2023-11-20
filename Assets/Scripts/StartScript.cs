using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartScript : MonoBehaviour
{
    public List<Sprite> imageList1; // List of Sprites for Image 1
    public List<Sprite> imageList2; // List of Sprites for Image 2
    public List<string> textList;   // List of Strings for Text
    public List<string> speakerName;

    public Image image1;
    public Image image2;
    public Image bubble;
    public TextMeshProUGUI bubbletext;
    public TextMeshProUGUI bubblename;
    public Image poster;

    int currentIndex = -1;
    bool isTalking = false;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        BeginConversation();
    }

    void Update()
    {
        // Check for touch input on mobile devices
        if (isTalking && (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            Talk();
    }

    void BeginConversation()
    {
        isTalking = true;
        image1.enabled = true;
        image2.enabled = true;
        bubbletext.enabled = true;
        bubble.enabled = true;
        bubblename.enabled = true;
        Talk();
    }

    public void Talk()
    {
        if (currentIndex == -1)
            poster.enabled = true;
        else
        {
            poster.enabled = false;
            // Update images and text based on the current index
            image1.sprite = imageList1[currentIndex];
            image2.sprite = imageList2[currentIndex];
            bubbletext.text = textList[currentIndex];
            bubblename.text = speakerName[currentIndex];
        }

        // Cycle through the lists
        currentIndex++;
        
        if(currentIndex == Mathf.Min(imageList1.Count, imageList2.Count, textList.Count)) 
        {
            isTalking = false;
            image1.enabled = false;
            image2.enabled = false;
            bubbletext.enabled = false;
            bubble.enabled = false;
            bubblename.enabled = false;
            Destroy(gameObject);
        }
    }

}