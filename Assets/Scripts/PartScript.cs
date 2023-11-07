using UnityEngine;
using UnityEngine.UI;

public class PartScript : MonoBehaviour
{
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
        if (isTouched && Input.GetMouseButtonDown(0))
        {
            //Do something
            player.GetComponent<InteractScript>().PartInteraction();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        isTouched = true;
    }

    void OnTriggerExit(Collider collision)
    {
        isTouched = false;
    }
}
