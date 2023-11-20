using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScript : MonoBehaviour
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
    public Canvas suspectList;
    public Image poster;

    int currentIndex = 0;
    int suspectLine = 0;
    bool isTouched = false;
    bool isTalking = false;
    string suspect = "";
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
        if(collision.CompareTag("Player"))
            isTouched = true;
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Player"))
            isTouched = false;
    }

    public void SelectSuspect(string sus)
    {
        suspect = sus;
        currentIndex = -1;
        suspectList.enabled = false;
        SetVisibility(true);
    }

    void SetVisibility(bool set){
        image1.enabled = set;
        image2.enabled = set;
        bubbletext.enabled = set;
        bubble.enabled = set;
        bubblename.enabled = set;
    }

    void BeginConversation()
    {
        isTalking = true;
        isTouched = false;
        SetVisibility(true);
        Talk();
    }

    void WrongSuspect()
    {
        SetVisibility(true);
        suspectList.enabled = false;
        if (suspect == "Pepe")
            currentIndex = 8;
        else if(suspect == "Isaac")
            currentIndex = 9;
        else if(suspect == "Felicia")
            currentIndex = 10;
        else if(suspect == "Gabriela")
            currentIndex = 11;
        DisplayDialoge();
        suspect = "Wrong";
    }

    void DisplayDialoge()
    {
        image1.sprite = imageList1[currentIndex];
        image2.sprite = imageList2[currentIndex];
        bubbletext.text = textList[currentIndex];
        bubblename.text = speakerName[currentIndex];
    }

    public void Talk()
    {
        if (currentIndex == textList.Count)
        {
            poster.enabled = true;
            currentIndex++;
        }
        else if(currentIndex > textList.Count)
        {
            poster.enabled = false;
            isTalking = false;
            SetVisibility(false);
            Destroy(gameObject);
        }
        else if(currentIndex < 0 || suspect == "Wrong") {
            if(suspect == "Clementina")
            {
                currentIndex = 12;
                DisplayDialoge();
                currentIndex++;
            }
            else if (suspect == "Wrong")
            {
                suspect = "";
                currentIndex = suspectLine;
                SetVisibility(false);
                suspectList.enabled = true;
            }
            else if (suspect != "")
                WrongSuspect();
        }
        else if(textList[currentIndex] == "Select sus") 
        {
            currentIndex = -1;
            suspectLine = currentIndex;
            SetVisibility(false);
            suspectList.enabled = true;
        }
        else
        {
        // Update images and text based on the current index
        DisplayDialoge();
        // Cycle through the lists
        currentIndex++;
        }
    }

}