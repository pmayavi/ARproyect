using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractScript : MonoBehaviour
{
    public int numberOfParts;
    public int maxParts;
    public TextMeshProUGUI displayText;
    public GameObject evidence;

    // Start is called before the first frame update
    void Start()
    {
        numberOfParts = 0;
        displayText.text = "Pistas faltantes: " + maxParts;
    }

    public void PartInteraction()
    {
        numberOfParts++;
        if (maxParts - numberOfParts == 0)
        {
            displayText.text = "Encontraste todas las partes!";
            Invoke("Completed", 3f);
        }
        else if (maxParts - numberOfParts == 1)
        {
            evidence.SetActive(true);
        }
        else
            displayText.text = "Pistas faltantes: " + (maxParts - numberOfParts);
    }

    void Completed()
    {
        displayText.text = "";
    }
}
