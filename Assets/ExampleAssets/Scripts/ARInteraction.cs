using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInteraction : MonoBehaviour
{
    public Text targetText; // Assign the Text component you want to update in the Inspector.

    public void UpdateText()
    {
        if (targetText != null)
        {
            // Update the Text component's text with the new value
            targetText.text = (int.Parse(targetText.text) + 1).ToString();
        }
    }

    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField]
    GameObject spawnablePrefab;

    Camera arCam;
    GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;


        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(8).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Spawnable")
                        spawnedObject = hit.collider.gameObject;
                    else
                        SpawnPrefab(m_Hits[0].pose.position);
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
                spawnedObject.transform.position = m_Hits[0].pose.position;
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
                spawnedObject = null;
            UpdateText();
        }
    }


    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }

}
