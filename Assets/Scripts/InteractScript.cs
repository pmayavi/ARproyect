using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public int numberOfParts;
    // Start is called before the first frame update
    void Start()
    {
        numberOfParts = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PartInteraction()
    {
        numberOfParts++;
    }
}
