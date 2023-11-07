using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogeScript : MonoBehaviour
{
    public List<Sprite> imageList1; // List of Sprites for Image 1
    public List<Sprite> imageList2; // List of Sprites for Image 2
    public List<string> textList;   // List of Strings for Text
    public List<bool> speaker;

    public Image image1;
    public Image image2;
    public Image bubble;
    public TextMeshProUGUI displayText;

    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial display elements
        image1.sprite = imageList1[currentIndex];
        image2.sprite = imageList2[currentIndex];
        displayText.text = textList[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))
        {
            // Cycle through the lists on touch
            currentIndex = (currentIndex + 1) % Mathf.Min(imageList1.Count, imageList2.Count, textList.Count);

            // Update images and text based on the current index
            image1.sprite = imageList1[currentIndex];
            image2.sprite = imageList2[currentIndex];
            displayText.text = textList[currentIndex];

            if (!speaker[currentIndex])
                bubble.rectTransform.localRotation = Quaternion.Euler(0, 180, 0);
            else
                bubble.rectTransform.localRotation = Quaternion.identity;
        }
    }
}
